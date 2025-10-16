using DataStructuresAndAlgorithms.Sorting;
namespace DataStructureAndAlgorithmsTest.SortingTests;



public class SortUtilsTests
{
    public static IEnumerable<object[]> SortTestCases =>
    new List<object[]>
    {
        new object[]
        {
            new BubbleSorter<int>(),
            new List<int> { },
            new List<int> { }
        },
        new object[]
        {
            new InsertionSorter<int>(),
            new List<int> { },
            new List<int> { }
        },
        new object[]
        {
            new BubbleSorter<int>(),
            new List<int> { 5, 3, 8, 1 },
            new List<int> { 1, 3, 5, 8 }
        },
        new object[]
        {
            new InsertionSorter<int>(),
            new List<int> { 5, 3, 8, 1 },
            new List<int> { 1, 3, 5, 8 }
        },
        new object[]
        {
            new BubbleSorter<double>(),
            new List<double> { 3.14, 2.71, 1.41 },
            new List<double> { 1.41, 2.71, 3.14 }
        },
        new object[]
        {
            new InsertionSorter<long>(),
            new List<long> { 10000000000, 1, 9999999999 },
            new List<long> { 1, 9999999999, 10000000000 }
        },
        new object[]
        {
            new BubbleSorter<int>(),
            new List<int> {2},
            new List<int> {2}
        },
        new object[]
        {
            new InsertionSorter<int>(),
            new List<int> {2},
            new List<int> {2}
        }

    };

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
