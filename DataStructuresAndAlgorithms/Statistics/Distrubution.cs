using DataStructuresAndAlgorithms.Sorting;
using MathNet.Numerics.Distributions;
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

    public static double AndersonDarlingNormalTest(IList<double> data, ISorter<double>? sorter = null)
    {
        if (data is null || data.Count <= 1)
            throw new ArgumentException("Data must not be null, empty, or a single value.");

        int n = data.Count;

        if (!IsSortedClass.IsSorted(data))
        {
            sorter ??= new InsertionSorter<double>();
            sorter.Sort(data as List<double> ?? [.. data]);
        }

        double mean = data.Average();
        double stdDev = CalculateStandardDeviation(data);

        double sum = 0.0;
        for (int i = 0; i < n; i++)
        {
            double zLower = (data[i] - mean) / stdDev;
            double zUpper = (data[n - 1 - i] - mean) / stdDev;

            double cdfLower = Normal.CDF(0.0, 1.0, zLower);
            double cdfUpper = Normal.CDF(0.0, 1.0, zUpper);

            sum += ((2 * i) + 1) * (Math.Log(cdfLower) + Math.Log(1 - cdfUpper));
        }

        double ad = -n - (sum / n);
        return ad;
    }
    public static bool IsApproximatelyBinomial(IList<int> data, double alpha = 0.05)
    {
        int n = data.Max(); 
        double mean = Mean.CalculateMean(data);
        double variance = CalculateVariance(data);
        double p = 1 - (variance / mean);
        int estimatedN = (int)Math.Round(mean / p);

        Dictionary<int, int> observed = data.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        Dictionary<int, double> expected = [];

        foreach (int k in observed.Keys)
        {
            double prob = Binomial.PMF(estimatedN, (int)p, k);
            expected[k] = prob * data.Count;
        }

        double chiSquared = observed.Sum(kvp =>
        {
            double e = expected[kvp.Key];
            return e > 0 ? Math.Pow(kvp.Value - e, 2) / e : 0;
        });

        int df = observed.Count - 2;
        double criticalValue = ChiSquared.InvCDF(df, 1 - alpha);

        return chiSquared < criticalValue;
    }

}
