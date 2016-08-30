using System;

namespace OOBootCamp
{
    public class Length : IEquatable<Length>, IComparable<Length>, IComparable
    {
        private readonly decimal _quantity;
        private readonly LengthUnits _unit;

        public Length(decimal quantity, string unit)
        {
            _quantity = quantity;
            _unit = (LengthUnits) Enum.Parse(typeof(LengthUnits), unit, false);
        }

        public override string ToString()
        {
            return $"{_quantity} {_unit}";
        }

        public bool Equals(Length other)
        {
            return this.ToMeter() == other.ToMeter();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Length) obj);
        }

        public int CompareTo(Length other)
        {
            return ToMeter().CompareTo(other.ToMeter());
        }


        public int CompareTo(object obj)
        {
            return ToMeter().CompareTo(((Length) obj).ToMeter());
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ToMeter().GetHashCode();
            }
        }

        public static bool operator ==(Length left, Length right)
        {
            return !ReferenceEquals(left, null) && left.Equals(right);
        }

        public static bool operator !=(Length left, Length right)
        {
            return !(left == right);
        }

        public static bool operator <(Length left, Length right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator >(Length left, Length right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator <=(Length left, Length right)
        {
            return !(left > right);
        }

        public static bool operator >=(Length left, Length right)
        {
            return !(left < right);
        }

        private decimal ToMeter()
        {
            return _quantity * _unit.ToMeter();
        }
    }
}
