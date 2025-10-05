namespace DataStructuresAndAlgorithms.LinkedLists;

public class SingleLinkedList
{
    public class Node(int value)
    {
        public int Value = value;
        public Node? Next = null;
    }

    public Node? Head;

    public SingleLinkedList()
    {
        Head = null;
    }

    public void InsertAtStart(int value)
    {
        Node newNode = new(value)
        {
            Next = Head
        };
        Head = newNode;
    }

    public void InsertAtEnd(int value)
    {
        Node newNode = new(value);
        if (Head == null)
        {
            Head = newNode;
            return;
        }
        Node current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public void InsertAtPosition(int value, int position)
    {
        Node newNode = new(value);
        if (position == 0)
        {
            newNode.Next = Head;
            Head = newNode;
            return;
        }
        if (position > GetLength() || position < 0)
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds.");
        Node? current = Head;
        for (int i = 0; i < position - 1; i++)
        {
            current = current.Next;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    public int[] ToArray()
    {
        List<int> values = [];
        Node? current = Head;
        while (current != null)
        {
            values.Add(current.Value);
            current = current.Next;
        }
        return [.. values];
    }

    public int GetLength()
    {
        int length = 0;
        Node? current = Head;
        while (current != null)
        {
            length++;
            current = current.Next;
        }
        return length;
    }

    public int GetValueAtPosition(int position)
    {
        if (position < 0 || position >= GetLength())
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds.");
        Node? current = Head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }
        return current.Value;
    }

    public void RemoveAtPosition(int position)
    {
        if (position < 0 || position >= GetLength())
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds.");
        if (position == 0)
        {
            Head = Head.Next;
            return;
        }
        Node? current = Head;
        for (int i = 0; i < position - 1; i++)
        {
            current = current.Next;
        }
        current.Next = current.Next.Next;
    }

    public Node? FindNodeByValue(int v)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Value == v)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public List<Node> FindAllNodesByValue(int v)
    {
        Node current = Head;
        List<Node> nodes = [];
        while (current != null)
        {
            if (current.Value == v)
            {
                nodes.Add(current);
            }
            current = current.Next;
        }
        return nodes;
    }

    public void Reverse()
    {
        Node? prev = null;
        Node? current = Head;

        while (current != null)
        {
            Node? next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        Head = prev;
    }
}



