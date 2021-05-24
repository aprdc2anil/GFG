using System;
using System.Collections.Generic;

namespace GFGCodesP.Core.SlidingWindow
{
    public class LongestSubstringWithKDistinctChars
    {
        public static void EntryPoint()
        {

            PrintLongestSubstringWithKDistinctChars("hhfwdjh", 3);
            Console.ReadLine();
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintLongestSubstringWithKDistinctChars(string input, int k)
        {

            int maxLength = 0;
            int startIndex = 0;
            if (string.IsNullOrEmpty(input) || input.Length < k || k <= 0 || input.Length == 0)
            {
                Console.WriteLine(maxLength);
                return;
            }

            Dictionary<char, int> distChars = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; ++i)
            {
                if (!distChars.ContainsKey(input[i]))
                {
                    while (distChars.Count == k)
                    {
                        distChars[input[startIndex]]--;
                        if (distChars[input[startIndex]] == 0)
                        {
                            distChars.Remove(input[startIndex]);
                        }
                        startIndex++;
                    }

                    distChars.Add(input[i], 1);
                    
                }
                else
                {
                    distChars[input[i]]++;
                }
                if (distChars.Count == k)
                {
                    maxLength = Math.Max(maxLength, i - startIndex + 1);
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}

