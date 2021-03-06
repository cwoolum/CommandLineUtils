// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions
{
    /// <summary>
    /// Sets <see cref="CommandLineApplication.Name"/> using the name of the entry assembly
    /// to the current application. It is only applied if the name is null.
    /// </summary>
    public class AppNameFromEntryAssemblyConvention : IConvention
    {
        /// <inheritdoc />
        public virtual void Apply(ConventionContext context)
        {
            if (context.Application.Name != null || context.Application.Parent != null)
            {
                return;
            }

            var assembly = Assembly.GetEntryAssembly();
            if (assembly == null && context.ModelType != null)
            {
                assembly = context.ModelType.GetTypeInfo().Assembly;
            }

            if (assembly != null)
            {
                context.Application.Name = assembly.GetName().Name;
            }
        }
    }
}
