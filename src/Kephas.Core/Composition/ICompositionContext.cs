﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICompositionContext.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Public interface for the composition context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Composition
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Reflection;

    using Kephas.Composition.ExportFactoryImporters;
    using Kephas.Composition.Internal;
    using Kephas.Reflection;

    /// <summary>
    /// Public interface for the composition context.
    /// </summary>
    public interface ICompositionContext : IDisposable
    {
        /// <summary>
        /// Resolves the specified contract type.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <param name="contractName">The contract name.</param>
        /// <returns>An object implementing <paramref name="contractType"/>.</returns>
        object GetExport(Type contractType, string contractName = null);

        /// <summary>
        /// Resolves the specified contract type returning multiple instances.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <param name="contractName">The contract name.</param>
        /// <returns>An enumeration of objects implementing <paramref name="contractType"/>.</returns>
        IEnumerable<object> GetExports(Type contractType, string contractName = null);

        /// <summary>
        /// Resolves the specified contract type.
        /// </summary>
        /// <typeparam name="T">The service type.</typeparam>
        /// <param name="contractName">The contract name.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />.
        /// </returns>
        T GetExport<T>(string contractName = null);

        /// <summary>
        /// Resolves the specified contract type returning multiple instances.
        /// </summary>
        /// <typeparam name="T">The service type.</typeparam>
        /// <param name="contractName">The contract name.</param>
        /// <returns>
        /// An enumeration of objects implementing <typeparamref name="T" />.
        /// </returns>
        IEnumerable<T> GetExports<T>(string contractName = null);

        /// <summary>
        /// Tries to resolve the specified contract type.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <param name="contractName">The contract name.</param>
        /// <returns>An object implementing <paramref name="contractType"/>, or <c>null</c> if a service with the provided contract was not found.</returns>
        object TryGetExport(Type contractType, string contractName = null);

        /// <summary>
        /// Tries to resolve the specified contract type.
        /// </summary>
        /// <typeparam name="T">The service type.</typeparam>
        /// <param name="contractName">The contract name.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />, or <c>null</c> if a service with the provided contract was not found.
        /// </returns>
        T TryGetExport<T>(string contractName = null);

        /// <summary>
        /// Creates a new scoped composition context.
        /// </summary>
        /// <param name="scopeName">The scope name. If not provided the <see cref="ScopeNames.Default"/> scope name is used.</param>
        /// <returns>
        /// The new scoped context.
        /// </returns>
        ICompositionContext CreateScopedContext(string scopeName = ScopeNames.Default);
    }

    /// <summary>
    /// Extension methods for <see cref="ICompositionContext"/>.
    /// </summary>
    public static class CompositionContextExtensions
    {
        /// <summary>
        /// Initializes static members of the <see cref="CompositionContextExtensions"/> class.
        /// </summary>
        static CompositionContextExtensions()
        {
            GetExportFactory1Method = ReflectionHelper.GetGenericMethodOf(_ => GetExportFactory<int>(null));
            GetExportFactory2Method = ReflectionHelper.GetGenericMethodOf(_ => GetExportFactory<int, int>(null));
            GetExportFactories1Method = ReflectionHelper.GetGenericMethodOf(_ => GetExportFactories<int>(null));
            GetExportFactories2Method = ReflectionHelper.GetGenericMethodOf(_ => GetExportFactories<int, int>(null));
        }

        /// <summary>
        /// Gets the <see cref="GetExportFactory{T}"/> method.
        /// </summary>
        /// <value>
        /// The <see cref="GetExportFactory{T}"/> method.
        /// </value>
        private static MethodInfo GetExportFactory1Method { get; }

        /// <summary>
        /// Gets the <see cref="GetExportFactory{T, TMetadata}"/> method.
        /// </summary>
        /// <value>
        /// The <see cref="GetExportFactory{T, TMetadata}"/> method.
        /// </value>
        private static MethodInfo GetExportFactory2Method { get; }

        /// <summary>
        /// Gets the <see cref="GetExportFactories{T}"/> method.
        /// </summary>
        /// <value>
        /// The <see cref="GetExportFactories{T}"/> method.
        /// </value>
        private static MethodInfo GetExportFactories1Method { get; }

        /// <summary>
        /// Gets the <see cref="GetExportFactories{T, TMetadata}"/> method.
        /// </summary>
        /// <value>
        /// The <see cref="GetExportFactories{T, TMetadata}"/> method.
        /// </value>
        private static MethodInfo GetExportFactories2Method { get; }

        /// <summary>
        /// Converts a <see cref="ICompositionContext"/> to a <see cref="IServiceProvider"/>.
        /// </summary>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <returns>
        /// compositionContext as an IServiceProvider.
        /// </returns>
        public static IServiceProvider ToServiceProvider(this ICompositionContext compositionContext)
        {
            Contract.Requires(compositionContext != null);

            return new CompositionContextServiceProviderAdapter(compositionContext);
        }

        /// <summary>
        /// Resolves the specified contract type as an export factory.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />.
        /// </returns>
        public static IExportFactory<T> GetExportFactory<T>(this ICompositionContext compositionContext)
        {
            Contract.Requires(compositionContext != null);

            var importerType = typeof(IExportFactoryImporter<>).MakeGenericType(typeof(T));
            var importer = (IExportFactoryImporter)compositionContext.GetExport(importerType);
            return (IExportFactory<T>)importer.ExportFactory;
        }

        /// <summary>
        /// Resolves the specified contract type as an export factory with metadata.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <typeparam name="TMetadata">The metadata type.</typeparam>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />.
        /// </returns>
        public static IExportFactory<T, TMetadata> GetExportFactory<T, TMetadata>(this ICompositionContext compositionContext)
        {
            Contract.Requires(compositionContext != null);

            var importerType = typeof(IExportFactoryImporter<,>).MakeGenericType(typeof(T), typeof(TMetadata));
            var importer = (IExportFactoryImporter)compositionContext.GetExport(importerType);
            return (IExportFactory<T, TMetadata>)importer.ExportFactory;
        }

        /// <summary>
        /// Resolves the specified contract type as an enumeration of export factories.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />.
        /// </returns>
        public static IEnumerable<IExportFactory<T>> GetExportFactories<T>(this ICompositionContext compositionContext)
        {
            Contract.Requires(compositionContext != null);

            var importerType = typeof(ICollectionExportFactoryImporter<>).MakeGenericType(typeof(T));
            var importer = (ICollectionExportFactoryImporter)compositionContext.GetExport(importerType);
            return (IEnumerable<IExportFactory<T>>)importer.ExportFactories;
        }

        /// <summary>
        /// Resolves the specified contract type as an enumeration of export factories with metadata.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <typeparam name="TMetadata">The metadata type.</typeparam>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />.
        /// </returns>
        public static IEnumerable<IExportFactory<T, TMetadata>> GetExportFactories<T, TMetadata>(this ICompositionContext compositionContext)
        {
            Contract.Requires(compositionContext != null);

            var importerType = typeof(ICollectionExportFactoryImporter<,>).MakeGenericType(typeof(T), typeof(TMetadata));
            var importer = (ICollectionExportFactoryImporter)compositionContext.GetExport(importerType);
            return (IEnumerable<IExportFactory<T, TMetadata>>)importer.ExportFactories;
        }

        /// <summary>
        /// Tries to resolve the specified contract type as an export factory.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />, or <c>null</c>.
        /// </returns>
        public static IExportFactory<T> TryGetExportFactory<T>(this ICompositionContext compositionContext)
        {
            Contract.Requires(compositionContext != null);

            var importerType = typeof(IExportFactoryImporter<>).MakeGenericType(typeof(T));
            var importer = (IExportFactoryImporter)compositionContext.TryGetExport(importerType);
            return (IExportFactory<T>)importer?.ExportFactory;
        }

        /// <summary>
        /// Tries to esolve the specified contract type as an export factory with metadata.
        /// </summary>
        /// <typeparam name="T">The contract type.</typeparam>
        /// <typeparam name="TMetadata">The metadata type.</typeparam>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <returns>
        /// An object implementing <typeparamref name="T" />, or <c>null</c>.
        /// </returns>
        public static IExportFactory<T, TMetadata> TryGetExportFactory<T, TMetadata>(this ICompositionContext compositionContext)
        {
            Contract.Requires(compositionContext != null);

            var importerType = typeof(IExportFactoryImporter<,>).MakeGenericType(typeof(T), typeof(TMetadata));
            var importer = (IExportFactoryImporter)compositionContext.TryGetExport(importerType);
            return (IExportFactory<T, TMetadata>)importer?.ExportFactory;
        }

        /// <summary>
        /// Resolves the specified contract type as an export factory.
        /// </summary>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>
        /// A export factory of an object implementing <paramref name="contractType"/>.
        /// </returns>
        public static object GetExportFactory(this ICompositionContext compositionContext, Type contractType)
        {
            Contract.Requires(compositionContext != null);
            Contract.Requires(contractType != null);

            var getExport = GetExportFactory1Method.MakeGenericMethod(contractType);
            return getExport.Call(null, compositionContext);
        }

        /// <summary>
        /// Resolves the specified contract type as an export factory with metadata.
        /// </summary>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <param name="contractType">Type of the contract.</param>
        /// <param name="metadataType">Type of the metadata.</param>
        /// <returns>
        /// A export factory of an object implementing <paramref name="contractType"/> with <paramref name="metadataType"/> metadata.
        /// </returns>
        public static object GetExportFactory(this ICompositionContext compositionContext, Type contractType, Type metadataType)
        {
            Contract.Requires(compositionContext != null);
            Contract.Requires(contractType != null);
            Contract.Requires(metadataType != null);

            var getExport = GetExportFactory2Method.MakeGenericMethod(contractType, metadataType);
            return getExport.Call(null, compositionContext);
        }

        /// <summary>
        /// Resolves the specified contract type as an enumeration of export factories.
        /// </summary>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>
        /// An enumeration of export factories of an object implementing <paramref name="contractType"/>.
        /// </returns>
        public static IEnumerable GetExportFactories(this ICompositionContext compositionContext, Type contractType)
        {
            Contract.Requires(compositionContext != null);
            Contract.Requires(contractType != null);

            var getExport = GetExportFactories1Method.MakeGenericMethod(contractType);
            return (IEnumerable)getExport.Call(null, compositionContext);
        }

        /// <summary>
        /// Resolves the specified contract type as an enumeration of export factories with metadata.
        /// </summary>
        /// <param name="compositionContext">The compositionContext to act on.</param>
        /// <param name="contractType">Type of the contract.</param>
        /// <param name="metadataType">Type of the metadata.</param>
        /// <returns>
        /// An enumeration of export factories of an object implementing <paramref name="contractType"/> with <paramref name="metadataType"/> metadata.
        /// </returns>
        public static IEnumerable GetExportFactories(this ICompositionContext compositionContext, Type contractType, Type metadataType)
        {
            Contract.Requires(compositionContext != null);
            Contract.Requires(contractType != null);
            Contract.Requires(metadataType != null);

            var getExport = GetExportFactories2Method.MakeGenericMethod(contractType, metadataType);
            return (IEnumerable)getExport.Call(null, compositionContext);
        }
    }
}