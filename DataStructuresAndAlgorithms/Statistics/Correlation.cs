using System.Numerics;

namespace DataStructuresAndAlgorithms.Statistics;

public class Correlation
{
    public static double CalculatePearsonCorrelation<T>(
        IList<T> x, IList<T> y, double tolerance = 1e-10) where T : INumber<T>
    {
        ArgumentNullException.ThrowIfNull(x);
        ArgumentNullException.ThrowIfNull(y);

        if (x.Count != y.Count)
            throw new ArgumentException("Input collections must have the same length.");
        if (x.Count == 0)
            throw new ArgumentException("Input collections must not be empty.");

        if (x is T[] xArray && y is T[] yArray)
            return CalculatePearsonCorrelation(xArray.AsSpan(), yArray.AsSpan(), tolerance);
        else
            return CalculatePearsonCorrelation([.. x], [.. y], tolerance);
    }

    public static double CalculatePearsonCorrelation<T>(
        Span<T> x, Span<T> y, double tolerance = 1e-10) where T : INumber<T>
    {
        if (x.Length != y.Length)
            throw new ArgumentException("Input spans must have the same length.");
        if (x.Length == 0)
            throw new ArgumentException("Input spans must not be empty.");

        int n = x.Length;
        double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0, sumY2 = 0;

        for (int i = 0; i < n; i++)
        {
            double xi = double.CreateChecked(x[i]);
            double yi = double.CreateChecked(y[i]);

            sumX += xi;
            sumY += yi;
            sumXY += xi * yi;
            sumX2 += xi * xi;
            sumY2 += yi * yi;
        }

        double covXY = (n * sumXY) - (sumX * sumY);
        double stdX = (n * sumX2) - (sumX * sumX);
        double stdY = (n * sumY2) - (sumY * sumY);
        double denominator = Math.Sqrt(stdX * stdY);

        if (Math.Abs(denominator) < tolerance)
            throw new InvalidOperationException("Denominator in correlation calculation is too close to zero.");

        return covXY / denominator;
    }

}
