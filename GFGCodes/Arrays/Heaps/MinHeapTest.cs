using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class MinHeapTest
    {
        public static void EntryPoint()
        {
            MinHeap minHeap = new MinHeap();
            minHeap.Add(13);
            minHeap.Add(18);
            minHeap.Add(17);
            minHeap.Add(11);
            minHeap.Add(3);
            minHeap.Add(8);
            minHeap.Add(1);
            minHeap.Add(9);
        
           

            int min = minHeap.GetMin();
            Console.WriteLine(min);

            min = minHeap.RemoveMin();
            Console.WriteLine(min);

            min = minHeap.GetMin();
            Console.WriteLine(min);

            min = minHeap.RemoveMin();
            Console.WriteLine(min);

            min = minHeap.GetMin();
            Console.WriteLine(min);

            minHeap.Add(10);
            minHeap.Add(2);
            minHeap.Add(14);
            minHeap.Add(23);
            minHeap.Add(19);

            min = minHeap.RemoveMin();
            Console.WriteLine(min);

            min = minHeap.GetMin();
            Console.WriteLine(min);

            min = minHeap.RemoveMin();
            Console.WriteLine(min);

            min = minHeap.GetMin();
            Console.WriteLine(min);

            minHeap.Add(4);
            minHeap.Add(15);
            minHeap.Add(5);

            min = minHeap.RemoveMin();
            Console.WriteLine(min);

            min = minHeap.GetMin();
            Console.WriteLine(min);

            min = minHeap.RemoveMin();
            Console.WriteLine(min);

            min = minHeap.GetMin();
            Console.WriteLine(min);

            Console.WriteLine(string.Join(", ", minHeap.ToArray()));
            Console.ReadLine();
        }
    }
}
