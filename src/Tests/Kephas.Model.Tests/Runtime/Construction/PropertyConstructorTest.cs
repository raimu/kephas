﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyConstructorTest.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   A runtime property information factory test.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Model.Tests.Runtime.Construction
{
    using Kephas.Model.Elements;
    using Kephas.Model.Runtime.Construction;
    using Kephas.Reflection;

    using NUnit.Framework;

    using Telerik.JustMock;
    using Telerik.JustMock.Helpers;

    /// <summary>
    /// A runtime property information factory test.
    /// </summary>
    [TestFixture]
    public class PropertyConstructorTest : ConstructorTestBase
    {
        private INamedElement TryCreateAgeModelElement(IModelSpace modelSpace = null)
        {
            var constructor = new PropertyConstructor();
            var context = this.GetConstructionContext(modelSpace);
            var propertyInfo = typeof(TestModelElement).AsRuntimeTypeInfo().Properties["Age"];
            var modelElement = constructor.TryCreateModelElement(context, propertyInfo);

            return modelElement;
        }

        [Test]
        public void TryCreateModelElement_ReturnType()
        {
            var modelElement = this.TryCreateAgeModelElement();

            Assert.IsNotNull(modelElement);
            Assert.IsInstanceOf<Property>(modelElement);
        }

        [Test]
        public void TryCreateModelElement_Name()
        {
            var modelElement = (IProperty)this.TryCreateAgeModelElement();

            Assert.AreEqual("Age", modelElement.Name);
        }

        [Test]
        public void TryCreateModelElement_CanRead()
        {
            var modelElement = (IProperty)this.TryCreateAgeModelElement();

            Assert.AreEqual(true, modelElement.CanRead);
        }

        [Test]
        public void TryCreateModelElement_CanWrite()
        {
            var modelElement = (IProperty)this.TryCreateAgeModelElement();

            Assert.AreEqual(true, modelElement.CanWrite);
        }

        public class TestModelElement
        {
            public int Age { get; set; }
        }
    }
}