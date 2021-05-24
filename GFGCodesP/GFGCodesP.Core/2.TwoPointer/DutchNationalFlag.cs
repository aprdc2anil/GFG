using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class DutchNationalFlag
    {
        public static void EntryPoint()
        {
            int[] array = new int[] { 2, 2, 0 , 1, 1, 0, 1, 2, 0, 2, 1, 2, 2, 1, 1, 0, 0, 1, 0, 1, 0, 2 };
            DNFSort(array);
            ArrayHelper.PrintArray(array);
            Console.ReadLine();
        }

         // 0, 2, 1, 1, 0, 2, 1, 0, 1, 0
         // 0, 0, 0, 0| 1, 1, 1, 1, |2, 2

        private static void DNFSort(int[] array)
        {

            if (array.Length <= 1)
            {
                Console.WriteLine("less than 2 elements in the array");

                return;
            }

            if (array.Length == 2)
            {
                if (array[1] < array[0])
                {
                    ArrayHelper.Swap(array, 0, 1);
                }

                return;
            }

            int startIndex = 0, endIndex = array.Length - 1;

            int i = 0;
            while (i <= endIndex)
            {
                if (array[i] == 2)
                {
                    ArrayHelper.Swap(array, endIndex, i);
                    endIndex--;
                }
                else if (array[i] == 0)
                {
                    ArrayHelper.Swap(array, i, startIndex);
                    ++startIndex;
                    ++i;
                } else{
                    ++i;
                }
            }
            //if(array[endIndex]==0)
            //{
             //   ArrayHelper.Swap(array, endIndex, startIndex);
            //}
        }
    }
}
