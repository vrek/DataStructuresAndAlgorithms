using DataStructuresAndAlgorithms.Sorting;
using System.Numerics;

namespace DataStructuresAndAlgorithms.Statistics;

public class Median
{
    public static double CalculateMedian<T>(
        IEnumerable<T> source,
        ISorter<T>? sorter = null) where T : INumber<T>, IComparable<T>
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source), "Input collection must not be null.");

        List<T> list = [.. source];
        if (list.Count == 0)
            throw new ArgumentException("Input collection must not be empty.", nameof(source));

        if (!IsSortedClass.IsSorted(list))
        {
            sorter ??= new InsertionSorter<T>();
            sorter.Sort(list);
        }

        int mid = list.Count / 2;
        return list.Count % 2 == 1
            ? double.CreateChecked(list[mid])
            : (double.CreateChecked(list[mid - 1]) + double.CreateChecked(list[mid])) / 2.0;
    }

}
