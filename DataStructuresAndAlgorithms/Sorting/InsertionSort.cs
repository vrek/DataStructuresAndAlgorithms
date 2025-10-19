namespace DataStructuresAndAlgorithms.Sorting;

public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
{
    public void Sort(List<T> list)
    {
        ArgumentNullException.ThrowIfNull(list);

        for (int i = 1; i < list.Count; i++)
        {
            var key = list[i];
            int j = i - 1;

            while (j >= 0 && list[j].CompareTo(key) > 0)
            {
                list[j + 1] = list[j];
                j--;
            }

            list[j + 1] = key;
        }
    }
}

