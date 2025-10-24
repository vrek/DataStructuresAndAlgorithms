using DataStructuresAndAlgorithms.Statistics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

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
    [Fact]
    public void IsApproximatelyNormal_PerfectNormalDistribution_ReturnsTrue()
    {
        Normal normal = new(0, 1);
        double[] data = [.. normal.Samples().Take(1000)];
        bool result = Distrubution.IsApproximatelyNormal(data);
        Assert.True(result);

    }

    [Fact]
    public void IsApproximatelyNormal_UniformDistribution_ReturnsFalse()
    {
        double[] data = [1.0, 2.0, 3.0, 4.0, 5.0];
        bool result = Distrubution.IsApproximatelyNormal(data);
        Assert.False(result);
    }

    [Fact]
    public void IsApproximatelyNormal_SingleValue_ReturnsFalse()
    {
        double[] data = [42.0];
        bool result = Distrubution.IsApproximatelyNormal(data);
        Assert.False(result);
    }

    [Fact]
    public void IsApproximatelyNormal_EmptyInput_ThrowsException()
    {
        double[] data = [];
        Assert.Throws<ArgumentException>(() => Distrubution.IsApproximatelyNormal(data));
    }
    [Fact]
    public void AndersonDarling_NormalData_ReturnsLowStatistic()
    {
        double[] data = [-2.0, -1.0, 0.0, 1.0, 2.0];
        double result = Distrubution.AndersonDarlingNormalTest(data);
        Assert.True(result < 0.75);
    }

    [Fact]
    public void AndersonDarling_UniformData_ReturnsHighStatistic()
    {
        double[] data = [.. Enumerable.Range(1, 100).Select(i => (double)i)];
        double result =Distrubution.AndersonDarlingNormalTest(data);
        Assert.True(result > 1.0);
    }

    [Fact]
    public void AndersonDarling_SingleValue_ThrowsException()
    {
        double[] data = [42.0];
        Assert.Throws<ArgumentException>(() => Distrubution.AndersonDarlingNormalTest(data));
    }

    [Fact]
    public void AndersonDarling_EmptyInput_ThrowsException()
    {
        double[] data = [];
        Assert.Throws<ArgumentException>(() => Distrubution.AndersonDarlingNormalTest(data));
    }
}
