using AdventOfCode2021.Day3.Shared;

namespace AdventOfCode2021.Day3.PartTwo
{
    public class LifeSupportRatingCalculator
    {
        public int Calculate(DiagnosticReport diagnosticReport)
        {
            OxygenGeneratorRatingCalculator oxygenGeneratorRatingCalculator = new();
            Co2ScrubberRatingCalculator co2ScrubberRatingCalculator = new();

            return oxygenGeneratorRatingCalculator.Calculate(diagnosticReport) *
                   co2ScrubberRatingCalculator.Calculate(diagnosticReport);
        }
    }
}