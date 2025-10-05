using DataStructuresAndAlgorithms.LinkedLists;

namespace DataStructureAndAlgorithmsTest.LinkedListTests;

public class RemoveAtPositionTests
{
    [Fact]
    public void RemoveAtPosition_ShouldRemoveNodeAtGivenPosition()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(1);
        list.InsertAtStart(2);
        list.InsertAtStart(3); // Final list: 3 → 2 → 1

        list.RemoveAtPosition(1); // Remove node at position 1 (value 2)


        Assert.Equal(3, list.GetValueAtPosition(0));
        Assert.Equal(1, list.GetValueAtPosition(1));
        Assert.Equal(2, list.GetLength());
    }
    [Fact]
    public void RemoveAtPosition_InvalidPosition_ShouldThrowArgumentOutOfRangeException()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(1);
        list.InsertAtStart(2);
        list.InsertAtStart(3);
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAtPosition(-1)); 
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAtPosition(3));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAtPosition(100));
    }
}

public class GetValueAtPositionTests
{
    public class InvalidPositionTestData
    {
        public static TheoryData<int> Cases =>
    [
        -1,
        3,
        100
    ];
    }


    public static class ValidPositionTestData
    {
        public static TheoryData<int, int> Cases => new()
        {
            { 0, 1 },
            { 1, 2 },
            { 2, 3 },
        };
    }



    [Theory]
    [MemberData(nameof(ValidPositionTestData.Cases), MemberType = typeof(ValidPositionTestData))]
    public void GetValueAtPosition_ShouldReturnCorrectValue(int position, int expectedValue)
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(1);
        list.InsertAtEnd(2);
        list.InsertAtEnd(3);

        int actualValue = list.GetValueAtPosition(position);
        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [MemberData(nameof(InvalidPositionTestData.Cases), MemberType = typeof(InvalidPositionTestData))]
    public void GetValueAt_InvalidPosition_ShouldThrowArgumentOutOfRangeException(int invalidPosition)
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(3);
        list.InsertAtStart(2);
        list.InsertAtStart(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetValueAtPosition(invalidPosition));
    }

    [Fact]
    public void GetValueAtPosition_EmptyList_ShouldThrowArgumentOutOfRangeException()
    {
        SingleLinkedList<int> list = new();
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetValueAtPosition(0));
    }
}

public class InsertAtStartTests
{
    [Fact]
    public void InsertAtStart_ShouldInsertNodesAtHeadInReverseOrder()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(1);
        list.InsertAtStart(2);
        list.InsertAtStart(3);

        Assert.NotNull(list.Head);
        Assert.Equal(3, list.Head.Value);

        Assert.NotNull(list.Head.Next);
        Assert.Equal(2, list.Head.Next.Value);

        Assert.NotNull(list.Head.Next.Next);
        Assert.Equal(1, list.Head.Next.Next.Value);

        Assert.Null(list.Head.Next.Next.Next);
    }


    [Fact]
    public void InsertAtStart_ShouldAddNodesToHead()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(3);
        list.InsertAtStart(2);
        list.InsertAtStart(1);

        Assert.Equal([1, 2, 3], list.ToArray());
    }

    [Fact]
    public void InsertAtStart_EmptyList_ShouldCreateSingleNode()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(42);

        Assert.Equal(1, list.GetLength());
        Assert.Equal([42], list.ToArray());
    }

    [Fact]
    public void InsertAtStart_ShouldHandleNegativeAndZeroValues()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(-1);
        list.InsertAtStart(0);
        list.InsertAtStart(-99);

        Assert.Equal(3, list.GetLength());
        Assert.Equal([-99, 0, -1], list.ToArray());
    }

    [Fact]
    public void InsertAtStart_ManyInsertions_ShouldMaintainOrder()
    {
        SingleLinkedList<int> list = new();
        for (int i = 100; i >= 1; i--)
        {
            list.InsertAtStart(i);
        }

        Assert.Equal(100, list.GetLength());
        Assert.Equal([.. Enumerable.Range(1, 100)], list.ToArray());
    }

    [Fact]
    public void InsertAtStart_ThenInsertAtPosition_ShouldPreserveStructure()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(3);
        list.InsertAtStart(2);
        list.InsertAtStart(1);

        list.InsertAtPosition(99, 1);

        Assert.Equal(4, list.GetLength());
        Assert.Equal([1, 99, 2, 3], list.ToArray());
    }

    [Fact]
    public void InsertAtStart_Duplicates_ShouldBeHandledCorrectly()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(5);
        list.InsertAtStart(5);
        list.InsertAtStart(5);

        Assert.Equal(3, list.GetLength());
        Assert.Equal([5, 5, 5], list.ToArray());
    }

    [Theory]
    [MemberData(nameof(LinkedListLengthTestData.Cases), MemberType = typeof(LinkedListLengthTestData))]
    public void GivenVariousInputs_InsertAtStartShouldBuildCorrectLength(int[] values, int expectedLength)
    {
        SingleLinkedList<int> list = new();

        foreach (int value in values)
        {
            list.InsertAtStart(value);
        }

        int actualLength = list.GetLength();
        Assert.Equal(expectedLength, actualLength);
    }
}

