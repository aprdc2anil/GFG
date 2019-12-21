using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes
{
    public class LongestSubArraySumAtMaxS
    {
        public static void EntryPoint()
        {
            // int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            int[] array = new int[] { 10, 3, 5, 8, 13, 15, 21, 7, 3, 1, 8, 43 };

            PrintLongestSubArraySumAtMaxS(array, 18);
            Console.ReadLine();
        }


        /// <summary>
        /// This is wrong implimentation this does not work...
        /// Fails when you have something like below
        /// -5, -6, -7, -8, 40, -3, -4 ; sum = 8
        /// 
        /// this will work for only positive numbers
        /// </summary>
        /// <param name="array"></param>
        /// <param name="s"></param>
        private static void PrintLongestSubArraySumAtMaxS(int[] array, int s)
        {
            int maxStartIndex = 0, maxEndIndex = 0, startIndex = 0, currSum = 0, currLength=0, maxLength=0;
            int sumLessThanSAtMaxLength = 0;

            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] > s)
                {
                    currSum = 0;
                    startIndex = i + 1;
                    currLength = 0;
                }
                else {

                    currSum += array[i];
                    ++currLength;

                    if (currSum > s)
                    {
                        // do something to adjust
                        // startIndex, currSum, currLength

                        int diff = currSum - s;

                        int tempDiff = 0;

                        while (tempDiff < diff && startIndex < i )
                        {
                            tempDiff += array[startIndex];
                            ++startIndex;
                            --currLength;
                            currSum -= array[startIndex];
                        }
                    }                    
                }

                maxLength = Math.Max(maxLength, currLength);

                if (maxLength == currLength)
                {
                    maxStartIndex = startIndex;
                    maxEndIndex = i;
                    sumLessThanSAtMaxLength = currSum;
                }
            }

            Console.WriteLine("{0} = {1} of max length: {2}", string.Join(" + ", array.Skip(maxStartIndex).Take(maxEndIndex + 1 - maxStartIndex)), sumLessThanSAtMaxLength, maxLength);
        }
    }
}
