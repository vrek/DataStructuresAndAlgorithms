namespace DataStructuresAndAlgorithms.Sorting;

public static class IsSortedClass
{
    public static bool IsSorted<T>(IEnumerable<T> source) where T : IComparable<T>
    {
        using var enumerator = source.GetEnumerator();
        if (!enumerator.MoveNext()) return true;

        T prev = enumerator.Current;
        while (enumerator.MoveNext())
        {
            if (prev.CompareTo(enumerator.Current) > 0)
                return false;
            prev = enumerator.Current;
        }
        return true;
    }
}
