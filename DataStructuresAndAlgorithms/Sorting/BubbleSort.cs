namespace DataStructuresAndAlgorithms.Sorting;

using System;
using System.Collections.Generic;

public class BubbleSorter<T> : ISorter<T> where T : IComparable<T>
{
    public void Sort(List<T> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        foreach (var item in list)
        {
            if (!IsNumeric(item))
                throw new ArgumentException($"Non-numeric value detected: {item}");
        }

        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j].CompareTo(list[j + 1]) > 0)
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                }
            }

        }
    }

    private static bool IsNumeric(T value) =>
        value is
            byte or sbyte
            or short or ushort
            or int or uint
            or long or ulong
            or float or double or decimal;
}
