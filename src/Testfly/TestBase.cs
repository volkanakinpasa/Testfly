using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Testfly
{
    [TestFixture]
    public abstract class BaseTest
    {
        /// <summary>
        /// it is created when test runs. Override this if you need to create your own custom fixture object
        /// </summary>
        protected virtual IFixture FixtureCustom { get { return _fixture; } set { _fixture = value; } }
        private IFixture _fixture;
        private MockRepository _mockRepositoryCustom;

        public Mock<T> CreateMock<T>() where T : class
        {
            return _mockRepositoryCustom.Create<T>();
        }

        protected T CreateFixture<T>()
        {
            return _fixture.Create<T>();
        }

        protected IEnumerable<T> CreateManyFixture<T>()
        {
            return _fixture.CreateMany<T>();
        }

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockRepositoryCustom = new MockRepository(MockBehavior.Strict);
        }

        [TearDown]
        public void End()
        {
            _mockRepositoryCustom.VerifyAll();
        }
    }
}