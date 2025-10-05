namespace DataStructuresAndAlgorithms.Hashmaps;

public class DuplicatesHashMap
{
    public static bool FindDuplicate(int[] nums)
    {
        HashSet<int> SeenNumbers = [];
        foreach (int num in nums)
        {
            if (SeenNumbers.Contains(num)) return true;
            SeenNumbers.Add(num);
        }
        return false;
    }
}
