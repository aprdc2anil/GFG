using System;
using System.Collections.Generic;

namespace GFGCodes
{
    class ContinuousSubArraySum
    {
        public static void EntryPoint()
        {
            // int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            int[] array = new int[] {-10, -7, -3, -1, 3, 5, 8, 13, 21, 32, 43, 50 };

            PrintSumIndexesHash(array, 18);
            Console.ReadLine();
          
        }

        private static void PrintSumIndexes(int[] array, int n, int s)
        {
            int currSum = 0;
            for(int i =0; i < n; ++i)
            {
                currSum = 0;
                for (int j = i; j < n; ++j)
                {
                    currSum += array[j];
                    if (currSum == s)
                    {
                        Console.WriteLine("{0} {1}", i, j);
                        j = n; i = n;
                    }
                    else if(currSum > s)
                    {
                        j = n;
                    }
                }
            }
        }

        /// <summary>
        /// This is wrong implimentation this does not work
        /// </summary>
        /// <param name="array"></param>
        /// <param name="s"></param>
        private static void PrintSumIndexesSort(int[] array, int s)
        {
            Array.Sort(array);

            int curr_sum = 0;
            int i = 0;

            while(curr_sum<s && i < array.Length)
            {
                curr_sum += array[i];
                ++i;
            }

            if (i == array.Length)
            {
                return;
            }

            if(curr_sum==s)
            {
                Console.WriteLine("{0} {1}", 0, i);
                return;
            }

            int j = i;
            i = 0;

            while(i<j && j<array.Length)
            {
                if(curr_sum>s)
                {
                    curr_sum -= array[i];
                    ++i;
                }
                else if(curr_sum < s)
                {
                    curr_sum += array[j];
                    ++j;
                }
                else
                {
                    Console.WriteLine("{0} {1}", i , j );
                    return;
                }

            }

        }

        /// <summary>
        /// This is wrong implimentation this does not work
        /// </summary>
        /// <param name="array"></param>
        /// <param name="s"></param>
        private static void PrintSumIndexesHash(int[] array, int s)
        {           
            int currSum = 0;
            int i = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int j = 0; j < array.Length; ++j)
            {
                currSum += array[j];
                dict.Add(currSum, j);
                if (s == currSum)
                {
                    Console.WriteLine("{0}, {1}", i, j);
                    return;
                }
                else if (dict.ContainsKey(currSum-s))
                {
                    Console.WriteLine("{0}, {1}", dict[currSum-s]+1, j);
                    return;
                }
            }
        }
    }
}
