using System.Numerics;

namespace DataStructuresAndAlgorithms.Statistics;

public class Distrubution
{
    public static double CalculateVariance<T>(IEnumerable<T> source) where T : INumber<T>
    {
        ArgumentNullException.ThrowIfNull(source);

        List<T> data = [.. source];
        if (data.Count == 0)
            throw new ArgumentException("Input collection must not be empty.", nameof(source));

        double mean = Mean.CalculateMean(data);

        double varianceSum = 0.0;
        foreach (var x in data)
        {
            double diff = double.CreateChecked(x) - mean;
            varianceSum += diff * diff;
        }

        return varianceSum / data.Count;
    }


    public static double CalculateStandardDeviation<T>(IEnumerable<T> source) where T : INumber<T>
    {
        double variance = CalculateVariance(source);
        return Math.Sqrt(variance);
    }

    public static bool IsApproximatelyNormal(IList<double> data, double tolerance = 0.03)
    {
        if (data is null || data.Count == 0)
            throw new ArgumentException("Data must not be null or empty.");

        double mean = Mean.CalculateMean(data);
        double stdDev = CalculateStandardDeviation(data);

        int within1 = data.Count(x => Math.Abs(x - mean) <= stdDev);
        int within2 = data.Count(x => Math.Abs(x - mean) <= 2 * stdDev);
        int within3 = data.Count(x => Math.Abs(x - mean) <= 3 * stdDev);

        double p1 = (double)within1 / data.Count;
        double p2 = (double)within2 / data.Count;
        double p3 = (double)within3 / data.Count;

        return Math.Abs(p1 - 0.6827) <= tolerance &&
               Math.Abs(p2 - 0.9545) <= tolerance &&
               Math.Abs(p3 - 0.9973) <= tolerance;
    }

}
