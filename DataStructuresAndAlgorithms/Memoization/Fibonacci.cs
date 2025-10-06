namespace DataStructuresAndAlgorithms.Memoization;

public class Fibonacci
{
    public static int Fib(int n, Dictionary<int, int>? memo = null)
    {
        if (n <= 0)
        {
            return 0;
        }

        if (n <= 2)
        {
            return 1;
        }

        memo ??= [];
        if (memo.TryGetValue(n, out int value))
        {
            return value;
        }

        memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
        return memo[n];
    }
}
