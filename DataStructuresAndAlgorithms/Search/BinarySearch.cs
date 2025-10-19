using DataStructuresAndAlgorithms.Sorting;

namespace DataStructuresAndAlgorithms.Search;

public class BinarySearch
{
    public static int CountNumberOfSearchesToFindTarget(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        int count = 1;
        int[] SortedNums = [.. nums.OrderBy(n => n)];

        while (left <= right)
        {
            int mid = left + ((right - left) / 2);
            if (SortedNums[mid] == target)
            {
                return count;
            }

            if (SortedNums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }

            count++;
        }

        return -1;
    }
    public static int BinarySearchInSortedArray(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            int mid = left + ((right - left) / 2);
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
    public static int BinarySearchInUnsortedArray(int[] nums, int target)
    {
        ISorter<int> sorter = new InsertionSorter<int>();
        List<int> numList = [.. nums];
        sorter.Sort(numList);
        int[] sortedNums = [.. numList];
        return BinarySearchInSortedArray(sortedNums, target);

    }
}
