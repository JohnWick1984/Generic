using System;
using System.Collections.Generic;

public class PriorityQueue<T, TPriority> where TPriority : IComparable<TPriority>
{
    private List<(T Item, TPriority Priority)> elements = new List<(T, TPriority)>();

    public int Count => elements.Count;

    public void Enqueue(T item, TPriority priority)
    {
        elements.Add((item, priority));
        elements.Sort((x, y) => x.Priority.CompareTo(y.Priority));
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T item = elements[0].Item;
        elements.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return elements[0].Item;
    }
}

class Program
{
    static void Main()
    {
        
        PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();

        priorityQueue.Enqueue("Task 1", 3);
        priorityQueue.Enqueue("Task 2", 1);
        priorityQueue.Enqueue("Task 3", 2);

        Console.WriteLine(priorityQueue.Dequeue());
        Console.WriteLine(priorityQueue.Dequeue()); 
        Console.WriteLine(priorityQueue.Dequeue()); 
    }
}
