using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class OrderedPageBinarySearch
    {
        public static int[] fullArray = new int[] { };
        public static void EntryPoint()
        {
            int[] fullArray2 = GenerateSortedArray(5000);
            ArrayHelper.PrintArray(fullArray2);
            Console.ReadLine();
        }

        public static int[] GenerateSortedArray(int n)
        {

            if (n <= 0)
                return null;

            int[] array = new int[n];

            Random random = new Random();

            int i = 0;
            int value = random.Next(1, 100);

            while (true)
            {
                int k = random.Next(0, (n - i) / 2);
                Console.WriteLine("{0} ", k);
                
                while (k > 0 && i < n)
                {
                    array[i] = value;
                    ++i;
                    --k;
                }

                if (i == n)
                {
                    break;
                }

                value = value + random.Next(1, 100);
            }

            return array;
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void FindCount(int limit, int k)
        {

        }
    }
}
