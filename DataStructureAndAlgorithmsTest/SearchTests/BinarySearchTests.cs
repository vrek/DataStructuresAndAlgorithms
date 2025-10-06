using DataStructuresAndAlgorithms.Search;

namespace DataStructureAndAlgorithmsTest.SearchTests;

public class BinarySearchTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 3, 1)]
    [InlineData(new int[] { 10, 20, 30, 40, 50 }, 30, 1)]
    [InlineData(new int[] { -5, -3, -1, 0, 1 }, -1, 1)]
    [InlineData(new int[] { 100, 200, 300, 400, 500 }, 100, 2)]
    [InlineData(new int[] { 7, 14, 21, 28, 35 }, 35, 3)]
    [InlineData(new int[] { 1, 3, 5, 7, 9, 11 }, 2, -1)]
    [InlineData(new[] { 5, 3, 9, 1, 7 }, 9, 3)]
    [InlineData(new int[] { }, 5, -1)]
    [InlineData(new int[] { 42 }, 42, 1)] 
    [InlineData(new int[] { 42 }, 99, -1)] 
    [InlineData(new int[] { 7, 7, 7, 7, 7 }, 7, 1)]
    [InlineData(new int[] { 7, 7, 7, 7, 7 }, 3, -1)] 
    [InlineData(new int[] { 9, 1, 3, 5, 7 }, 1, 2)] 
    [InlineData(new int[] { 9, 1, 3, 5, 7 }, 9, 3)] 
    [InlineData(new int[] { -10, -20, -30, -40 }, -30, 1)]
    [InlineData(new int[] { -10, 0, 5, -5, 10 }, 0, 1)]

    public void GivenValidIntegersFunctionShouldReturnAValidResponse(int[] nums, int target, int expected)
    {
        int result = BinarySearch.CountNumberOfSearchesToFindTarget(nums, target);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(Cases))]
    public void CountNumberOfSearches_ShouldReturnExpected(int[] nums, int target, int expected)
    {
        int result = BinarySearch.CountNumberOfSearchesToFindTarget(nums, target);
        Assert.Equal(expected, result);
    }

    public static TheoryData<int[], int, int> Cases => new()
    {
        { Enumerable.Range(1, 1000).ToArray(), 500, 1 },
        { Enumerable.Range(1, 1000).ToArray(), 1001, -1 }
    };



}

