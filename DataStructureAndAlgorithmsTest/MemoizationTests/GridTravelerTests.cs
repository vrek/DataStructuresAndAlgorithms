using DataStructuresAndAlgorithms.Memoization;

namespace DataStructureAndAlgorithmsTest.MemoizationTests;

public class GridTravelerTests
{
    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(2, 3, 3)]
    [InlineData(3, 2, 3)]
    [InlineData(3, 3, 6)]
    [InlineData(18, 18, 2333606220)]
    public void GridTraveler_ValidInput_ReturnsExpectedResult(long m, long n, long expected)
    {
        long result = GridTraveler.Travel(m, n);
        Assert.Equal(expected, result);
    }

}
