#
# Copyright (c) 2022 Ira Strawser. All rights reserved.
#

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$JsonConfig
)

$CimTypeMap = @{
    'Boolean' = 'bool'
    'UInt8' = 'byte'
    'SInt8' = 'sbyte'
    'UInt16' = 'ushort'
    'SInt16' = 'short'
    'UInt32' = 'uint'
    'SInt32' = 'int'
    'UInt64' = 'UInt64'
    'SInt64' = 'Int64'
    'Real32' = 'float'
    'Real64' = 'double'
    'Char16' = 'char'
    'DateTime' = 'DateTime'
    'String' = 'string'
    'BooleanArray' = 'bool[]'
    'UInt8Array' = 'byte[]'
    'SInt8Array' = 'sbyte[]'
    'UInt16Array' = 'ushort[]'
    'SInt16Array' = 'short[]'
    'UInt32Array' = 'uint[]'
    'SInt32Array' = 'int[]'
    'UInt64Array' = 'UInt64[]'
    'SInt64Array' = 'Int64[]'
    'Real32Array' = 'float[]'
    'Real64Array' = 'double[]'
    'Char16Array' = 'char[]'
    'DateTimeArray' = 'DateTime[]'
    'StringArray' = 'string[]'
    'Instance' = 'ManagementBaseObject'
    'Reference' = 'ManagementBaseObject'
    'ReferenceArray' = 'ManagementBaseObject[]'
    'InstanceArray' = 'ManagementBaseObject[]'
}

function GetQualifier {
    param(
        $CimParam,
        $QualName
    )
    return $CimParam.Qualifiers[$QualName]
}

function IsKey {
    param( $Prop )

    return $(GetQualifier $Prop 'KEY') -ne $null
}

function IsOutParam {
    param( $CimParam )
    $out = GetQualifier $CimParam 'OUT'
    return $out -ne $null
}

function IsStaticMethod {
    param ( $Method )
    return $(GetQualifier $method 'Static') -ne $null
}

function GenClass {
    param (
        [ref]$ClassQueue,
        $Config,
        $Class
    )

    '    [WmiClassName("{0}", @"{1}")]' -f $Class.CimClassName, $Config.cim_namespace
    '    public class I{0} : IWmiObject' -f $Class.CimClassName
    '    {'
    #'        public ManagementBaseObject __Instance{ get; }'
    #''
    '        public I{0}(ManagementBaseObject instance) {{ __Instance = instance; }}' -f $Class.CimClassName
    ''

    # class properties
    $enumerator = $Class.CimClassProperties.GetEnumerator()
    while ( $enumerator.MoveNext() )
    {
        $prop = $enumerator.Current
        $propName = if ($prop.Name -eq 'volatile') { 'Volatile' } else { $prop.Name }
        $cimType = $prop.CimType.ToString()
        $csType = $CimTypeMap[$cimType]
        $key = if ( IsKey $prop ) { '[WmiKey] ' } else { '' }

        $getter = 'WmiClassImpl.GetProperty<{0}>(__Instance, "{1}")' -f $csType, $propName
        $setter = 'WmiClassImpl.SetProperty<{0}>(__Instance, "{1}", value)' -f $csType, $propName
        '        {0}public {1}? {2}{{ get => {3}; set => {4}; }}' -f $key, $csType, $propName, $getter, $setter
    }

    #class methods
    $first = $true
    $enumerator = $Class.CimClassMethods.GetEnumerator()
    while ( $enumerator.MoveNext() )
    {
        if ( $first )
        {
            ''
            $first = $false
        }
        $method = $enumerator.Current
        $retType = $CimTypeMap[$method.ReturnType.ToString()]
        $static = if ( IsStaticMethod $method ) { '[WmiStatic] ' } else { '' }
        $penum = $method.Parameters.GetEnumerator()
        $args = ''
        $ins = @()
        $outs = @()
        while ( $penum.MoveNext() )
        {
            $param = $penum.Current
            $out = ''
            $nullable = ''
            $argType = $CimTypeMap[$param.CimType.ToString()]
            if ( IsOutParam $param )
            {
                $out = 'out '
                $nullable = '?'
                $outs += '{1} = WmiClassImpl.GetProperty<{0}>(outParams, "{1}");' -f $argType, $param.Name
            }
            else
            {
                $ins += 'WmiClassImpl.SetProperty<{0}>(inParams, "{1}", {1});' -f $argType, $param.Name
            }
            if ($argType -eq 'CimInstance')
            {
                if ( $param.ReferenceClassName -ne $null )
                {
                    $argType = 'I{0}' -f $param.ReferenceClassName
                    $refClass = Get-CimClass -ClassName $param.ReferenceClassName -Namespace $Config.cim_namespace
                    $ClassQueue.value.Enqueue($refClass)
                }
                else
                {
                    $argType = 'IWmiObject'
                }
            }
            if ( $args.Length -ne 0 )
            {
                $args += ', '
            }
            $args += '{0}{1}{2} {3}' -f $out, $argType, $nullable, $param.Name
        }
        if ($retType -ne 'void')
        {
            $outs += 'return WmiClassImpl.GetProperty<{0}>(outParams, "ReturnValue");' -f $retType
        }
        '        {0}public {1} {2}({3})' -f $static, $retType, $method.Name, $args
        '        {'
        '            ManagementBaseObject inParams = WmiClassImpl.MethodParameters(__Instance, "{0}");' -f $method.Name
        foreach ( $line in $ins ) { '            {0}' -f $line }
        '            ManagementBaseObject outParams = ((ManagementObject)__Instance).InvokeMethod("{0}", inParams, null!);' -f $method.Name
        foreach ( $line in $outs ) { '            {0}' -f $line }
        '        }'
    }

    '    }'
}

function ProcessClasses {
    param ($classQueue, $Config)

    'using System;'
    'using System.Management;'
    'using EasyWMI;'
    ''
    'namespace {0}' -f $Config.namespace
    '{'

    $done = @{}
    $first = $true
    while ( $classQueue.Count )
    {
        $entry = $classQueue.Dequeue()
        if ($done.Item($entry.CimClassName) -ne $null)
        {
            continue
        }
        if ($first -eq $false) { '' }
        $first = $false
        $done[$entry.CimClassName] = $true
        GenClass ([ref]$classQueue) $Config $entry
    }
    '}'
}

function ProcessConfig {
    param (
        [string]$JsonPath
    )

    $config = Get-Content -Raw -Path $JsonPath | ConvertFrom-Json

    foreach ( $entry in $config )
    {
        $classQueue = [System.Collections.Queue]::new()

        foreach ( $nameGlob in $entry.classes )
        {
            $classes = Get-CimClass -Namespace $entry.cim_namespace -ClassName $nameGlob
            if ( $classes.Count -eq 1 )
            {
                $classQueue.Enqueue( $classes )
            }
            else
            {
                $enumerator = $classes.GetEnumerator()
                while ( $enumerator.MoveNext() )
                {
                    $classQueue.Enqueue($enumerator.Current)
                }
            }
        }

        $cs = ProcessClasses $classQueue $entry
        Out-File -Encoding ascii -FilePath $entry.path -InputObject $cs
    }

}

ProcessConfig $JsonConfig
