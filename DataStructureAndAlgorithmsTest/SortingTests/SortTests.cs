using DataStructuresAndAlgorithms.Sorting;
namespace DataStructureAndAlgorithmsTest.SortingTests;



public class SortUtilsTests
{
    public static IEnumerable<object[]> SortTestCases =>
    [
        [
            new BubbleSorter<int>(),
            new List<int> { },
            new List<int> { }
        ],
        [
            new InsertionSorter<int>(),
            new List<int> { },
            new List<int> { }
        ],
        [
            new BubbleSorter<int>(),
            new List<int> { 5, 3, 8, 1 },
            new List<int> { 1, 3, 5, 8 }
        ],
        [
            new InsertionSorter<int>(),
            new List<int> { 5, 3, 8, 1 },
            new List<int> { 1, 3, 5, 8 }
        ],
        [
            new BubbleSorter<double>(),
            new List<double> { 3.14, 2.71, 1.41 },
            new List<double> { 1.41, 2.71, 3.14 }
        ],
        [
            new InsertionSorter<long>(),
            new List<long> { 10000000000, 1, 9999999999 },
            new List<long> { 1, 9999999999, 10000000000 }
        ],
        [
            new BubbleSorter<int>(),
            new List<int> {2},
            new List<int> {2}
        ],
        [
            new InsertionSorter<int>(),
            new List<int> {2},
            new List<int> {2}
        ]

    ];

    [Theory]
    [MemberData(nameof(SortTestCases))]
    public void SorterSortsCorrectly<T>(ISorter<T> sorter,
                                        List<T> input,
                                        List<T> expected) where T : IComparable<T>
    {
        sorter.Sort(input);
        Assert.Equal(expected, input);
    }
}

public class IsSortedClassTests
{
    [Fact]
    public void IsSorted_EmptyArray_ReturnsTrue()
    {
        int[] input = [];
        Assert.True(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_SingleElementArray_ReturnsTrue()
    {
        int[] input = [42];
        Assert.True(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_SortedArray_ReturnsTrue()
    {
        int[] input = [1, 2, 3, 4, 5];
        Assert.True(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_UnsortedArray_ReturnsFalse()
    {
        int[] input = [5, 3, 4, 1, 2];
        Assert.False(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_DescendingArray_ReturnsFalse()
    {
        int[] input = [5, 4, 3, 2, 1];
        Assert.False(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_DuplicateElementsSorted_ReturnsTrue()
    {
        int[] input = [1, 2, 2, 3, 4];
        Assert.True(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_DuplicateElementsUnsorted_ReturnsFalse()
    {
        int[] input = [1, 3, 2, 2, 4];
        Assert.False(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_NegativeNumbersSorted_ReturnsTrue()
    {
        int[] input = [-5, -3, -1, 0, 2];
        Assert.True(IsSortedClass.IsSorted(input));
    }

    [Fact]
    public void IsSorted_NegativeNumbersUnsorted_ReturnsFalse()
    {
        int[] input = [-1, -3, -2, 0, 2];
        Assert.False(IsSortedClass.IsSorted(input));
    }
}
