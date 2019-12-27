using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GFGCodes
{
    public class SortedIncreasingDecreasingArray
    {
        public static void EntryPoint()
        {
            int[] input = new int[] { 5, 7, 9, 11, 13, 12, 10, 8};
            Console.WriteLine(string.Join(" ", input));
            Console.WriteLine("binary search index: {0}", BinarySearch(input, 11, 0, input.Length-1));
            Console.WriteLine("rotation index: {0}", FindCriticalIndex(input));
            Console.WriteLine("binary search index: {0}", FindElementInSortedIncreasingDecreasingArray(input, 8));
            Console.ReadLine();
        }

        public static int BinarySearch(int[] input, int element, int start, int end)
        {
            if (input[end] < input[start])
                return -1;

            int mid = 0; 
            while(start<=end)
            {
                mid = (start + end) / 2;

                if (input[mid] == element)
                {
                    return mid;
                }
                else if (input[mid] > element)
                {
                    end = mid-1;
                }
                else
                {
                    start = mid+1;
                }
            }

            return -1;
        }

        public static int BinarySearchDecreasing(int[] input, int element, int start, int end)
        {
            if (input[end] > input[start])
                return -1;

            int mid = 0;
            while (start <= end)
            {
                mid = (start + end) / 2;

                if (input[mid] == element)
                {
                    return mid;
                }
                else if (input[mid] > element)
                {
                    start = mid + 1;                    
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        public static int FindElementInSortedIncreasingDecreasingArray(int[] input, int element)
        {
            int criticalIndex = FindCriticalIndex(input);

            if (criticalIndex == -1 || input[criticalIndex] == element)
            {
                return criticalIndex;
            }

            int start = 0;
            int end = input.Length-1;            

            if (element >= input[0] && element <= input[criticalIndex])
            {
                return BinarySearch(input, element, start, criticalIndex);
            }
            else
            {
                return BinarySearch(input, element, criticalIndex+1, end);
            }
        }


        public static int FindCriticalIndex(int[] input)
        {
            int n = input.Length;
            int start = 0;
            int end = n - 1;
            int mid = 0;
            
            while (start >= 0 && end <= n-1 && start <= end)
            {
                mid = (start + end) / 2;

                if (mid == start)
                {
                    return mid;
                }

                if (input[mid] > input[mid - 1])
                {
                    if(input[mid] > input[mid + 1])
                    {
                        return mid;
                    }
                    else
                    {
                        start = mid + 1;
                    }                    
                }               
                else 
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
    }
}
