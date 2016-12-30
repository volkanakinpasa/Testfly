#Testfly
###### Faster way to mock the objects, to verify them, to create poco objects

####**Nuget**
      Install-Package Testfly
      
####**How to use it**
###### inherit Testfly.BaseTest in your class
    [TestFixture]
    public class TestClass : Testfly.BaseTest
    {
    }
###### if you need to create custom fixture
    [TestFixture]
    public class TestClass : Testfly.BaseTest
    {
        protected override sealed IFixture FixtureCustom { get; set; }

        public TestClass()
        {
            FixtureCustom = new Fixture().Customize(new customisationByUser());
        }
    }    
###### example
    [TestFixture]
    public class TestClass : Testfly.BaseTest
    {
        private Mock<IClientDataLayer> _mock;
        private IClientManager _clientManager;
    }
    
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
