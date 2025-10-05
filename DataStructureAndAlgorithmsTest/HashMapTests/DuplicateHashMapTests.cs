using DataStructuresAndAlgorithms.Hashmaps;

namespace DataStructureAndAlgorithmsTest.HashMapTests;

public class DuplicatesHashMapPassingTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 1 }, true)]
    [InlineData(new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
    public void GivenValidIntegersFunctionShouldReturnATrue(int[] nums, bool expected)
    {
        bool result = DuplicatesHashMap.FindDuplicate(nums);
        Assert.Equal(expected, result);
    }

}

public class DuplicatesHashMapFailingTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, false)]
    [InlineData(new int[] { }, false)]
    [InlineData(new int[] { 0 }, false)]
    public void GivenInvalidIntegersFunctionShouldReturnFalse(int[] nums, bool expected)
    {
        bool result = DuplicatesHashMap.FindDuplicate(nums);
        Assert.Equal(expected, result);
    }

}
