using DataStructuresAndAlgorithms.Statistics;

namespace DataStructureAndAlgorithmsTest.StatisticsTests;

public class MeanTests
{
    const float Epsilon = 1e-6f;

    [Fact]
    public void CalculateMean_Ints_ReturnsExpected()
    {
        int[] numbers = [1, 2, 3, 4];
        double result = Mean.CalculateMean(numbers);
        Assert.InRange(result, 2.5f - Epsilon, 2.5f + Epsilon);
    }

    [Fact]
    public void CalculateMean_Doubles_ReturnsExpected()
    {
        double[] numbers = [1.5, 2.5];
        double result = Mean.CalculateMean(numbers);
        Assert.InRange(result, 2.0f - Epsilon, 2.0f + Epsilon);
    }

    [Fact]
    public void CalculateMean_Decimals_ReturnsExpected()
    {
        decimal[] numbers = [1.1m, 2.2m];
        double result = Mean.CalculateMean(numbers);
        Assert.InRange(result, 1.65f - Epsilon, 1.65f + Epsilon);
    }

    [Fact]
    public void CalculateMean_NullArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentNullException>(() => Mean.CalculateMean<int>(null!));
    }

    [Fact]
    public void CalculateMean_EmptyArray_ThrowsArgumentException()
    {
        int[] empty = [];
        Assert.Throws<ArgumentException>(() => Mean.CalculateMean(empty));
    }
}