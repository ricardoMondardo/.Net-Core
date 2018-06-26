using WebApi.Services;
using Xunit;

namespace WebApi.UnitTest
{
    public class TestableServiceTest
    {
        [Fact]
        public void TestSay()
        {
            var ctor = new TestableService();

            var result = ctor.SayHi();

            Assert.Equal(result, "Hi I am obj: " + ctor.GetHashCode());
        }
    }
}
