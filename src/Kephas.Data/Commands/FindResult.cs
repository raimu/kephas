﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FindResult.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Implements the find result class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Data.Commands
{
    using System;

    /// <summary>
    /// Encapsulates the result of a find.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    public class FindResult<T> : DataCommandResult, IFindResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FindResult{T}"/> class.
        /// </summary>
        /// <param name="entity">The found entity.</param>
        /// <param name="message">(Optional) The message.</param>
        /// <param name="exception">(Optional) the exception.</param>
        public FindResult(T entity, string message = null, Exception exception = null)
            : base(message, exception)
        {
            this.Entity = entity;
        }

        /// <summary>
        /// Gets the found entity or <c>null</c> if no entity could be found.
        /// </summary>
        /// <value>
        /// The found entity.
        /// </value>
        public T Entity { get; }
    }
}