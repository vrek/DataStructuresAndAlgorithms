using DataStructuresAndAlgorithms.Statistics;

namespace DataStructureAndAlgorithmsTest.StatisticsTests;

public class CalculateMedianTests
{
    [Fact]
    public void Throws_On_Null_Input()
    {
        int[] input = null!;
        Assert.Throws<ArgumentNullException>(() => Median.CalculateMedian(input));
    }

    [Fact]
    public void Throws_On_Empty_Collection()
    {
        double[] input = [];
        Assert.Throws<ArgumentException>(() => Median.CalculateMedian(input));
    }

    [Fact]
    public void Returns_Correct_Median_For_Sorted_Odd_Count()
    {
        List<int> input = [1, 3, 5];
        double result = Median.CalculateMedian(input);
        Assert.Equal(3, result);
    }

    [Fact]
    public void Returns_Correct_Median_For_Sorted_Even_Count()
    {
        List<int> input = [2, 4, 6, 8];
        double result = Median.CalculateMedian(input);
        Assert.Equal(5, result); // (4 + 6) / 2
    }

    [Fact]
    public void Returns_Correct_Median_For_Unsorted_Odd_Count()
    {
        int[] input = [9, 1, 5];
        double result = Median.CalculateMedian(input);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Returns_Correct_Median_For_Unsorted_Even_Count()
    {
        int[] input = [10, 2, 8, 4];
        double result = Median.CalculateMedian(input);
        Assert.Equal(6, result); // (4 + 8) / 2
    }

    [Fact]
    public void Returns_Correct_Median_For_Doubles()
    {
        double[] input = [1.5, 3.5, 2.5];
        double result = Median.CalculateMedian(input);
        Assert.Equal(2.5, result);
    }
}
