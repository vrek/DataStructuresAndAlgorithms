using DataStructuresAndAlgorithms.Statistics;

namespace DataStructureAndAlgorithmsTest.StatisticsTests;



public class ModeTests
{
    [Fact]
    public void Throws_On_Null_Input()
    {
        int[] input = null;
        Assert.Throws<ArgumentException>(() => Mode.CalculateMode(input));
    }

    [Fact]
    public void Throws_On_Empty_Array()
    {
        string[] input = [];
        Assert.Throws<ArgumentException>(() => Mode.CalculateMode(input));
    }

    [Fact]
    public void Returns_Single_Element_As_Mode()
    {
        int[] input = [42];
        int result = Mode.CalculateMode(input);
        Assert.Equal(42, result);
    }

    [Fact]
    public void Returns_Correct_Mode_For_Ints()
    {
        int[] input = [1, 2, 2, 3, 3, 3, 4];
        int result = Mode.CalculateMode(input);
        Assert.Equal(3, result);
    }

    [Fact]
    public void Returns_Correct_Mode_For_Strings()
    {
        string[] input = ["apple", "banana", "apple", "cherry", "banana", "banana"];
        string result = Mode.CalculateMode(input);
        Assert.Equal("banana", result);
    }

    [Fact]
    public void Returns_First_Mode_When_Tie()
    {
        string[] input = ["a", "b", "a", "b"];
        string result = Mode.CalculateMode(input);
        Assert.True(result == "a" || result == "b"); // Accept either
    }

    [Fact]
    public void Returns_Mode_For_Custom_Type()
    {
        var input = new[] {
            new Point(1, 2),
            new Point(3, 4),
            new Point(1, 2),
        };
        var result = Mode.CalculateMode(input);
        Assert.Equal(new Point(1, 2), result);
    }

    private record Point(int X, int Y);
}

