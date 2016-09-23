using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OOBootCamp
{
    public class ParkingReport
    {
        private string Role { get; }
        private int OccupiedParkingSpacesCount { get; }
        private int Capacity { get; }
        private ReadOnlyCollection<ParkingReport> SubReports { get; }
        private string NewLine { get; } = Environment.NewLine;

        public ParkingReport(string role, int occupiedParkingSpacesCount, int capacity)
        {
            Role = role;
            OccupiedParkingSpacesCount = occupiedParkingSpacesCount;
            Capacity = capacity;
            SubReports = new ReadOnlyCollection<ParkingReport>(new List<ParkingReport>());
        }

        public ParkingReport(string role, IList<ParkingReport> subReports)
        {
            Role = role;
            SubReports = new ReadOnlyCollection<ParkingReport>(subReports);
            OccupiedParkingSpacesCount = SubReports.Sum(report => report.OccupiedParkingSpacesCount);
            Capacity = SubReports.Sum(report => report.Capacity);
        }

        public string ToString(string format)
        {
            if (format.Equals("markdown", StringComparison.OrdinalIgnoreCase))
            {
                return ToMarkdownString();
            }
            return ToString();
        }

        public override string ToString()
        {
            var summary = $"{Role} {OccupiedParkingSpacesCount} {Capacity}";
            return SubReports.Aggregate(summary,
                (current, subReport) => current + NewLine + AddPadding(subReport.ToString(), "  "));
        }

        private static string AddPadding(string text, string padding)
        {
            return string.Join("\n",
                text
                    .Split('\n')
                    .Select(line => padding + line));
        }

        private string ToMarkdownString()
        {
            var headingMark = Role == ParkingRoles.ParkingLot ? "*" : "#";
            var summary = $"{headingMark} {Role} {OccupiedParkingSpacesCount} {Capacity}";
            var orderedSubReports = SubReports
                .OrderBy(r => r.Role == ParkingRoles.ParkingLot ? 0 : 1);
            return orderedSubReports.Aggregate(summary,
                (current, subReport) => current + NewLine + AddMarkdownHeadingLevel(subReport.ToMarkdownString()));
        }

        private static string AddMarkdownHeadingLevel(string text)
        {
            return string.Join("\n",
                text
                    .Split('\n')
                    .Select(line => (line.StartsWith("#") ? "#" : "") + line));
        }
    }
}
