using Moq;
using NUnit.Framework;
using Testify.Client;

namespace Testify.UnitTest
{
    [TestFixture]
    public class ClientManagerTests : BaseTest
    {
        private readonly Mock<IClientDataLayer> _mock;
        private readonly IClientManager _clientManager;

        public ClientManagerTests()
        {
            _mock = CreateMock<IClientDataLayer>();
            _clientManager = new ClientManager(_mock.Object);
        }

        [Test]
        public void GetDataTest()
        {
            Profile profile = CreateFixture<Profile>();

            _mock.Setup(m => m.GetData(It.IsAny<int>())).Returns("result");

            var data = _clientManager.GetData(profile.Id);

            Assert.NotNull(data);
        }
    }

    public class Profile
    {
        public int Id { get; set; }
    }
}
