namespace DataStructuresAndAlgorithms.Hashmaps;

public class TwoSumHashMap
{
    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> numDict = [];
        int index = 0;
        foreach (int num in nums)
        {
            int complement = target - num;
            if (numDict.TryGetValue(complement, out int value))
            {
                return [value, index];
            }

            numDict[num] = index;
            index++;
        }
        return [];
    }
}