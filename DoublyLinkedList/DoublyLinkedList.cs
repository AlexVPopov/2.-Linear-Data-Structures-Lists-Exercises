using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        var newNode = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.head = this.tail = newNode;
        }
        else
        {
            newNode.NextNode = this.head;
            this.head.PrevNode = newNode;
            this.head = newNode;
        }
        this.Count++;
    }

    public void AddLast(T element)
    {
        var newNode = new ListNode<T>(element);
        if (this.Count == 0)
        {
            this.head = this.tail = newNode;
        }
        else
        {
            this.tail.NextNode = newNode;
            newNode.PrevNode = this.tail;
            this.tail = newNode;
        }      
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0) { throw new InvalidOperationException("List is empty"); }

        var removedElement = this.head.Value;

        if (this.Count == 1) { this.head = this.tail = null; }
        else
        {
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }

        this.Count--;
        return removedElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0) { throw new InvalidOperationException("List is empty"); }

        var removedElement = this.tail.Value;

        if (this.Count == 1) { this.head = this.tail = null; }
        else
        {
            this.tail = this.tail.PrevNode;
            this.tail.NextNode = null;
        }

        this.Count--;
        return removedElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var currentNode = this.head;
        for (int i = 0; i < this.Count; i++)
        {
            array[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }
        return array;
    }

    private class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;

    private ListNode<T> tail;
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
