using Xunit;
using FluentAssertions;

namespace OOBootCampTest
{
    public class Tests{
        [Fact]
        public void Test1(){
            true.Should().BeTrue();
        }
    }
}
