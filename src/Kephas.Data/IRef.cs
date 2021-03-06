﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRef.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Structure used to define and retrieve a referenced entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Data
{
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;

    using Kephas.Data.Commands;

    /// <summary>
    /// Structure used to define and retrieve a referenced entity.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    [ContractClass(typeof(RefContractClass<>))]
    public interface IRef<T> : IIdentifiable
        where T : class
    {
        /// <summary>
        /// Gets or sets the identifier of the referenced entity.
        /// </summary>
        /// <value>
        /// The identifier of the referenced entity.
        /// </value>
        new Id Id { get; set; }

        /// <summary>
        /// Gets the referenced entity asynchronously.
        /// </summary>
        /// <param name="operationContext">The operationContext for finding the entity (optional).</param>
        /// <param name="cancellationToken">The cancellation token (optional).</param>
        /// <returns>
        /// A task promising the referenced entity.
        /// </returns>
        Task<T> GetAsync(IFindContext<T> operationContext = null, CancellationToken cancellationToken = default(CancellationToken));
    }

    /// <summary>
    /// Contract class for <see cref="IRef{T}"/>.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    [ContractClassFor(typeof(IRef<>))]
    internal abstract class RefContractClass<T> : IRef<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets the identifier of the referenced entity.
        /// </summary>
        /// <value>
        /// The identifier of the referenced entity.
        /// </value>
        public Id Id
        {
            get
            {
                Contract.Ensures(Contract.Result<Id>() != null);
                return Contract.Result<Id>();
            }

            set
            {
                Contract.Requires(value != null);
            }
        }

        /// <summary>
        /// Gets the referenced entity asynchronously.
        /// </summary>
        /// <param name="operationContext">The operationContext for finding the entity (optional).</param>
        /// <param name="cancellationToken">The cancellation token (optional).</param>
        /// <returns>
        /// A task promising the referenced entity.
        /// </returns>
        public Task<T> GetAsync(IFindContext<T> operationContext = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Contract.Ensures(Contract.Result<Task<T>>() != null);

            return Contract.Result<Task<T>>();
        }
    }
}