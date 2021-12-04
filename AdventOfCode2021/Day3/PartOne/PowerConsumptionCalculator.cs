using AdventOfCode2021.Day3.Shared;

namespace AdventOfCode2021.Day3.PartOne
{
    public class PowerConsumptionCalculator
    {
        public int Calculate(DiagnosticReport diagnosticReport)
        {
            GammaCalculator gammaCalculator = new();
            EpsilonCalculator epsilonCalculator = new();

            return gammaCalculator.Calculate(diagnosticReport) * epsilonCalculator.Calculate(diagnosticReport);
        }
    }
}