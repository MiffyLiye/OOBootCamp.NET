using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace OOBootCamp
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum LengthUnits
    {
        [ToMeter("1")] m,
        [ToMeter("0.01")] cm,
        [ToMeter("0.001")] mm
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ToMeter : Attribute
    {
        public ToMeter(string ratio)
        {
            Meter = decimal.Parse(ratio);
        }

        public decimal Meter { get; }
    }

    public static class LengthUnitsExtension
    {
        private static readonly ConcurrentDictionary<LengthUnits, decimal> Ratio =
            new ConcurrentDictionary<LengthUnits, decimal>();

        public static decimal ToMeter(this LengthUnits unit)
        {
            if (Ratio.ContainsKey(unit))
            {
                return Ratio[unit];
            }

            var attribute = unit.GetType().GetField(Enum.GetName(typeof(LengthUnits), unit)).GetCustomAttribute<ToMeter>();
            Ratio.GetOrAdd(unit, attribute.Meter);

            return attribute.Meter;
        }
    }
}
