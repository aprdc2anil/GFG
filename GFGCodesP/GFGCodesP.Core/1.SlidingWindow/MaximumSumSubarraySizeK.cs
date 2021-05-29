using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class MaximumSumSubarraySizeK
    {
        public static void EntryPoint()
        {
            // int[] array = new int[] { -10, -7, -3, -1, 3, 5, 8, 13, 21, 32, 43, 50 };

            int[] array = new int[] { 2, 3, 4, 1, 5 };

            PrintMaximumSumSubarraySizeK(array, 2);
            Console.ReadLine();
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintMaximumSumSubarraySizeK(int[] array, int k)
        {
            int maxSum = 0;
            int currentSum = 0;

            if (k > array.Length)
                return;

            for (int i = 0; i < k; ++i)
            {
                currentSum += array[i];
            }

            maxSum = currentSum;

            for (int i = k; i < array.Length; ++i)
            {
                currentSum = currentSum + array[i] - array[i - k];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            Console.WriteLine("max sum is : " + maxSum);
        }
    }
}
