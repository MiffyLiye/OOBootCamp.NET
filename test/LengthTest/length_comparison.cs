using FluentAssertions;
using OOBootCamp;
using Xunit;

namespace OOBootCampTest
{
    public class length_comparison
    {
        [Theory]
        [InlineData(1, "m", 1, "m")]
        [InlineData(1, "cm", 1, "cm")]
        [InlineData(1, "mm", 1, "mm")]
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
            (left.CompareTo(right)).Should().Be(0);
            (left != right).Should().BeFalse();
            (left <= right).Should().BeTrue();
            (left >= right).Should().BeTrue();
        }

        [Theory]
        [InlineData(1, "m", 10, "m")]
        [InlineData(1, "cm", 10, "cm")]
        [InlineData(1, "mm", 10, "mm")]
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

        [Theory]
        [InlineData(1, "m", 2, "m")]
        [InlineData(1, "m", 200, "cm")]
        [InlineData(2, "m", 3000, "mm")]
        [InlineData(3, "cm", 40, "mm")]
        public void
            should_be_the_shorter_when_one_length_has_smaller_quantity_than_the_other_length_after_converted_to_m(
                decimal leftQuantity,
                string leftUnit,
                decimal rightQuantity,
                string rightUnit)
        {
            var left = new Length(leftQuantity, leftUnit);
            var right = new Length(rightQuantity, rightUnit);

            (left.CompareTo(right)).Should().Be(-1);
            (right.CompareTo(left)).Should().Be(1);
            (left < right).Should().BeTrue();
            (left <= right).Should().BeTrue();
            (left > right).Should().BeFalse();
            (left >= right).Should().BeFalse();
        }
    }
}