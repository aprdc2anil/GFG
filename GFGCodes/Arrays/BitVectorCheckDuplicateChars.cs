using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class BitVectorCheckDuplicateChars
    {
        public static void EntryPoint(string[] args)
        {
            string testArgs = Console.ReadLine();
            Console.Write(isUniqueBitVector(testArgs));
            Console.ReadLine();
        }

        // assuming that the characters range from a-z
        static bool isUniqueBitVector(String str)
        {
            int checker = 0;

            char[] array = str.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                int val = array[i] - 'a';

                if ((checker & (1 << val)) > 0)
                {
                    Console.WriteLine(array[i] + " is a duplicate");
                    return false;
                }
                else
                {                    
                    checker |= (1 << val);
                    Console.WriteLine(i.ToString() + "-a-" + array[i] + "-" + Convert.ToString(checker, 2).PadLeft(32, '0'));
                }
            }

            return true;
        }
    }
}
