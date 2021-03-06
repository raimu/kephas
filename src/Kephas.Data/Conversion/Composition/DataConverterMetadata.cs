﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataConverterMetadata.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Implements the data converter metadata class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Data.Conversion.Composition
{
    using System;
    using System.Collections.Generic;
    using Kephas.Collections;
    using Kephas.Services;

    /// <summary>
    /// A metadata information for <see cref="IDataConverter"/>.
    /// </summary>
    public class DataConverterMetadata : AppServiceMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataConverterMetadata"/> class.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        public DataConverterMetadata(IDictionary<string, object> metadata)
            : base(metadata)
        {
            if (metadata == null)
            {
                return;
            }

            this.SourceType = (Type)metadata.TryGetValue(nameof(this.SourceType));
            this.TargetType = (Type)metadata.TryGetValue(nameof(this.TargetType));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataConverterMetadata"/>
        ///  class.
        /// </summary>
        /// <param name="sourceType">The type of the source.</param>
        /// <param name="targetType">The type of the target.</param>
        /// <param name="processingPriority">(Optional) the processing priority.</param>
        /// <param name="overridePriority">  The override priority.</param>
        /// <param name="optionalService">   <c>true</c> if the service is optional, <c>false</c> if not.</param>
        public DataConverterMetadata(Type sourceType, Type targetType, int processingPriority = 0, int overridePriority = 0, bool optionalService = false)
            : base(processingPriority, overridePriority, optionalService)
        {
            this.SourceType = sourceType;
            this.TargetType = targetType;
        }

        /// <summary>
        /// Gets the type of the source.
        /// </summary>
        /// <value>
        /// The type of the source.
        /// </value>
        public Type SourceType { get; }

        /// <summary>
        /// Gets the type of the target.
        /// </summary>
        /// <value>
        /// The type of the target.
        /// </value>
        public Type TargetType { get; }
    }
}