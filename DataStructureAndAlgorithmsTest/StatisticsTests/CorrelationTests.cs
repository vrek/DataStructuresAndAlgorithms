using DataStructuresAndAlgorithms.Statistics;
namespace DataStructureAndAlgorithmsTest.StatisticsTests;



public class CorrelationTests
{
    [Fact]
    public void Correlation_IdenticalVectors_ReturnsOne()
    {
        int[] data = [1, 2, 3, 4, 5];
        double result = Correlation.CalculatePearsonCorrelation(data, data);
        Assert.Equal(1.0, result, precision: 10);
    }

    [Fact]
    public void Correlation_PerfectNegativeCorrelation_ReturnsMinusOne()
    {
        int[] x = [1, 2, 3, 4, 5];
        int[] y = [5, 4, 3, 2, 1];
        double result = Correlation.CalculatePearsonCorrelation(x, y);
        Assert.Equal(-1.0, result, precision: 10);
    }

    [Fact]
    public void Correlation_UncorrelatedVectors_ReturnsZero()
    {
        int[] x = [1, 2, 3, 4, 5];
        int[] y = [7, 6, 7, 6, 7]; 
        double result = Correlation.CalculatePearsonCorrelation(x, y);
        Assert.True(Math.Abs(result) < 1e-10);
    }

    [Fact]
    public void Correlation_EmptyInputs_ThrowsArgumentException()
    {
        int[] x = [];
        int[] y = [];
        Assert.Throws<ArgumentException>(() => Correlation.CalculatePearsonCorrelation(x, y));
    }

    [Fact]
    public void Correlation_MismatchedLengths_ThrowsArgumentException()
    {
        int[] x = [1, 2, 3];
        int[] y = [1, 2];
        Assert.Throws<ArgumentException>(() => Correlation.CalculatePearsonCorrelation(x, y));
    }

    [Fact]
    public void Correlation_ZeroVariance_ThrowsInvalidOperationException()
    {
        int[] x = [1, 1, 1, 1];
        int[] y = [2, 3, 4, 5];
        Assert.Throws<InvalidOperationException>(() => Correlation.CalculatePearsonCorrelation(x, y));
    }

    public static IEnumerable<object[]> CorrelationTestData =>
    [
        [new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 1.0],
        [new float[] { 1f, 2f, 3f }, new float[] { 3f, 2f, 1f }, -1.0],
        [new double[] { 1.0, 2.0, 3.0 }, new double[] { 1.0, 2.0, 3.0 }, 1.0],
        [new decimal[] { 1m, 2m, 3m }, new decimal[] { 3m, 2m, 1m }, -1.0],
    ];


    [Theory]
    [MemberData(nameof(CorrelationTestData))]
    public void Correlation_MixedNumericTypes_ReturnsExpected(object xRaw, object yRaw, double expected)
    {
        if (xRaw is int[] xi && yRaw is int[] yi)
            Assert.Equal(expected, Correlation.CalculatePearsonCorrelation(xi, yi), precision: 10);
        else if (xRaw is float[] xf && yRaw is float[] yf)
            Assert.Equal(expected, Correlation.CalculatePearsonCorrelation(xf, yf), precision: 10);
        else if (xRaw is double[] xd && xRaw is double[] yd)
            Assert.Equal(expected, Correlation.CalculatePearsonCorrelation(xd, yd), precision: 10);
        else if (xRaw is decimal[] xm && yRaw is decimal[] ym)
            Assert.Equal(expected, Correlation.CalculatePearsonCorrelation(xm, ym), precision: 10);
        else
            throw new InvalidOperationException("Unsupported test data type.");
    }

}

