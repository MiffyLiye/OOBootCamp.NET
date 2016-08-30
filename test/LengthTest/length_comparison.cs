using FluentAssertions;
using OOBootCamp;
using Xunit;

namespace OOBootCampTest
{
    public class length_comparison
    {
        [Fact]
        public void should_be_equal_when_two_lengths_have_same_unit_and_quantity()
        {
            var left = new Length(1, "m");
            var right = new Length(1, "m");

            (left.Equals(right)).Should().BeTrue();
            (left == right).Should().BeTrue();
            (left != right).Should().BeFalse();
        }

        [Fact]
        public void should_be_inequal_when_two_lengths_have_same_unit_but_different_quantity()
        {
            var left = new Length(10, "m");
            var right = new Length(1, "m");

            (left.Equals(right)).Should().BeFalse();
            (left == right).Should().BeFalse();
            (left != right).Should().BeTrue();
        }
    }
}