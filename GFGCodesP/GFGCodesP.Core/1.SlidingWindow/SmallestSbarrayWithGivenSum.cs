using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class SmallestSbarrayWithGivenSum
    {
        public static void EntryPoint()
        {
            // int[] array = new int[] { -10, -7, -3, -1, 3, 5, 8, 13, 21, 32, 43, 50 };

            int[] array = new int[] { 2, 3, 4, 1, 5 };

            PrintSmallestSbarrayWithGivenSumK(array, 20);
            Console.ReadLine();
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintSmallestSbarrayWithGivenSumK(int[] array, int k)
        {
            //  lets solve for all positive numbers
            int currSum = 0;
            int startIndex = 0;
            int minSubArrayLength = int.MaxValue;

            for (int endIndex = 0; endIndex < array.Length; ++endIndex)
            {
                currSum += array[endIndex];
                while (currSum >= k)
                {
                    minSubArrayLength = Math.Min(minSubArrayLength, endIndex - startIndex + 1);
                    currSum -= array[startIndex];
                    ++startIndex;

                }
            }

            Console.WriteLine(minSubArrayLength);
        }
    }
}

