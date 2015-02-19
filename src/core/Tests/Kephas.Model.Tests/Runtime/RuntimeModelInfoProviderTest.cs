﻿namespace Kephas.Model.Tests.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Composition;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    using Kephas.Model.AttributedModel;
    using Kephas.Model.Elements.Construction;
    using Kephas.Model.Runtime;
    using Kephas.Model.Runtime.Factory;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;
    using Telerik.JustMock.Helpers;

    /// <summary>
    /// Tests for <see cref="RuntimeModelInfoProvider"/>.
    /// </summary>
    [TestClass]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public class RuntimeModelInfoProviderTest
    {
        [TestMethod]
        public void GetElementInfos()
        {
            var registrar = Mock.Create<IRuntimeModelRegistrar>();
            registrar.Arrange(r => r.GetRuntimeElements()).Returns(new object[] { typeof(string) });

            var stringInfoMock = Mock.Create<INamedElementInfo>();

            var factory = Mock.Create<IRuntimeElementInfoFactory>();
            factory.Arrange(f => f.TryGetElementInfo(Arg.Is(typeof(string).GetTypeInfo()))).Returns(stringInfoMock);

            var exportFactory = this.CreateElementinfoFactory(factory);

            var provider = new RuntimeModelInfoProvider(new[] { registrar }, new[] { exportFactory });

            var elementInfos = provider.GetElementInfos().ToList();

            Assert.AreEqual(1, elementInfos.Count);
            Assert.AreSame(stringInfoMock, elementInfos[0]);
        }

        private ExportFactory<IRuntimeElementInfoFactory, RuntimeElementInfoFactoryMetadata> CreateElementinfoFactory(
            IRuntimeElementInfoFactory factory)
        {
            var metadata =
                new RuntimeElementInfoFactoryMetadata(
                    new Dictionary<string, object>
                        {
                            {
                                RuntimeElementInfoFactoryMetadata.ElementInfoTypeKey,
                                typeof(IClassifierInfo)
                            },
                            {
                                RuntimeElementInfoFactoryMetadata.RuntimeInfoTypeKey,
                                typeof(TypeInfo)
                            }
                        });
            var exportFactory =
                new ExportFactory<IRuntimeElementInfoFactory, RuntimeElementInfoFactoryMetadata>(
                    () => Tuple.Create(factory, (Action)null),
                    metadata);
            return exportFactory;
        }
    }
}