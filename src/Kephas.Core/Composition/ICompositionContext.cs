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
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using Kephas.Composition.Internal;

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
    }
}