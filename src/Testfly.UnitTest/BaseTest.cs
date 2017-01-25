using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Testfly.UnitTest
{
    [TestFixture]
    public class BaseTest : Testfly.BaseTest
    {
        /// <summary>
        /// it is created by base class. Also can be created custom.
        /// </summary>
        //protected new IFixture FixtureCustom { get; set; }

        public BaseTest()
        {
            FixtureCustom = new Fixture().Customize(new IgnoreVirtualMembersCustomisation());
        }
    }
}