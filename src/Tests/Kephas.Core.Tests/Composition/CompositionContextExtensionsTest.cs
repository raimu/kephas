﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositionContextExtensionsTest.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Implements the composition context extensions test class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Core.Tests.Composition
{
    using System.Collections.Generic;
    using System.Linq;

    using Kephas.Composition;
    using Kephas.Composition.ExportFactoryImporters;
    using Kephas.Testing.Core.Composition;

    using NUnit.Framework;

    using Telerik.JustMock;
    using Telerik.JustMock.Helpers;

    [TestFixture]
    public class CompositionContextExtensionsTest
    {
        [Test]
        public void GetExportFactory_generic_1_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(IExportFactoryImporter<string>), Arg.AnyString)).Returns(this.CreateExportFactoryImporter("exported test"));

            var result = context.GetExportFactory<string>();
            Assert.AreEqual("exported test", result.CreateExport().Value);
        }

        [Test]
        public void GetExportFactory_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(IExportFactoryImporter<string>), Arg.AnyString)).Returns(this.CreateExportFactoryImporter("exported test"));

            var result = (IExportFactory<string>)context.GetExportFactory(typeof(string));
            Assert.AreEqual("exported test", result.CreateExport().Value);
        }

        [Test]
        public void GetExportFactory_generic_2_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(IExportFactoryImporter<string, string>), Arg.AnyString)).Returns(this.CreateExportFactoryImporter("exported test", "metadata"));

            var result = context.GetExportFactory<string, string>();
            Assert.AreEqual("exported test", result.CreateExport().Value);
            Assert.AreEqual("metadata", result.CreateExport().Metadata);
        }

        [Test]
        public void GetExportFactory_metadata_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(IExportFactoryImporter<string, string>), Arg.AnyString)).Returns(this.CreateExportFactoryImporter("exported test", "metadata"));

            var result = (IExportFactory<string, string>)context.GetExportFactory(typeof(string), typeof(string));
            Assert.AreEqual("exported test", result.CreateExport().Value);
            Assert.AreEqual("metadata", result.CreateExport().Metadata);
        }

        [Test]
        public void GetExportFactories_generic_1_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(ICollectionExportFactoryImporter<string>), Arg.AnyString)).Returns(this.CreateExportFactoriesImporter("exported test"));

            var result = context.GetExportFactories<string>();
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("exported test", result.First().CreateExport().Value);
        }

        [Test]
        public void GetExportFactories_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(ICollectionExportFactoryImporter<string>), Arg.AnyString)).Returns(this.CreateExportFactoriesImporter("exported test"));

            var result = (IEnumerable<IExportFactory<string>>)context.GetExportFactories(typeof(string));
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("exported test", result.First().CreateExport().Value);
        }

        [Test]
        public void GetExportFactories_generic_2_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(ICollectionExportFactoryImporter<string, string>), Arg.AnyString)).Returns(this.CreateExportFactoriesImporter("exported test", "metadata"));

            var result = context.GetExportFactories<string, string>();
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("exported test", result.First().CreateExport().Value);
            Assert.AreEqual("metadata", result.First().CreateExport().Metadata);
        }

        [Test]
        public void GetExportFactories_metadata_success()
        {
            var context = Mock.Create<ICompositionContext>();
            context.Arrange(c => c.GetExport(typeof(ICollectionExportFactoryImporter<string, string>), Arg.AnyString)).Returns(this.CreateExportFactoriesImporter("exported test", "metadata"));

            var result = (IEnumerable<IExportFactory<string, string>>)context.GetExportFactories(typeof(string), typeof(string));
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("exported test", result.First().CreateExport().Value);
            Assert.AreEqual("metadata", result.First().CreateExport().Metadata);
        }

        private IExportFactoryImporter<T> CreateExportFactoryImporter<T>(T value)
        {
            return new ExportFactoryImporter<T>(new TestExportFactory<T>(() => value));
        }

        private IExportFactoryImporter<T, TMetadata> CreateExportFactoryImporter<T, TMetadata>(T value, TMetadata metadata)
        {
            return new ExportFactoryImporter<T, TMetadata>(new TestExportFactory<T, TMetadata>(() => value, metadata));
        }

        private ICollectionExportFactoryImporter<T> CreateExportFactoriesImporter<T>(T value)
        {
            return new CollectionExportFactoryImporter<T>(new[] { new TestExportFactory<T>(() => value) });
        }

        private ICollectionExportFactoryImporter<T, TMetadata> CreateExportFactoriesImporter<T, TMetadata>(T value, TMetadata metadata)
        {
            return new CollectionExportFactoryImporter<T, TMetadata>(new[] { new TestExportFactory<T, TMetadata>(() => value, metadata) });
        }
    }
}