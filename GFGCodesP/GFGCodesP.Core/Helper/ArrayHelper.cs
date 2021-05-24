using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public static class ArrayHelper
    {

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length;++i)
            {
                 Console.Write("{0} ", array[i]);
            }
        }
         public static void Swap(int[] array, int i, int j)
        {
           int tmp = array[i];
           array[i] = array[j];
           array[j] = tmp;
        }
    }
}
