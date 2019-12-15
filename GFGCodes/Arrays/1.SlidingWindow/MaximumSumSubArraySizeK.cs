using System;
using System.Collections.Generic;
using System.Linq;

namespace GFGCodes
{
    class MaximumSumSubArraySizeK
    {
        public static void EntryPoint()
        {
            // int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            int[] array = new int[] {  8, 13, -7, -3, 21, 32, 3, 5, 43, -10, -1, 24 };

            var sum = MaximumSumSubArrayOfSizeK(array, 9);
            Console.ReadLine();
          
        }

        private static int MaximumSumSubArrayOfSizeK(int[] array, int k)
        {            
            int currSum = 0;
            int n = array.Length;
            int maxSum = int.MinValue;
         
            int indexj = 0;
            if (k > n)
                return -1;

            int i = 0;
           
            for (i =0; i < k; ++i)
            {
                currSum += array[i];
            }

            maxSum = Math.Max(maxSum, currSum);

           
            indexj = 0;

            while (i < n)
            {
                // 0, 1, 2, 3, 4, (i= k = 5) , 6
                currSum += (array[i]-array[i-k]);
                maxSum = Math.Max(maxSum, currSum);
                if (currSum == maxSum)
                {
                    indexj = i-k+1;
                }
                ++i;
            }
            Console.WriteLine("{0} = {1}",string.Join(" + ", array.Skip(indexj).Take(k)), maxSum);
            return maxSum;
        }

    }
}