public class InsertAtPositionTests
{
    [Fact]
    public void InsertAtPosition_Zero_ShouldInsertAtHead()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(2);
        list.InsertAtStart(1);

        list.InsertAtPosition(99, 0);

        Assert.Equal(3, list.GetLength());
        Assert.Equal([99, 1, 2], list.ToArray());
    }

    [Fact]
    public void InsertAtPosition_Middle_ShouldInsertCorrectly()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(3);
        list.InsertAtStart(2);
        list.InsertAtStart(1);

        list.InsertAtPosition(99, 1);

        Assert.Equal(4, list.GetLength());
        Assert.Equal([1, 99, 2, 3], list.ToArray());
    }

    [Fact]
    public void InsertAtPosition_End_ShouldAppend()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(2);
        list.InsertAtStart(1);

        list.InsertAtPosition(99, 2);

        Assert.Equal(3, list.GetLength());
        Assert.Equal([1, 2, 99], list.ToArray());
    }

    [Fact]
    public void InsertAtPosition_InvalidNegative_ShouldThrow()
    {
        SingleLinkedList<int> list = new();
        Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAtPosition(99, -1));
    }

    [Fact]
    public void InsertAtPosition_TooFar_ShouldThrow()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAtPosition(99, 5));
    }

    [Fact]
    public void InsertAtPosition_EmptyListZero_ShouldWork()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtPosition(99, 0);

        Assert.Equal(1, list.GetLength());
        Assert.Equal([99], list.ToArray());
    }

    [Fact]
    public void InsertAtEveryValidPosition_ShouldMaintainCorrectOrder()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(50);
        list.InsertAtStart(40);
        list.InsertAtStart(30);
        list.InsertAtStart(20);
        list.InsertAtStart(10);


        for (int position = 0; position <= list.GetLength(); position++)
        {
            SingleLinkedList<int> testList = CloneList(list);
            testList.InsertAtPosition(99, position);

            int[] expected = BuildExpectedArrayWithInsert([10, 20, 30, 40, 50], 99, position);
            Assert.Equal(expected, testList.ToArray());
        }
    }
    private static SingleLinkedList<int> CloneList(SingleLinkedList<int> original)
    {
        SingleLinkedList<int> clone = new();
        int[] values = original.ToArray();
        for (int i = values.Length - 1; i >= 0; i--)
        {
            clone.InsertAtStart(values[i]);
        }

        return clone;
    }

    private static int[] BuildExpectedArrayWithInsert(int[] original, int valueToInsert, int position)
    {
        List<int> result = [.. original];
        result.Insert(position, valueToInsert);
        return [.. result];
    }
}

public class ToArrayTests
{
    [Fact]
    public void ToArrayReturnsCorrectArray()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(3);
        list.InsertAtStart(2);
        list.InsertAtStart(1);
        int[] array = list.ToArray();
        Assert.Equal([1, 2, 3], array);
    }
}

public class InsertAtEndTests
{
    [Fact]
    public void InsertAtEnd_SingleValue_ShouldCreateSingleNode()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(42);

        Assert.Equal(1, list.GetLength());
        Assert.Equal([42], list.ToArray());
    }

    [Fact]
    public void InsertAtEnd_MultipleValues_ShouldAppendInOrder()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(1);
        list.InsertAtEnd(2);
        list.InsertAtEnd(3);

        Assert.Equal(3, list.GetLength());
        Assert.Equal([1, 2, 3], list.ToArray());
    }

    [Fact]
    public void InsertAtEnd_AfterInsertAtStart_ShouldAppendCorrectly()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtStart(2);
        list.InsertAtStart(1);

        list.InsertAtEnd(3);

        Assert.Equal(3, list.GetLength());
        Assert.Equal([1, 2, 3], list.ToArray());
    }

    [Fact]
    public void InsertAtEnd_DuplicateValues_ShouldBeHandledCorrectly()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(5);
        list.InsertAtEnd(5);
        list.InsertAtEnd(5);

        Assert.Equal(3, list.GetLength());
        Assert.Equal([5, 5, 5], list.ToArray());
    }

    [Fact]
    public void InsertAtEnd_StressTest_ShouldMaintainOrder()
    {
        SingleLinkedList<int> list = new();
        for (int i = 1; i <= 100; i++)
        {
            list.InsertAtEnd(i);
        }

        Assert.Equal(100, list.GetLength());
        Assert.Equal([.. Enumerable.Range(1, 100)], list.ToArray());
    }
}

public class FindNodeWithValueTests
{
    [Fact]
    public void FindNodeByValue_ReturnsCorrectNode_WhenValueExists()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(10);
        list.InsertAtEnd(20);
        list.InsertAtEnd(30);

        var result = list.FindNodeByValue(20);

