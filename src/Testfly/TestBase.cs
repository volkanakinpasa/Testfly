using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Testfly
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IFixture FixtureCustom = new Fixture();

        private MockRepository _mockRepositoryCustom;

        public Mock<T> MockIt<T>() where T : class
        {
            return _mockRepositoryCustom.Create<T>();
        }

        protected T FixtureIt<T>()
        {
            return FixtureCustom.Create<T>();
        }

        protected T FixtureIt<T>(T seed)
        {
            return FixtureCustom.Create(seed);
        }

        protected IEnumerable<T> FixtureItMany<T>()
        {
            return FixtureCustom.CreateMany<T>();
        }

        protected IEnumerable<T> FixtureItMany<T>(T seed)
        {
            return FixtureCustom.CreateMany(seed);
        }

        protected IEnumerable<T> FixtureItMany<T>(T seed, int count)
        {
            return FixtureCustom.CreateMany(seed, count);
        }

        protected IEnumerable<int> FixtureItMany<T>(int seed, int count)
        {
            return FixtureCustom.CreateMany(seed, count);
        }

        [SetUp]
        public void Setup()
        {
            _mockRepositoryCustom = new MockRepository(MockBehavior.Strict);
        }

        [TearDown]
        public void End()
        {
            _mockRepositoryCustom.VerifyAll();
        }
    }
}