using DataStructuresAndAlgorithms.LinkedLists;

namespace DataStructureAndAlgorithmsTest.LinkedListTests;

public class DoubleLinkedListTests
{
    [Fact]
    public void AddFirst_ShouldInsertAtHead()
    {
        DoubleLinkedList<int> list = new();
        list.AddFirst(10);
        list.AddFirst(20);
        Assert.Equal([20, 10], list.ToArray());
    }

    [Fact]
    public void AddLast_ShouldInsertAtTail()
    {
        DoubleLinkedList<int> list = new();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        Assert.Equal([1, 2, 3], list.ToArray());
    }

    [Fact]
    public void RemoveFirst_ShouldRemoveHead()
    {
        DoubleLinkedList<int> list = new();
        list.AddLast(5);
        list.AddLast(6);
        list.RemoveFirst();
        Assert.Equal(new[] { 6 }, list.ToArray());
    }

    [Fact]
    public void RemoveLast_ShouldRemoveTail()
    {
        DoubleLinkedList<int> list = new();
        list.AddLast(7);
        list.AddLast(8);
        list.RemoveLast();
        Assert.Equal(new[] { 7 }, list.ToArray());
    }

    [Fact]
    public void RemoveFirst_OnEmptyList_ShouldThrow()
    {
        DoubleLinkedList<int> list = new();
        Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
    }

    [Fact]
    public void RemoveLast_OnEmptyList_ShouldThrow()
    {
        DoubleLinkedList<int> list = new();
        Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
    }

    [Fact]
    public void Find_ShouldReturnCorrectNode()
    {
        DoubleLinkedList<string> list = new();
        list.AddLast("a");
        list.AddLast("b");
        list.AddLast("c");
        var node = list.FindByValue("b");
        Assert.NotNull(node);
        Assert.Equal("b", node.Value);
    }

    [Fact]
    public void ToArray_ShouldReturnAllElements()
    {
        DoubleLinkedList<char> list = new();
        list.AddLast('x');
        list.AddLast('y');
        list.AddLast('z');
        Assert.Equal(new[] { 'x', 'y', 'z' }, list.ToArray());
    }
}
