using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class KWayMerge
    {
        public static void EntryPoint()
        {
            List<List<int>> sortedArrays = new List<List<int>>()
            {
                new List<int>(){ 1, 21, 41, 61},
                new List<int>(){ 2, 3, 11, 16, 26},
                new List<int>(){ 31, 51, 56, 66, 71, 76, 96 },
                new List<int>(){ 6, 7, 12, 72, 74, 97, 101, 121},
                new List<int>(){ 43, 64, 73, 75, 85, 105, 106, 108}
            };

            var sortedArray = MergeKSortedArrays(sortedArrays);
            Console.WriteLine(string.Join(", ", sortedArray));
            Console.ReadLine();
        }

        public static int[] MergeKSortedArrays(List<List<int>> sortedArrays)
        {
            if (sortedArrays == null)
                return null;

            int size = 0;
            int k = sortedArrays.Count;
            var minHeap = new KMergeMinHeap<int>(k);

            for (int i =0; i<k; ++i)
            {
                size += sortedArrays[i].Count;
                minHeap.Add(new MinHeapKMergeType<int>(sortedArrays[i][0], i, 0));
            }

            int[] sortedMergedArray = new int[size];
            int sortedMergeIndex = 0;
            while (minHeap.Count > 0)
            {
                var min = minHeap.RemoveMin();
                sortedMergedArray[sortedMergeIndex++] = min.Data;

                if (min.DataAtIndex < sortedArrays[min.ArrayNumber].Count - 1)
                {
                    minHeap.Add(new MinHeapKMergeType<int>(sortedArrays[min.ArrayNumber][min.DataAtIndex + 1], min.ArrayNumber, min.DataAtIndex + 1));

                }
            }

            return sortedMergedArray;
        }
    }
}
