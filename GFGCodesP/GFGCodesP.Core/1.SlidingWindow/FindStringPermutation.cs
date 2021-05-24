using System;
using System.Collections.Generic;

namespace GFGCodesP.Core.SlidingWindow
{
    public class FindStringPermutation
    {
        public static void EntryPoint()
        {

            PrintFindStringPermutation("oidbxcaf", "abcx");
            Console.ReadLine();
        }
        

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintFindStringPermutation(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern) || pattern.Length > input.Length)
            {
                Console.WriteLine("pattern cant be found");
            }

            Dictionary<char, int> patternDict = new Dictionary<char, int>();
            Dictionary<char, int> inputDict = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; ++i)
            {
                if (patternDict.ContainsKey(pattern[i]))
                {
                    patternDict[pattern[i]]++;
                }
                else
                {
                    patternDict.Add(pattern[i], 1);
                }
            }

            int subStringLength = 0;
            int startIndex = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (!patternDict.ContainsKey(input[i]))
                {
                    inputDict = new Dictionary<char, int>();
                    subStringLength = 0;
                    startIndex = i + 1;
                }
                else
                {
                    if (inputDict.ContainsKey(input[i]))
                    {
                        inputDict[input[i]]++;
                    }
                    else
                    {
                        inputDict.Add(input[i], 1);
                    }

                    subStringLength++;

                    if (subStringLength == pattern.Length)
                    {
                        if (isDictionariesMatch(inputDict, patternDict))
                        {
                            Console.WriteLine("pattern found ");
                            return;
                        }
                    }
                    else if (subStringLength == pattern.Length + 1)
                    {
                        inputDict[input[startIndex]]--;
                        if (inputDict[input[startIndex]] == 0)
                        {
                            inputDict.Remove(input[startIndex]);
                        }
                        startIndex++;
                        subStringLength--;
                    }
                }
            }

            if (isDictionariesMatch(inputDict, patternDict))
            {
                Console.WriteLine("pattern found ");
                return;
            }

            Console.WriteLine("pattern cant be found");
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        /// <param name="array"></param>
        private static void PrintFindStringPermutationOptimal(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern) || pattern.Length > input.Length)
            {
                Console.WriteLine("pattern cant be found");
            }

            Dictionary<char, int> patternDict = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; ++i)
            {
                if (patternDict.ContainsKey(pattern[i]))
                {
                    patternDict[pattern[i]]++;
                }
                else
                {
                    patternDict.Add(pattern[i], 1);
                }
            }

            Dictionary<char, int> patternDictCopy = new Dictionary<char, int>(patternDict);

            int subStringLength = 0;
            int startIndex = 0;
            int matched =0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (!patternDict.ContainsKey(input[i]))
                {
                    subStringLength = 0;
                    startIndex = i + 1;
                    patternDict = patternDictCopy;
                }
                else
                {
                    patternDict[input[i]]--;
                    if(patternDict[input[i]]==0)
                    {
                        matched++;
                    }

                    subStringLength++;

                    if (subStringLength == pattern.Length && matched==patternDict.Keys.Count)
                    {
                        Console.WriteLine("pattern found ");
                        return;
                    }
                    else if (subStringLength == pattern.Length)
                    {
                        if(patternDict[input[startIndex]]==0)
                        {
                            matched--;
                        }
                        
                        patternDict[input[startIndex]]++;
                        startIndex++;
                        subStringLength--;
                    }
                }
            }

            Console.WriteLine("pattern cant be found");
        }

        private static bool isDictionariesMatch(Dictionary<char, int> inputDict, Dictionary<char, int> patternDict)
        {
            foreach (var kv in patternDict)
            {
                if (!inputDict.ContainsKey(kv.Key) || inputDict[kv.Key] != kv.Value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

