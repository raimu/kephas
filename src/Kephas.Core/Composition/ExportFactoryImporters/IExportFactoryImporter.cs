﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExportFactoryImporter.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Declares the IExportFactoryImporter interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Composition.ExportFactoryImporters
{
    using Kephas.Services;

    /// <summary>
    /// Interface for importers of an export factory.
    /// </summary>
    public interface IExportFactoryImporter
    {
        /// <summary>
        /// Gets the export factory.
        /// </summary>
        /// <value>
        /// The export factory.
        /// </value>
        object ExportFactory { get; }
    }

    /// <summary>
    /// Generic service contract for importers of an export factory with metadata.
    /// </summary>
    /// <typeparam name="TService">Type of the service.</typeparam>
    [AppServiceContract(AsOpenGeneric = true)]
    public interface IExportFactoryImporter<out TService> : IExportFactoryImporter
    {
        /// <summary>
        /// Gets the export factory.
        /// </summary>
        /// <value>
        /// The export factory.
        /// </value>
        new IExportFactory<TService> ExportFactory { get; }
    }

    /// <summary>
    /// Generic service contract for importers of an export factory with metadata.
    /// </summary>
    /// <typeparam name="TService">Type of the service.</typeparam>
    /// <typeparam name="TMetadata">Type of the metadata.</typeparam>
    [AppServiceContract(AsOpenGeneric = true)]
    public interface IExportFactoryImporter<out TService, out TMetadata> : IExportFactoryImporter
    {
        /// <summary>
        /// Gets the export factory.
        /// </summary>
        /// <value>
        /// The export factory.
        /// </value>
        new IExportFactory<TService, TMetadata> ExportFactory { get; }
    }
}