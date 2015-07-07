﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlatformManager.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Provides platform specific functionality.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Runtime
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides platform specific functionality.
    /// </summary>
    [ContractClass(typeof(PlatformManagerContractClass))]
    public interface IPlatformManager
    {
        /// <summary>
        /// Gets the application assemblies.
        /// </summary>
        /// <returns>An enumeration of application assemblies.</returns>
        Task<IEnumerable<Assembly>> GetAppAssembliesAsync();
    }

    /// <summary>
    /// Code contracts for <see cref="IPlatformManager"/>.
    /// </summary>
    [ContractClassFor(typeof(IPlatformManager))]
    internal abstract class PlatformManagerContractClass : IPlatformManager
    {
        /// <summary>
        /// Gets the application assemblies.
        /// </summary>
        /// <returns>
        /// An enumeration of application assemblies.
        /// </returns>
        public Task<IEnumerable<Assembly>> GetAppAssembliesAsync()
        {
            Contract.Ensures(Contract.Result<Task<IEnumerable<Assembly>>>() != null);
            return Contract.Result<Task<IEnumerable<Assembly>>>();
        }
    }
}