/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System.Reflection;
using System.Reflection.Emit;

namespace EasyWMI
{
    public class WmiAssembly
    {
        public AssemblyName AssemblyName { get; }
        public AssemblyBuilder AssemblyBuilder { get; }
        public ModuleBuilder ModuleBuilder { get; }

        public WmiAssembly()
        {
            AssemblyName = new AssemblyName(Guid.NewGuid().ToString());
            AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(AssemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder = AssemblyBuilder.DefineDynamicModule("WmiGen");
        }
    }
}
