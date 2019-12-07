using System;

namespace GFGCodes
{
    class ContinuousSubArraySum
    {
        public static void EntryPoint(string[] args)
        {
           
            string testArgs = Console.ReadLine();
            int noOfTestCases = 0;            
            int.TryParse(testArgs.Split(' ')[0], out noOfTestCases);
            string[] splitstring = new string[] { };
            int n = 0;
            int s = 0;
            int[] array = new int[] { };
            for (int i = 0;i < noOfTestCases;++i)
            {
                testArgs = Console.ReadLine();
                splitstring = testArgs.Split(' ');                
                int.TryParse(splitstring[0], out n);
                array = new int[n];
                int.TryParse(splitstring[1], out s);
                testArgs = Console.ReadLine();
                splitstring = testArgs.Split(' ');

                for (int inx =0;inx < n; ++inx)
                {
                   int.TryParse(splitstring[inx], out array[inx]);
                }

                PrintSumIndexes(array, n, s);
            }

            Console.ReadLine();
          
        }

        private static void PrintSumIndexes(int[] array, int n, int s)
        {
            int currSum = 0;
            for(int i =0; i < n; ++i)
            {
                currSum = 0;
                for (int j = i; j < n; ++j)
                {
                    currSum += array[j];
                    if (currSum == s)
                    {
                        Console.WriteLine("{0} {1}", i+1, j+1);
                        j = n; i = n;
                    }
                    else if(currSum > s)
                    {
                        j = n;
                    }
                }
            }
        }
    }
}
