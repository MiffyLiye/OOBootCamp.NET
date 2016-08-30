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

        protected bool Equals(Length other)
        {
            return _quantity == other._quantity && _unit == other._unit;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Length) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_quantity.GetHashCode() * 397) ^ (int) _unit;
            }
        }

        public static bool operator ==(Length left, Length right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Length left, Length right)
        {
            return !(left == right);
        }
    }
}
