using System;
using System.Collections.Generic;

namespace GFGCodesP.Core.SlidingWindow
{
    public class MaximumSumSubarray
    {
        public static void EntryPoint()
        {
            // int[] array = new int[] { -10, -7, -3, -1, 3, 5, 8, 13, 21, 32, 43, 50 };

            int[] array = new int[] { 2, 1, 5, 1, 3, 2 };


            PrintMaximumSumSubarray(array);
            Console.ReadLine();
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintMaximumSumSubarray(int[] array)
        {
            // brute force - n2 
            // n ??

            int maxSum = 0;
            int currentSum = 0;
            bool isPositiveNumberExists = false;
            int maxValue = int.MinValue;

            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] > 0)
                {
                    isPositiveNumberExists = true;
                }

                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }

                currentSum += array[i];

                if (currentSum <= 0)
                {
                    currentSum = 0;
                }
                else if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            if (!isPositiveNumberExists)
            {
                Console.WriteLine("Max Sum is: " + maxValue);
            }
            else
            {
                Console.WriteLine("Max Sum is: " + maxSum);
            }
        }
    }
}
