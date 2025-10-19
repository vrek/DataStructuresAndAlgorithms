using System.Numerics;

namespace DataStructuresAndAlgorithms.Statistics;

public class Mean
{
    public static double CalculateMean<T>(IEnumerable<T> source) where T : INumber<T>
    {
        ArgumentNullException.ThrowIfNull(source);

        List<T> list = [.. source];
        if (list.Count == 0)
            throw new ArgumentException("Input collection must not be empty.", nameof(source));

        T sum = T.Zero;
        foreach (var x in list)
            sum += x;

        return double.CreateChecked(sum) / list.Count;
    }

}
