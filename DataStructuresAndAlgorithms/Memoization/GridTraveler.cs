namespace DataStructuresAndAlgorithms.Memoization;

public class GridTraveler
{
    public long Travel(long m, long n, Dictionary<string, long>? memo = null)
    {
        if (m <= 0 || n <= 0) return 0;
        if (m == 1 && n == 1) return 1;
        memo ??= [];
        string key = $"{m},{n}";
        if (memo.TryGetValue(key, out long value)) return value;
        memo[key] = Travel(m - 1, n, memo) + Travel(m, n - 1, memo);
        return memo[key];
    }
}
