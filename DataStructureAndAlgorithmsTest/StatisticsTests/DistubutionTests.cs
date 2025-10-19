using DataStructuresAndAlgorithms.Statistics;

namespace DataStructureAndAlgorithmsTest.StatisticsTests;

public class DistrubutionTests
{
    [Fact]
    public void CalculateVariance_EmptyCollection_ThrowsArgumentException()
    {
        int[] input = [];
        Assert.Throws<ArgumentException>(() => Distrubution.CalculateVariance(input));
    }

    [Fact]
    public void CalculateStandardDeviation_EmptyCollection_ThrowsArgumentException()
    {
        int[] input = [];
        Assert.Throws<ArgumentException>(() => Distrubution.CalculateStandardDeviation(input));
    }

    [Fact]
    public void CalculateVariance_SingleElement_ReturnsZero()
    {
        int[] input = [42];
        double result = Distrubution.CalculateVariance(input);
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void CalculateStandardDeviation_SingleElement_ReturnsZero()
    {
        int[] input = [42];
        double result = Distrubution.CalculateStandardDeviation(input);
        Assert.Equal(0.0, result);
    }

    [Fact]
    public void CalculateVariance_KnownDataset_ReturnsExpected()
    {
        int[] input = [2, 4, 4, 4, 5, 5, 7, 9];
        double result = Distrubution.CalculateVariance(input);
        Assert.Equal(4.0, result, precision: 5);
    }

    [Fact]
    public void CalculateStandardDeviation_KnownDataset_ReturnsExpected()
    {
        int[] input = [2, 4, 4, 4, 5, 5, 7, 9];
        double result = Distrubution.CalculateStandardDeviation(input);
        Assert.Equal(2.0, result, precision: 5);
    }

    [Fact]
    public void CalculateVariance_NegativeNumbers_ReturnsCorrectValue()
    {
        int[] input = [-3, -1, -2, -4];
        double result = Distrubution.CalculateVariance(input);
        Assert.Equal(1.25, result, precision: 5);
    }

    [Fact]
    public void CalculateStandardDeviation_NegativeNumbers_ReturnsCorrectValue()
    {
        int[] input = [-3, -1, -2, -4];
        double result = Distrubution.CalculateStandardDeviation(input);
        Assert.Equal(Math.Sqrt(1.25), result, precision: 5);
    }
}
