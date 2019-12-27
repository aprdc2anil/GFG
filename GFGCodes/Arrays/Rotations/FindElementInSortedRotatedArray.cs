using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GFGCodes
{
    public class FindElementInSortedRotatedArray
    {
        public static void EntryPoint()
        {
            int[] input = new int[] { 9, 10, 11, 12, 0, 1, 2, 3, 4, 5, 6, 7, 8, };
            Console.WriteLine(string.Join(" ", input));
            Console.WriteLine("binary search index: {0}", BinarySearch(input, 11, 0, input.Length-1));
            Console.WriteLine("rotation index: {0}", FindRotationIndex(input));
            Console.WriteLine("binary search index: {0}", FindElementInRotatedSorted(input, 11));
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


        public static int FindElementInRotatedSorted(int[] input, int element)
        {
            int rotationIndex = FindRotationIndex(input);

            if (rotationIndex == -1)
            {
                return BinarySearch(input, element, 0, input.Length-1);
            }

            int start = 0;
            int end = input.Length-1;

            if (element >= input[0] && element <= input[rotationIndex])
            {
                return BinarySearch(input, element, start, rotationIndex);
            }
            else
            {
                return BinarySearch(input, element, rotationIndex+1, end);
            }
        }


        public static int FindRotationIndex(int[] input)
        {
            int n = input.Length;
            int start = 0;
            int end = n - 1;
            int mid = 0;

            // assume it is sorted

            // if there is no rotation to the right
            if (input[end] > input[start])
                return -1;

            while (start >= 0 && end <= n-1 && start < end)
            {
                mid = (start + end) / 2;

                if (mid == start)
                {
                    return mid;
                }

                if (input[mid] > input[mid - 1] && input[mid] > input[mid + 1])
                {
                    return mid;
                }
                else if (input[mid] < input[mid - 1] && input[mid] < input[mid + 1])
                {
                    return mid - 1;
                }
                else if (input[mid] > input[end])
                {
                    start = mid + 1;
                }
                else {
                    end = mid - 1;
                }
            }

            return -1;
        }
    }
}
