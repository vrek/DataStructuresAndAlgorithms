namespace DataStructuresAndAlgorithms.Hashmaps;

public class GenericDuplicateHashMap
{
    public static bool FindDuplicate<T>(T[] items)
    {
        HashSet<T> SeenItems = [];
        foreach (T item in items)
        {
            if (SeenItems.Contains(item)) return true;
            SeenItems.Add(item);
        }
        return false;
    }
}
