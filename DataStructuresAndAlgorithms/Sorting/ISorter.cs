namespace DataStructuresAndAlgorithms.Sorting;

public interface ISorter<T> where T : IComparable<T>
{
    void Sort(List<T> list);
}
