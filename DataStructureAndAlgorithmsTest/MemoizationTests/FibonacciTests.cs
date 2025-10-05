using DataStructuresAndAlgorithms.Memoization;

namespace DataStructureAndAlgorithmsTest.MemoizationTests;

public class FibonacciTests
{
    [Fact]
    public void Fibonacci_Zero_ReturnsZero()
    {
        int result = Fibonacci.Fib(0);
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(6, 8)]
    [InlineData(7, 13)]
    [InlineData(8, 21)]
    public void Fibonacci_ValidInput_ReturnsExpectedResult(int n, int expected)
    {
        int result = Fibonacci.Fib(n);
        Assert.Equal(expected, result);
    }

}
