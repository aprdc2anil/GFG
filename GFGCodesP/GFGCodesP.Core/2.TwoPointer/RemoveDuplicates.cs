using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class RemoveDuplicates
    {
        public static void EntryPoint()
        {
            int[] array = new int[] { 2, 3, 5, 5, 7, 7, 7, 9, 11, 13, 13, 13, 15, 15, 17, 19, 21, 23, 23, 25, 25, 25 };
            PrintRemoveDuplicatesWithNoLoss(array);
            Console.ReadLine();
        }

        private static void PrintRemoveDuplicates(int[] array)
        {

            if (array.Length <= 1)
            {
                Console.WriteLine("less than 2 elements in the array");
            }

            int noDuplicatesSoFarIndex = 0;

            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] != array[i - 1])
                {
                    array[noDuplicatesSoFarIndex + 1] = array[i];
                    noDuplicatesSoFarIndex++;
                }
            }

            ArrayHelper.PrintArray(array);

        }

        private static void PrintRemoveDuplicatesWithNoLoss(int[] array)
        {

            if (array.Length <= 1)
            {
                Console.WriteLine("less than 2 elements in the array");
            }

            int noDuplicatesSoFarIndex = 0;

            // { 2, 3, 5, 5, 7, 7, 7, 9, 11, 13, 13, 13, 15, 15, 17, 19, 21, 23, 23, 25, 25, 25 }

            // { 2, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 15, 7, 7, 13, 13, 23, 5, 25, 25 }

            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] > array[noDuplicatesSoFarIndex])
                {
                    noDuplicatesSoFarIndex++;

                    ArrayHelper.Swap(array, noDuplicatesSoFarIndex, i);
                }
            }

             ArrayHelper.PrintArray(array);
             Console.WriteLine();
        }
    }
}
