using System;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.
namespace GFGCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> x = new Dictionary<int, int>();

            for (int i = 0; i < 5; ++i)
            {
                x.Add(i, 0);
            }


            Console.WriteLine(" befor increment {0}", string.Join(" ", x.Values));

            for (int i = 0; i < 5; ++i)
            {
                x[i]++;
            }

            Console.WriteLine(" after increment {0}", string.Join(" ", x.Values));

            // RotateMatrix.EntryPoint();
            Console.ReadLine();            
        }

        public static void EntryPoint()
        {

        }

        public static void Algorithm()
        {

        }
    }
}
