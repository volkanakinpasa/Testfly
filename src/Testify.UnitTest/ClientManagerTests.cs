using Moq;
using NUnit.Framework;
using Testify.Client;

namespace Testify.UnitTest
{
    [TestFixture]
    public class ClientManagerTests : CustomBaseTest
    {
        private Mock<IClientDataLayer> _mock;
        private IClientManager _clientManager;

        /// <summary>
        /// to call this setup each time before test method is called. it is called after base class's "Setup" method is called.
        /// </summary>
        [SetUp]
        public void Init()
        {
            _mock = CreateMock<IClientDataLayer>();
            _clientManager = new ClientManager(_mock.Object);
        }

        [Test]
        public void GetDataTest()
        {
            var profile = CreateFixture<Profile>();

            _mock.Setup(m => m.GetData(It.IsAny<int>())).Returns("result");

            var data = _clientManager.GetData(profile.Id);

            Assert.NotNull(data);
        }

        [Test]
        public void GetDataTest1()
        {
            var profile = CreateFixture<Profile>();

            _mock.Setup(m => m.GetData(It.IsAny<int>())).Returns("result");

            var data = _clientManager.GetData(profile.Id);

            Assert.NotNull(data);
        }
    }
}
