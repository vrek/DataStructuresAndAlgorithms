namespace DataStructuresAndAlgorithms.Statistics;

public static class Mode
{
    public static T CalculateMode<T>(ReadOnlySpan<T> numbers)
    {
        if (numbers.Length == 0)
            throw new ArgumentException("Input array must not be empty.", nameof(numbers));
        Dictionary<T, int> frequencyMap = [];
        T mode = default!;
        int maxCount = 0;

        foreach (T number in numbers)
        {
            int count = frequencyMap.TryGetValue(number, out int value) ? ++value : 1;
            frequencyMap[number] = count;

            if (count > maxCount)
            {
                maxCount = count;
                mode = number;
            }
        }

        return mode;
    }

}
