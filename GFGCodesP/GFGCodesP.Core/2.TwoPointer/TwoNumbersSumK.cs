using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class TwoNumbersSumK
    {
        public static void EntryPoint()
        {
            // int[] array = new int[] { -10, -7, -3, -1, 3, 5, 8, 13, 21, 32, 43, 50 };

            int[] array = new int[] { 2, 3, 5, 7, 11, 13, 17, 19 };


            PrintTwoNumbersSumK(array, 45);
            Console.ReadLine();
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintTwoNumbersSumK(int[] array, int k)
        {

            if (array.Length <= 1)
            {
                Console.WriteLine("less than 2 elements in the array");
            }

            int i = 0, j = array.Length - 1;

            while (i < j)
            {
                int sum = array[i] + array[j];

                if (sum == k)
                {
                    Console.WriteLine("{0} + {1} = {2}", array[i], array[j], k);
                    return;
                }
                else if (sum > k)
                {
                    --j;
                }
                else
                {
                    ++i;
                }

            }

            Console.WriteLine("No pair found");

        }
    }
}
