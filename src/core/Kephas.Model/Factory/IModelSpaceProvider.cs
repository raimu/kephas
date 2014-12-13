﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModelSpaceProvider.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Contract for providing a model space.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Model.Factory
{
    using Kephas.Services;

    /// <summary>
    /// Contract for providing a model space.
    /// </summary>
    [SharedAppServiceContract]
    public interface IModelSpaceProvider
    {
        /// <summary>
        /// Gets the model space.
        /// </summary>
        /// <returns>The model space.</returns>
        IModelSpace GetModelSpace();
    }
}