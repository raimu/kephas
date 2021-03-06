﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGraphEdge.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Declares the IGraphEdge interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Graphs
{
    using Kephas.Dynamic;

    /// <summary>
    /// Defines the contract for a graph edge.
    /// </summary>
    public interface IGraphEdge : IExpando
    {
        /// <summary>
        /// Gets the node from which the edge starts.
        /// </summary>
        /// <value>
        /// The node from which the edge starts.
        /// </value>
        IGraphNode From { get; }

        /// <summary>
        /// Gets the node where the edge ends.
        /// </summary>
        /// <value>
        /// The node where the edge ends.
        /// </value>
        IGraphNode To { get; }
    }

    /// <summary>
    /// Defines the contract for a graph edge.
    /// </summary>
    /// <typeparam name="TNodeValue">Type of the node value.</typeparam>
    public interface IGraphEdge<TNodeValue> : IGraphEdge
    {
        /// <summary>
        /// Gets the node from which the edge starts.
        /// </summary>
        /// <value>
        /// The node from which the edge starts.
        /// </value>
        new IGraphNode<TNodeValue> From { get; }

        /// <summary>
        /// Gets the node where the edge ends.
        /// </summary>
        /// <value>
        /// The node where the edge ends.
        /// </value>
        new IGraphNode<TNodeValue> To { get; }
    }
}