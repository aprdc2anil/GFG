using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class Permutations
    {
        static int count = 1;
        public static void EntryPoint()
        {
            string input = "abcd";
            char[] charArray = input.ToCharArray();
            int n = charArray.Length;
            PermuteRecursive(charArray, n, 0);
            Console.ReadLine();
        }

        public static void PermuteRecursive(char[] charArray, int n, int index)
        {
            if (index == n - 1)
            {
                Console.WriteLine("{0} - {1}", count++, new string(charArray));
            }
            else
            {                
                for (int i = index; i < n; ++i)
                {
                    Swap(charArray, index, i);
                    PermuteRecursive(charArray, n, index + 1);
                    Swap(charArray, i, index);
                }
            }
        }

        private static void Swap(char[] array, int x, int y)
        {
            char temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }


    }
}
