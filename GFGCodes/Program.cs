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
            KWayMerge.EntryPoint();
            Console.ReadLine();
            ////var matrix = ReadMatrixMXN(3, 4);
            ////MatrixPrint(matrix);
            ////Console.ReadLine();
        }

        static int[][] ReadMatrix()
        {
            return new int[][] { new int[] { 1, 2, 3 }, new int[] { 11, 12, 13 }, new int[] { 21, 22, 23 }, new int[] { 31, 32, 33 } };
        }

        static int[,] ReadMatrixMXN(int m, int n)
        {
            var matrix = new int[m, n];
            var random = new Random();

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    matrix[i, j] = random.Next(1, 99);
                }
            }

            return matrix;
        }

        static void MatrixPrint(int[,] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(", ", row));
            }
        }
    }
}
