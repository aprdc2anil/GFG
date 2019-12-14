using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace GFGCodes
{
    public class TwoSumK
    {
        public static void EntryPoint()
        {
            string testArgs = Console.ReadLine();
            int[] inputArray = Array.ConvertAll<string, int>(testArgs.Split(' '), s => int.Parse(s));
            Console.WriteLine("{0}", IsSumOfTwoIsKNoExtraMem(inputArray, 30));
        }

        public static bool IsSumOfTwoIsK(int[] input, int k)
        {
            Dictionary<int, int> arrayDic = new Dictionary<int, int>(input.Select(item=>new KeyValuePair<int, int>(item,item)));

            for (int i = 0; i < input.Length; ++i)
            {
                if (arrayDic.ContainsKey(k - input[i]))
                {
                    return true;
                }
            }

            return false;
        }


        public static bool IsSumOfTwoIsKNoExtraMem(int[] input, int k)
        {
            Array.Sort(input);
            int i = 0;
            int j = input.Length - 1;

            while (i < j)
            {
                int currSum = input[i] + input[j];
                if (currSum == k)
                {
                    return true;
                }
                else
                {
                    if (currSum > k)
                    {
                        --j;
                    }
                    else {
                        ++i;
                    }
                }
            }

            return false;
        }
    }
}
