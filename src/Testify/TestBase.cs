using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Testify
{
    [TestFixture]
    public abstract class BaseTest
    {
        private readonly MockRepository _mockRepository = new MockRepository(MockBehavior.Strict);

        private readonly IFixture _fixture = new Fixture();

        protected BaseTest()
        {
            
        }

        public Mock<T> CreateMock<T>() where T : class
        {
            return _mockRepository.Create<T>();
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
        public virtual void Setup()
        {

        }

        [TearDown]
        public virtual void End()
        {
            _mockRepository.VerifyAll();
        }
    }
}