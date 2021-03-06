﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes
{
    class MaxContinuousSubArraySum
    {
        public static void EntryPoint()
        {
            // int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            int[] array = new int[] {-10,  3, 5, 8,-13, 15, 21, -7, -3, -1, 32, 43 };

            PrintMaxContinuousSubArraySumIndexes(array);
            Console.ReadLine();
          
        }

        /// <summary>
        /// works for if there exists atleast one non negative number in the array
        /// </summary>
        /// <param name="array"></param>
        private static void PrintMaxContinuousSubArraySumIndexes(int[] array)
        {
            int currSum = 0;
            int n = array.Length;
            int maxSum = int.MinValue;
            int maxStartIndex = 0;
            int maxEndIndex = 0;
            int startIndex = 0;
           
            for(int i =0; i < n; ++i)
            {
                currSum += array[i];
                maxSum = Math.Max(maxSum, currSum);
                if (maxSum == currSum)
                {
                    maxStartIndex = startIndex;
                    maxEndIndex = i;
                }

                if(currSum<=0)
                {
                    startIndex = i + 1;
                    currSum = 0;
                }                
            }

            Console.WriteLine("{0} = {1}", string.Join(" + ", array.Skip(maxStartIndex).Take(maxEndIndex+1- maxStartIndex)), maxSum);
        }
    }
}
