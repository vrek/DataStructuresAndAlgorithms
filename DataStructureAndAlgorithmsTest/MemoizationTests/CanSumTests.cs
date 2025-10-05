namespace DataStructureAndAlgorithmsTest.MemoizationTests;

public class CanSumTests
{
    [Theory]
    [InlineData(7, new int[] { 2, 3 }, true)]
    [InlineData(7, new int[] { 5, 3, 4, 7 }, true)]
    [InlineData(7, new int[] { 2, 4 }, false)]
    [InlineData(8, new int[] { 2, 3, 5 }, true)]
    [InlineData(300, new int[] { 7, 14 }, false)]
    [InlineData(0, new int[] { 1, 2, 3 }, true)]
    [InlineData(1, new int[] { }, false)]
    public void CanSumFunc_ShouldReturnExpectedResult(int targetSum, int[] numbers, bool expected)
    {
        // Act
        bool result = DataStructuresAndAlgorithms.Memoization.CanSum.CanSumFunc(targetSum, numbers);
        // Assert
        Assert.Equal(expected, result);
    }
}
