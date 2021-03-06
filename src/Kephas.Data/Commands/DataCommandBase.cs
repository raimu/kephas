﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCommandBase.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Implements the data command base class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Data.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using Kephas.Threading.Tasks;

    /// <summary>
    /// Base implementation of a data command.
    /// </summary>
    /// <typeparam name="TContext">Type of the operationContext.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public abstract class DataCommandBase<TContext, TResult> : IDataCommand<TContext, TResult>
        where TContext : IDataOperationContext
        where TResult : IDataCommandResult
    {
        /// <summary>
        /// Executes the data command asynchronously.
        /// </summary>
        /// <param name="context">The operationContext.</param>
        /// <param name="cancellationToken">(Optional) the cancellation token.</param>
        /// <returns>
        /// A promise of a <see cref="IDataCommandResult"/>.
        /// </returns>
        public abstract Task<TResult> ExecuteAsync(TContext context, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Executes the data command asynchronously.
        /// </summary>
        /// <param name="operationContext">The operation context.</param>
        /// <param name="cancellationToken">(Optional) the cancellation token.</param>
        /// <returns>
        /// A promise of a <see cref="IDataCommandResult"/>.
        /// </returns>
        public async Task<IDataCommandResult> ExecuteAsync(IDataOperationContext operationContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await this.ExecuteAsync((TContext)operationContext, cancellationToken).PreserveThreadContext();
            return result;
        }
    }
}