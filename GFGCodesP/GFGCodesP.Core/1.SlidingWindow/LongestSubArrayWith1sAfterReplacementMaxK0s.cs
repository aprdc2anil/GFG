using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class LongestSubArrayWith1sAfterReplacementMaxK0s
    {
        public static void EntryPoint()
        {

            int[] input = {0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1};
            PrintLongestSubArrayWith1sAfterReplacementMaxK0s(input, 3);
            Console.ReadLine();
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintLongestSubArrayWith1sAfterReplacementMaxK0s(int[] input, int k)
        {

            int maxLength = 0;
            int startIndex = 0;
            int zeroCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if(input[i]==0)
                    zeroCount++;

                while(zeroCount>k)
                {
                    if(input[startIndex]==0)
                    {
                        zeroCount--;
                    }
                    startIndex++;
                }

                maxLength = Math.Max(maxLength, i - startIndex + 1 );
            }

            Console.WriteLine(maxLength);
        }
    }
}

