﻿using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Testfly.Client;

namespace Testfly.UnitTest
{
    [TestFixture]
    public class ClientManagerTests : BaseTest
    {
        private Mock<IClientDataLayer> _mock;
        private IClientManager _clientManager;

        /// <summary>
        /// to call this setup each time before test method is called. it is called after base class's "Setup" method is called.
        /// </summary>
        [SetUp]
        public void Init()
        {
            FixtureCustom.Behaviors.Add(new OmitOnRecursionBehavior());
            _mock = MockIt<IClientDataLayer>();
            _clientManager = new ClientManager(_mock.Object);
        }

        [Test]
        public void GetDataTest()
        {
            var profile = FixtureIt<Profile>();

            _mock.Setup(m => m.GetData(It.IsAny<int>())).Returns("result");

            var data = _clientManager.GetData(profile.Id);

            Assert.NotNull(data);
        }

        [Test]
        public void GetDataTest1()
        {
            var profile = FixtureIt<Profile>();

            _mock.Setup(m => m.GetData(It.IsAny<int>())).Returns("result");

            var data = _clientManager.GetData(profile.Id);

            Assert.NotNull(data);
        }
    }
}
