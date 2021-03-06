﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultDataBehaviorProvider.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Implements the default data behavior provider class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Data.Behaviors
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reflection;

    using Kephas.Composition;
    using Kephas.Data.Behaviors.Composition;
    using Kephas.Services;

    /// <summary>
    /// A default data behavior provider.
    /// </summary>
    [OverridePriority(Priority.Low)]
    public class DefaultDataBehaviorProvider : IDataBehaviorProvider
    {
        /// <summary>
        /// The data behavior factories.
        /// </summary>
        private readonly ICollection<IExportFactory<IDataBehavior, DataBehaviorMetadata>> dataBehaviorFactories;

        /// <summary>
        /// The behaviors cache.
        /// </summary>
        private readonly ConcurrentDictionary<Type, ConcurrentDictionary<Type, IEnumerable>> behaviorsCache =
            new ConcurrentDictionary<Type, ConcurrentDictionary<Type, IEnumerable>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultDataBehaviorProvider"/> class.
        /// </summary>
        /// <param name="dataBehaviorFactories">The data behavior factories.</param>
        public DefaultDataBehaviorProvider(ICollection<IExportFactory<IDataBehavior, DataBehaviorMetadata>> dataBehaviorFactories)
        {
            Contract.Requires(dataBehaviorFactories != null);

            this.dataBehaviorFactories = dataBehaviorFactories;
        }

        /// <summary>
        /// Gets the data behaviors of type <typeparamref name="TBehavior"/>
        ///  for the provided type.
        /// </summary>
        /// <typeparam name="TBehavior">Type of the behavior.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An enumeration of behaviors mathing the provided type.
        /// </returns>
        public IEnumerable<TBehavior> GetDataBehaviors<TBehavior>(Type type)
        {
            var typeBehaviors = this.behaviorsCache.GetOrAdd(type, _ => new ConcurrentDictionary<Type, IEnumerable>());
            var behaviors = typeBehaviors.GetOrAdd(typeof(TBehavior), _ => this.ComputeDataBehaviors<TBehavior>(type) as IEnumerable);
            return (IEnumerable<TBehavior>)behaviors;
        }

        /// <summary>
        /// Calculates the data behaviors.
        /// </summary>
        /// <typeparam name="TBehavior">Type of the behavior.</typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        /// An enumeration of behaviors of the specified type.
        /// </returns>
        private IEnumerable<TBehavior> ComputeDataBehaviors<TBehavior>(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            var behaviorTypeInfo = typeof(TBehavior).GetTypeInfo();
            var behaviors = (from f in this.dataBehaviorFactories
                                 let entityTypeInfo = f.Metadata.EntityType.GetTypeInfo()
                                 let serviceTypeInfo = f.Metadata.AppServiceImplementationType.GetTypeInfo()
                                 where
                                     typeInfo.IsAssignableFrom(entityTypeInfo)
                                     && behaviorTypeInfo.IsAssignableFrom(serviceTypeInfo)
                                 orderby f.Metadata.ProcessingPriority
                                 select f.CreateExport().Value)
                             .Cast<TBehavior>()
                             .ToList();
            return behaviors;
        }
    }
}