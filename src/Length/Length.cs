using System;

namespace OOBootCamp
{
    public class Length
    {
        private readonly decimal _quantity;
        private readonly LengthUnits _unit;

        public Length(decimal quantity, string unit)
        {
            _quantity = quantity;
            if (!LengthUnits.TryParse(unit, true, out _unit))
            {
                throw new InvalidOperationException($"Length unit {unit} not supported.");
            }
        }

        public override string ToString()
        {
            return $"{_quantity} {_unit}";
        }
    }
}