namespace DataStructuresAndAlgorithms.Memoization;

public class CanSum
{
    public static bool CanSumFunc(int targetSum, int[] numbers, Dictionary<int, bool>? memo = null)
    {
        memo ??= [];
        if (targetSum == 0)
        {
            return true;
        }

        if (targetSum < 0)
        {
            return false;
        }

        if (memo.TryGetValue(targetSum, out bool value))
        {
            return value;
        }

        foreach (var _ in from int num in numbers
                          let remainder = targetSum - num
                          where CanSumFunc(remainder, numbers, memo)
                          select new { })
        {
            memo[targetSum] = true;
            return true;
        }

        memo[targetSum] = false;
        return false;
    }
}
