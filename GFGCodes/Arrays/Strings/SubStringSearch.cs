using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class SubStringSearch
    {
        public static void EntryPoint()
        {
            string input = "aabababbababbaaabbabbaabaaabababa";
            int count = KMPPatternMatching("abab", input);
            Console.WriteLine("number: {0}", count);
            Console.ReadLine();
        }

        public static int KMPPatternMatching(string pattern, string text)
        {
            int count = 0;

            int[] lsp = KMPAlgorithm(pattern);

            int m = pattern.Length;
            int n = text.Length;
            int j = 0;

            for (int i = 0; i < n; ++i)
            {
                while (j > 0 && pattern[j] != text[i])
                {
                    j = lsp[j - 1];
                }

                if (pattern[j] == text[i])
                {
                    ++j;
                    if (j == m)
                    {
                        j = lsp[m - 1];
                        ++count;
                    }
                }
            }

            return count;
        }

        public static int[] KMPAlgorithm(string text)
        {
            // maintain length at each i , the longest suffix that is also a prefix for 0, i            
            int len = text.Length;
            int[] lsp = new int[len];
            
            lsp[0] = 0;
            int j = 0;
            for (int i = 1; i < len; ++i)
            {
                while (text[j] != text[i] && j>0)
                {
                    // get the max suffix for j length prefix of the original string
                    // repeat the process
                    j = lsp[j - 1];
                }

                if (text[j] == text[i])
                {
                    ++j;
                }

                lsp[i] = j;
            }

            Console.WriteLine(string.Join(" ", text.ToCharArray()));
            Console.WriteLine(string.Join(" ", lsp));
            Console.WriteLine(lsp[len - 1]);
            return lsp;
        }

        public static void ZAlgorithm()
        {
        }
    }

   
}
