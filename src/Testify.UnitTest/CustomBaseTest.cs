using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Testify.UnitTest
{
    [TestFixture]
    public class CustomBaseTest : BaseTest
    {
        /// <summary>
        /// it is created by base class. Also can be created custom.
        /// </summary>
        protected override sealed IFixture FixtureCustom { get; set; }

        public CustomBaseTest()
        {
            FixtureCustom = new Fixture().Customize(new IgnoreVirtualMembersCustomisation());
        }
    }
}