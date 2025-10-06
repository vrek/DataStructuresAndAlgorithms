using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.LinkedLists;

public class DoubleLinkedList<T>
{
    public class Node(T value)
    {
        public T Value = value;
        public Node? Next = null;
        public Node? Prev = null;
    }


    public Node? Head;

    public DoubleLinkedList()
    {
        Head = null;
    }

    public void AddFirst(T value)
    {
        Node newNode = new(value);
        if (Head == null)
        {
            Head = newNode;
            return;
        }
        newNode.Next = Head;
        Head.Prev = newNode;
        Head = newNode;
    }

    public void AddLast(T value)
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
        newNode.Prev = current;
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

    public void RemoveFirst()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }
        Head = Head.Next;
        if (Head != null)
        {
            Head.Prev = null;
        }
    }

    public void RemoveLast()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }
        if (Head.Next == null)
        {
            Head = null;
            return;
        }
        Node current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Prev!.Next = null;
    }

    public Node FindByValue(string v)
    {
        if (Head == null)
        {
            throw new InvalidOperationException("List is empty.");
        }
        Node current = Head;
        while (current != null)
        {
            if (current.Value!.Equals(v))
            {
                return current;
            }
            current = current.Next;
        }
        return null!;
    }
}
