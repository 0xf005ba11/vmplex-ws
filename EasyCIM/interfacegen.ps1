#
# Copyright (c) 2022 Ira Strawser. All rights reserved.
#

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$JsonConfig
)

$CimFlags = [Microsoft.Management.Infrastructure.CimFlags]
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
    'Instance' = 'CimInstance'
    'Reference' = 'CimInstance'
    'ReferenceArray' = 'CimInstance[]'
    'InstanceArray' = 'CimInstance[]'
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

    '    [CimClassName("{0}", @"{1}")]' -f $Class.CimClassName, $Config.cim_namespace
    '    public interface I{0} : ICimObject' -f $Class.CimClassName
    '    {'

    # class properties
    $enumerator = $Class.CimClassProperties.GetEnumerator()
    while ( $enumerator.MoveNext() )
    {
        $prop = $enumerator.Current
        $cimType = $prop.CimType.ToString()
        $csType = $CimTypeMap[$cimType]
        $key = if ( IsKey $prop ) { '[CimKey] ' } else { '' }

        '        {0}{1}? {2}{{ get; set; }}' -f $key, $csType, $prop.Name
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
        $static = if ( IsStaticMethod $method ) { '[CimStatic] ' } else { '' }
        $penum = $method.Parameters.GetEnumerator()
        $args = ''
        while ( $penum.MoveNext() )
        {
            $param = $penum.Current
            $out = ''
            $nullable = ''
            if ( IsOutParam $param )
            {
                $out = 'out '
                $nullable = '?'
            }
            $argType = $CimTypeMap[$param.CimType.ToString()]
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
                    $argType = 'ICimObject'
                }
            }
            if ( $args.Length -ne 0 )
            {
                $args += ', '
            }
            $args += '{0}{1}{2} {3}' -f $out, $argType, $nullable, $param.Name
        }
        '        {0}{1} {2}({3});' -f $static, $retType, $method.Name, $args
    }

    '    }'
}

function ProcessClasses {
    param ($classQueue, $Config)

    'using System;'
    'using Microsoft.Management.Infrastructure;'
    'using EasyCIM;'
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
