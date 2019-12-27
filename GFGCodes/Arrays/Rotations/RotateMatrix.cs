using System;
using System.Collections.Generic;
using System.Text;

namespace GFGCodes
{
    public class RotateMatrix
    {
        public static void EntryPoint()
        {
            int[,] matrix = GenerateMatrix(5);
            PrintMatrix(matrix, 5);
            RotateMatrix90ClockWise(matrix, 5);
            PrintMatrix(matrix, 5);
            Console.WriteLine();
        }

        public static int[,] GenerateMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            Random r = new Random();
            for (int i= 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    matrix[i, j] = r.Next(1, n * n * 2);
                }
            }

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix, int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void RotateMatrix90ClockWise(int[,] matrix, int n)
        {
            // rotate by each layer
            for (int i = 1; i <= n / 2; ++i)
            {
                int rowStart = i - 1;
                int rowEnd = n - i;

                int colStart = i - 1;
                int colEnd = n - i;

                // each element in the row
                for (int j = 0; colStart+j < colEnd; ++j)
                {                       
                    Console.WriteLine("({0}, {1}) : {2}", rowStart, colStart + j, colEnd);

                    int temp = matrix[rowStart, colStart + j];

                    matrix[rowStart, colStart + j] = matrix[rowEnd-j, colStart];
                    matrix[rowEnd - j, colStart] = matrix[rowEnd, colEnd-j];
                    matrix[rowEnd, colEnd - j] = matrix[rowStart+j, colEnd];
                    matrix[rowStart + j, colEnd] = temp;

                }
            }

        }
    }
}
