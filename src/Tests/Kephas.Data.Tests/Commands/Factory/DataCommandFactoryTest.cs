﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCommandFactoryTest.cs" company="Quartz Software SRL">
//   Copyright (c) Quartz Software SRL. All rights reserved.
// </copyright>
// <summary>
//   Defines the DataCommandFactoryTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Kephas.Data.Tests.Commands.Factory
{
    using System;
    using System.Collections.Generic;

    using Kephas.Composition;
    using Kephas.Data.Commands;
    using Kephas.Data.Commands.Composition;
    using Kephas.Data.Commands.Factory;
    using Kephas.Testing.Core.Composition;

    using NUnit.Framework;

    using Telerik.JustMock;

    [TestFixture]
    public class DataCommandFactoryTest
    {
        [Test]
        public void CreateCommand_success()
        {
            var cmd = Mock.Create<IDataCommand>();
            var factory = new DataCommandFactory<IDataCommand>(new List<IExportFactory<IDataCommand, DataCommandMetadata>>
                                                                   {
                                                                       new TestExportFactory<IDataCommand, DataCommandMetadata>(() => cmd, new DataCommandMetadata(typeof(string)))
                                                                   });

            var actualCmd = factory.CreateCommand(typeof(string));
            Assert.AreSame(cmd, actualCmd);
        }

        [Test]
        public void CreateCommand_respects_override_priority()
        {
            var cmd = Mock.Create<IDataCommand>();
            var betterCmd = Mock.Create<IDataCommand>();
            var factory = new DataCommandFactory<IDataCommand>(new List<IExportFactory<IDataCommand, DataCommandMetadata>>
                                                                   {
                                                                       new TestExportFactory<IDataCommand, DataCommandMetadata>(() => cmd, new DataCommandMetadata(typeof(string))),
                                                                       new TestExportFactory<IDataCommand, DataCommandMetadata>(() => betterCmd, new DataCommandMetadata(typeof(string), overridePriority: -100))
                                                                   });

            var actualCmd = factory.CreateCommand(typeof(string));
            Assert.AreSame(betterCmd, actualCmd);
        }

        [Test]
        public void CreateCommand_NotSupported()
        {
            var cmd = Mock.Create<IDataCommand>();
            var factory = new DataCommandFactory<IDataCommand>(new List<IExportFactory<IDataCommand, DataCommandMetadata>>
                                                                   {
                                                                       new TestExportFactory<IDataCommand, DataCommandMetadata>(() => cmd, new DataCommandMetadata(typeof(string)))
                                                                   });

            Assert.Throws<NotSupportedException>(() => factory.CreateCommand(typeof(int)));
        }

        [Test]
        public void CreateCommand_NotSupported_no_exported_commands()
        {
            var factory = new DataCommandFactory<IDataCommand>(new List<IExportFactory<IDataCommand, DataCommandMetadata>>());
            Assert.Throws<NotSupportedException>(() => factory.CreateCommand(typeof(int)));
        }
    }
}