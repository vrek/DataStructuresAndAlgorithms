namespace DataStructuresAndAlgorithms.LinkedLists;

public class SingleLinkedList<T>
{
    public class Node(T value)
    {
        public T Value = value;
        public Node? Next = null;
    }


    public Node? Head;

    public SingleLinkedList()
    {
        Head = null;
    }

    public void InsertAtStart(T value)
    {
        Node newNode = new(value)
        {
            Next = Head
        };
        Head = newNode;
    }

    public void InsertAtEnd(T value)
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

    public void InsertAtPosition(T value, int position)
    {
        Node newNode = new(value);
        if (position == 0)
        {
            newNode.Next = Head;
            Head = newNode;
            return;
        }
        if (position > GetLength() || position < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds.");
        }

        if (Head == null)
        {
            Head = newNode;
            return;
        }
        Node current = Head;
        for (int i = 0; i < position - 1; i++)
        {
            if (current.Next == null)
            {
                break;
            }
            current = current.Next;
        }
        newNode.Next = current.Next;
        current.Next = newNode;
    }

    public T[] ToArray()
    {
        List<T> values = [];
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

    public T GetValueAtPosition(int position)
    {
        if (position < 0 || position >= GetLength())
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds.");
        }
        Node current = Head;
        for (int i = 0; i < position; i++)
        {
            if (current.Next == null)
            {
                break;
            }
            current = current.Next;
        }
        return current.Value;
    }

    public void RemoveAtPosition(int position)
    {
        if (position < 0 || position >= GetLength())
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position is out of bounds.");
        }
        if (Head == null)
        {
            throw new ArgumentOutOfRangeException(nameof(position), "List is currently null");
        }
        if (position == 0)
        {
            Head = Head.Next;
            return;
        }
        Node current = Head;
        for (int i = 0; i < position - 1; i++)
        {
            if (current.Next != null)
            {
                current = current.Next;
            }
        }
        current.Next = current.Next.Next;
    }

    public Node? FindNodeByValue(T value)
    {
        if (Head == null)
        {
            return null;
        }
        Node current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return current;
            }
            if (current.Next == null)
            {
                break;
            }
            current = current.Next;
        }
        return null;
    }

    public List<Node> FindAllNodesByValue(T value)
    {
        if (Head == null)
        {
            return [];
        }
        Node current = Head;
        List<Node> nodes = [];
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))

            {
                nodes.Add(current);
            }
            if (current.Next == null)
            {
                break;
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
    public bool Contains(T value)
    {
        if (FindNodeByValue(value) != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsEmpty()
    {
        if (Head == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int IndexOf(T value)
    {
        if (Head == null)
        {
            return -1;
        }
        Node current = Head;
        int index = 0;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value))
            {
                return index;
            }
            if (current.Next == null)
            {
                break;
            }
            current = current.Next;
            index++;
        }
        return -1;
    }
}