using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Sorting;

public static class MergeSort
{
    public static void Sort<T>(Span<T> span) where T : IComparable<T>
    {
        if (span.Length <= 1) return;

        T[] buffer = new T[span.Length];
        Sort(span, buffer);
    }

    private static void Sort<T>(Span<T> span, T[] buffer) where T : IComparable<T>
    {
        if (span.Length <= 1) return;

        int mid = span.Length / 2;
        var left = span[..mid];
        var right = span[mid..];

        Sort(left, buffer);
        Sort(right, buffer);
        Merge(span, left, right, buffer);
    }

    private static void Merge<T>(Span<T> target, Span<T> left, Span<T> right, T[] buffer) where T : IComparable<T>
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i].CompareTo(right[j]) <= 0)
                buffer[k++] = left[i++];
            else
                buffer[k++] = right[j++];
        }

        while (i < left.Length)
            buffer[k++] = left[i++];

        while (j < right.Length)
            buffer[k++] = right[j++];

        for (int idx = 0; idx < target.Length; idx++)
            target[idx] = buffer[idx];
    }
}

