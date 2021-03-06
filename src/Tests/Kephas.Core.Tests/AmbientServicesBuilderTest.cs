﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AmbientServicesBuilderTest.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Test class for <see cref="AmbientServicesBuilder" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Kephas.Composition;
    using Kephas.Composition.Conventions;
    using Kephas.Composition.Hosting;
    using Kephas.Diagnostics.Logging;
    using Kephas.Services;

    using NUnit.Framework;

    using Telerik.JustMock;

    /// <summary>
    /// Test class for <see cref="AmbientServicesBuilder"/>.
    /// </summary>
    [TestFixture]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public class AmbientServicesBuilderTest
    {
        [Test]
        public void WithLogManager_success()
        {
            var ambientServices = new AmbientServices();
            var builder = new AmbientServicesBuilder(ambientServices);
            builder.WithLogManager(new DebugLogManager());

            Assert.IsTrue(ambientServices.LogManager is DebugLogManager);
        }

        [Test]
        public void WithCompositionContainer_builder()
        {
            var ambientServices = new AmbientServices();
            var builder = new AmbientServicesBuilder(ambientServices);
            builder.WithCompositionContainer<TestCompositionContainerBuilder>(b => b.WithAssembly(this.GetType().Assembly));

            Assert.IsFalse(ambientServices.CompositionContainer is NullCompositionContainer);
        }

        [Test]
        public void WithCompositionContainer_builder_missing_required_constructor()
        {
            var ambientServices = new AmbientServices();
            var builder = new AmbientServicesBuilder(ambientServices);
            Assert.Throws<MissingMethodException>(() => builder.WithCompositionContainer<BadTestCompositionContainerBuilder>());
        }

        [Test]
        public async Task WithCompositionContainerAsync_builder()
        {
            var ambientServices = new AmbientServices();
            var builder = new AmbientServicesBuilder(ambientServices);
            await builder.WithCompositionContainerAsync<TestCompositionContainerBuilder>(b => b.WithAssembly(this.GetType().Assembly));

            Assert.IsFalse(ambientServices.CompositionContainer is NullCompositionContainer);
        }

        [Test]
        public async Task WithCompositionContainerAsync_builder_missing_required_constructor()
        {
            var ambientServices = new AmbientServices();
            var builder = new AmbientServicesBuilder(ambientServices);
            Assert.That(() => builder.WithCompositionContainerAsync<BadTestCompositionContainerBuilder>(), Throws.TypeOf<MissingMethodException>());
        }

        public class TestCompositionContainerBuilder : CompositionContainerBuilderBase<TestCompositionContainerBuilder>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CompositionContainerBuilderBase{TBuilder}"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            public TestCompositionContainerBuilder(IContext context)
                : base(context)
            {
            }

            protected override IExportProvider CreateFactoryExportProvider<TContract>(Func<TContract> factory, bool isShared = false)
            {
                return Mock.Create<IExportProvider>();
            }

            protected override IExportProvider CreateServiceProviderExportProvider(IServiceProvider serviceProvider)
            {
                return Mock.Create<IExportProvider>();
            }

            protected override IConventionsBuilder CreateConventionsBuilder()
            {
                return Mock.Create<IConventionsBuilder>();
            }

            protected override ICompositionContext CreateContainerCore(IConventionsBuilder conventions, IEnumerable<Type> parts)
            {
                return Mock.Create<ICompositionContext>();
            }
        }

        /// <summary>
        /// Missing required constructor with parameter of type ICompositionContainerBuilderContext.
        /// </summary>
        public class BadTestCompositionContainerBuilder : CompositionContainerBuilderBase<BadTestCompositionContainerBuilder>
        {
            public BadTestCompositionContainerBuilder()
                : base(Mock.Create<IContext>())
            {
            }

            protected override IExportProvider CreateFactoryExportProvider<TContract>(Func<TContract> factory, bool isShared = false)
            {
                return Mock.Create<IExportProvider>();
            }

            protected override IExportProvider CreateServiceProviderExportProvider(IServiceProvider serviceProvider)
            {
                return Mock.Create<IExportProvider>();
            }

            protected override IConventionsBuilder CreateConventionsBuilder()
            {
                return Mock.Create<IConventionsBuilder>();
            }

            protected override ICompositionContext CreateContainerCore(IConventionsBuilder conventions, IEnumerable<Type> parts)
            {
                return Mock.Create<ICompositionContext>();
            }
        }
    }
}
