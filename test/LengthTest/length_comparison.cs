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

        [Theory]
        [InlineData(1, "m", 100, "cm")]
        [InlineData(2, "m", 2000, "mm")]
        [InlineData(3, "cm", 30, "mm")]
        public void should_be_equal_when_two_lengths_have_same_quantity_when_converted_to_m(
            decimal leftQuantity,
            string leftUnit,
            decimal rightQuantity,
            string rightUnit)
        {
            var left = new Length(leftQuantity, leftUnit);
            var right = new Length(rightQuantity, rightUnit);

            (left.Equals(right)).Should().BeTrue();
            (left == right).Should().BeTrue();
            (left != right).Should().BeFalse();
        }

        [Theory]
        [InlineData(1, "m", 200, "cm")]
        [InlineData(2, "m", 3000, "mm")]
        [InlineData(3, "cm", 40, "mm")]
        public void should_be_inequal_when_two_lengths_have_different_quantity_when_converted_to_m(
            decimal leftQuantity,
            string leftUnit,
            decimal rightQuantity,
            string rightUnit)
        {
            var left = new Length(leftQuantity, leftUnit);
            var right = new Length(rightQuantity, rightUnit);

            (left.Equals(right)).Should().BeFalse();
            (left == right).Should().BeFalse();
            (left != right).Should().BeTrue();
        }
    }
}