namespace Heap;

using System;
using System.Collections.Generic;

public class Heap
{
    private List<int> list;

    public Heap() => list = new List<int>();

    private void Swap(int first, int second)
    {
        int temp = list[first];
        list[first] = list[second];
        list[second] = temp;
    }

    private int Parent(int index) => (index - 1) / 2;

    private int Left(int index) => index * 2 + 1;

    private int Right(int index) => index * 2 + 2;

    public void Insert(int value)
    {
        list.Add(value); // add last    
        Upheap(list.Count - 1);
    }

    private void Upheap(int index)
    {
        if (index == 0)
            return;

        int p = Parent(index);
        if (list[index] < list[p]) // if newly added ele is smaller then parent -> SWAP
        {
            Swap(index, p);
            Upheap(p);
        }
    }

    public int Remove()
    {
        if (list.Count == 0)
            throw new Exception("Removing from an empty heap!");

        int first = list[0]; // remove 1st

        // remove Last element
        int last = list[list.Count - 1]; 
        list.RemoveAt(list.Count - 1); 

        if (list.Count > 0)
        {
            list[0] = last; // set last element at start
            Downheap(0);
        }

        return first;
    }

    private void Downheap(int index)
    {
        int min = index;
        int left = Left(index);
        int right = Right(index);

        if (left < list.Count && list[min] > list[left])
            min = left;

        if (right < list.Count && list[min] > list[right])
            min = right;

        if (min != index)
        {
            Swap(min, index);
            Downheap(min);
        }
    }

    public List<int> HeapSort()
    {
        List<int> data = new List<int>();
        while (list.Count > 0)
            data.Add(Remove());
        return data;
    }
}

class Program
{
    static void Main()
    {
        Heap minHeap = new Heap();

        minHeap.Insert(5);
        minHeap.Insert(3);
        minHeap.Insert(8);
        minHeap.Insert(1);

        List<int> sortedData = minHeap.HeapSort();

        Console.WriteLine("Sorted Data: " + string.Join(", ", sortedData));
    }
}
