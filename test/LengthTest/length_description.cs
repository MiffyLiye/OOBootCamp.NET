using Xunit;
using FluentAssertions;
using OOBootCamp;

namespace OOBootCampTest
{
    public class length_description{
        [Theory]
        [InlineData(1, "m", "1 m")]
        [InlineData(2, "m", "2 m")]
        [InlineData(1, "cm", "1 cm")]
        [InlineData(1, "mm", "1 mm")]
        public void should_get_length_description(decimal quantity, string unit, string description)
        {
            var length = new Length(quantity, unit);

            length.ToString().Should().Be(description);
        }
    }
}