        Assert.NotNull(result);
        Assert.Equal(20, result.Value);
    }

    [Fact]
    public void FindNodeByValue_ReturnsNull_WhenValueDoesNotExist()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(10);
        list.InsertAtEnd(20);

        var result = list.FindNodeByValue(99);

        Assert.Null(result);
    }

    [Fact]
    public void FindNodeByValue_ReturnsFirstMatch_WhenDuplicatesExist()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(5);
        list.InsertAtEnd(10);
        list.InsertAtEnd(10);
        list.InsertAtEnd(15);

        var result = list.FindNodeByValue(10);

        Assert.NotNull(result);
        Assert.Equal(10, result.Value);
        Assert.Equal(10, result.Next!.Value);
    }

}

public class FindAllNodesWithValueTests
{
    [Fact]
    public void FindAllNodesByValue_ReturnsEmptyList_WhenListIsEmpty()
    {
        SingleLinkedList<int>? list = new();
        var result = list.FindAllNodesByValue(10);

        Assert.Empty(result);
    }

    [Fact]
    public void FindAllNodesByValue_ReturnsSingleMatch_WhenValueExistsOnce()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(5);
        list.InsertAtEnd(10);
        list.InsertAtEnd(15);

        var result = list.FindAllNodesByValue(10);

        Assert.Single(result);
        Assert.Equal(10, result[0].Value);
    }

    [Fact]
    public void FindAllNodesByValue_ReturnsMultipleMatches_WhenValueExistsMultipleTimes()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(10);
        list.InsertAtEnd(20);
        list.InsertAtEnd(10);
        list.InsertAtEnd(30);
        list.InsertAtEnd(10);

        var result = list.FindAllNodesByValue(10);

        Assert.Equal(3, result.Count);
        Assert.All(result, node => Assert.Equal(10, node.Value));
    }

    [Fact]
    public void FindAllNodesByValue_ReturnsEmptyList_WhenValueNotFound()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(1);
        list.InsertAtEnd(2);
        list.InsertAtEnd(3);

        var result = list.FindAllNodesByValue(99);

        Assert.Empty(result);
    }

}
public class ReverseLinkedListTests
{
    [Fact]
    public void Reverse_EmptyList_RemainsEmpty()
    {
        SingleLinkedList<int> list = new();
        list.Reverse();

        Assert.Equal(0, list.GetLength());
        Assert.Null(list.Head);
    }

    [Fact]
    public void Reverse_SingleNodeList_RemainsUnchanged()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(42);
        list.Reverse();

        Assert.Equal(1, list.GetLength());
        Assert.Equal(42, list.Head!.Value!);
        Assert.Null(list.Head.Next);
    }

    [Fact]
    public void Reverse_MultipleNodes_ReversesOrder()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(1);
        list.InsertAtEnd(2);
        list.InsertAtEnd(3);

        list.Reverse();

        int[] values = list.ToArray();
        Assert.Equal([3, 2, 1], values);
    }

    [Fact]
    public void Reverse_Twice_RestoresOriginalOrder()
    {
        SingleLinkedList<int> list = new();
        list.InsertAtEnd(10);
        list.InsertAtEnd(20);
        list.InsertAtEnd(30);

        list.Reverse();
        list.Reverse();

        int[] values = list.ToArray();
        Assert.Equal([10, 20, 30], values);
    }

}
public static class LinkedListLengthTestData
{
    public static TheoryData<int[], int> Cases => new()
{
    { Array.Empty<int>(), 0 },
    { p1, 1 },
    { p1Array, 3 },
    { Enumerable.Range(1, 10).ToArray(), 10 },
    { Enumerable.Range(1, 100).ToArray(), 100 }
};

    private static readonly int[] p1 = [42];
    private static readonly int[] p1Array = [1, 2, 3];
}

public class TraversalAndInspectionTests
{
    private static SingleLinkedList<int> CreateList(params int[] values)
    {
        SingleLinkedList<int> list = new();
        foreach (int v in values)
        {
            list.InsertAtEnd(v);
        }

        return list;
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrue_WhenListIsEmpty()
    {
        SingleLinkedList<int> list = new();
        Assert.True(list.IsEmpty());
    }

    [Fact]
    public void IsEmpty_ShouldReturnFalse_WhenListHasElements()
    {
        var list = CreateList(42);
        Assert.False(list.IsEmpty());
    }

    [Theory]
    [InlineData(5, new[] { 1, 2, 3, 4, 5 }, true)]
    [InlineData(0, new[] { 1, 2, 3 }, false)]
    public void Contains_ShouldReturnCorrectResult(int value, int[] values, bool expected)
    {
        var list = CreateList(values);
        Assert.Equal(expected, list.Contains(value));
    }

    [Theory]
    [InlineData(30, new[] { 10, 20, 30, 40 }, 2)]
    [InlineData(99, new[] { 1, 2, 3 }, -1)]
    public void IndexOf_ShouldReturnCorrectIndex(int value, int[] values, int expected)
    {
        var list = CreateList(values);
        Assert.Equal(expected, list.IndexOf(value));
    }

    [Fact]
    public void ToArray_ShouldReturnCorrectSequence()
    {
        var list = CreateList(1, 2, 3);
        Assert.Equal([1, 2, 3], list.ToArray());
    }

    [Fact]
    public void ToArray_ShouldReturnEmptyArray_WhenListIsEmpty()
    {
        SingleLinkedList<int> list = new();
        Assert.Empty(list.ToArray());
    }
}
