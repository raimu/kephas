﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelSpaceAppInitializer.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Application initializer for the model space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Model.Application
{
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using Kephas.Application;
    using Kephas.Services;

    /// <summary>
    /// Application initializer for the model space.
    /// </summary>
    [ProcessingPriority(Priority.High)]
    public class ModelSpaceAppInitializer : AppInitializerBase
    {
        /// <summary>
        /// The model space provider.
        /// </summary>
        private readonly IModelSpaceProvider modelSpaceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSpaceAppInitializer"/> class.
        /// </summary>
        /// <param name="modelSpaceProvider">The model space provider.</param>
        public ModelSpaceAppInitializer(IModelSpaceProvider modelSpaceProvider)
        {
            Contract.Requires(modelSpaceProvider != null);

            this.modelSpaceProvider = modelSpaceProvider;
        }

        /// <summary>
        /// Initializes the application asynchronously.
        /// </summary>
        /// <param name="appContext">Context for the application.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// A Task.
        /// </returns>
        protected override Task InitializeCoreAsync(IAppContext appContext, CancellationToken cancellationToken)
        {
            return this.modelSpaceProvider.InitializeAsync(appContext, cancellationToken);
        }
    }
}