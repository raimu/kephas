﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Net45HostingEnvironment.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   The hosting environment for .NET 4.5 applications.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Hosting.NetCore.Hosting.NetCore
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Kephas.Application;
    using Kephas.Reflection;

    /// <summary>
    /// The hosting environment for .NET 4.5 applications.
    /// </summary>
    public class NetCoreAppEnvironment : AppEnvironmentBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetCoreAppEnvironment" /> class.
        /// </summary>
        /// <param name="assemblyLoader">The assembly loader.</param>
        public NetCoreAppEnvironment(IAssemblyLoader assemblyLoader)
            : base(assemblyLoader)
        {
        }

        /// <summary>
        /// Adds additional assemblies to the ones already collected.
        /// </summary>
        /// <param name="assemblies">The collected assemblies.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// A Task.
        /// </returns>
        protected override Task AddAdditionalAssembliesAsync(IList<Assembly> assemblies, CancellationToken cancellationToken)
        {
            // TODO add additional assemblies from the app folder.
            return base.AddAdditionalAssembliesAsync(assemblies, cancellationToken);
        }
    }
}