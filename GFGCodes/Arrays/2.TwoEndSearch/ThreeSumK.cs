using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace GFGCodes
{
    public class ThreeSumK
    {
        public static void EntryPoint()
        {
            // int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

            int[] inputArray = new int[] { -10, -7, -3, -1, 3, 5, 8, 13, 21, 32, 43, 50 };
            Console.WriteLine("{0}", IsSumOfThreeIsK(inputArray, 54));
        }

        public static bool IsSumOfThreeIsK(int[] input, int sum)
        {
            Array.Sort(input);
            
            for (int k = 0; k < input.Length; ++k)
            {
                int chekSum = sum - input[k];
                int i = k+1;
                int j = input.Length - 1;

                while (i < j)
                {
                    int currSum = input[i] + input[j];
                    if (currSum == chekSum)
                    {
                        Console.WriteLine("{0} + {1} + {2} = {3}", input[k], input[i], input[j], sum);
                        return true;
                    }
                    else
                    {
                        if (currSum > chekSum)
                        {
                            --j;
                        }
                        else
                        {
                            ++i;
                        }
                    }
                }
            }

            return false;
        }

    }
}
