﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuntimeModelElementInfoProviderBase.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Base runtime provider for model element information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Model.Runtime.Factory
{
    using System.Reflection;

    using Kephas.Model.Runtime.Construction;

    /// <summary>
    /// Base runtime provider for model element information.
    /// </summary>
    /// <typeparam name="TElementInfo">The type of the element information.</typeparam>
    /// <typeparam name="TRuntimeInfo">The type of the runtime information.</typeparam>
    public abstract class RuntimeModelElementInfoFactoryBase<TElementInfo, TRuntimeInfo> : RuntimeNamedElementInfoFactoryBase<TElementInfo, TRuntimeInfo>
        where TElementInfo : RuntimeModelElementInfo<TRuntimeInfo>
        where TRuntimeInfo : MemberInfo
    {
    }
}