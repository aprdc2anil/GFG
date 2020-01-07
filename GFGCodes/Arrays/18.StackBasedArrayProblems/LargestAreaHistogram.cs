using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GFGCodes
{
    public class LargestAreaHistogram
    {
        public static void EntryPoint()
        {
            int[] bars = new int[] { 5, 1, 5, 4, 2, 3, 4, 6, 5, 6, 5, 4, 3, 4, 2, 1 };
            var maxArea = CalculateLargestAreaHistogram(bars);

            Console.WriteLine(string.Join(" ", bars));
            Console.WriteLine("Max Area {0}", maxArea);
            Console.ReadLine();
        }

        public static int CalculateLargestAreaHistogram(int[] bars)
        {
            if (bars == null || !bars.Any())
                return -1;

            int n = bars.Length;
            int maxAreaSoFar = 0;

            Stack<int> indexes = new Stack<int>();

            #region detailed tracing
            // 1-16, 2-26, 3-27, 4-24, 5-20, 6-6, 
            //5, 1, 5, 4, 2 , 3, 4, 6, 5, 6, 5 , 4, 3, 4, 2 , 1

            /* 
            i=0, b[0]=5 
            push - 5
            stack {0} - > {5}
            
            i = 1, b[1] = 1
            pop - 5  , max - 5             
            stack {1} - > {1}
            
            i=2 , b[2] = 5
            push - 5 
            stack {1, 2} - > {1, 5}
            
            i=3 , b[3] = 4              
            pop  - 5 ,  max - 5
            push - 4
            stack {1, 3} - > {1, 4}
            
            i = 4 , b[4] = 2
            pop - 4,  max - 8           
            push - 2
            stack {1, 4} - > {1, 2}
            
            5, 1, 5, 4, 2 - 3, 4, 6, 5, 6, 5 , 4, 3, 4, 2 , 1
            
            i = 5 , b[5] = 3            
            push - 3
            stack {1, 4, 5} - > {1, 2, 3}
            
            i = 6 , b[6] = 4            
            push - 4
            stack {1, 4, 5, 6} - > {1, 2, 3, 4}
            
            i = 7 , b[7] = 6            
            push - 6
            stack {1, 4, 5, 6, 7} - > {1, 2, 3, 4, 6}
            
            i = 8 , b[8] = 5
            pop - 6, max - 8
            push - 5
            stack {1, 4, 5, 6, 8} - > {1, 2, 3, 4, 5}
            
            i = 9 , b[9] = 6           
            push - 6
            stack {1, 4, 5, 6, 8, 9} - > {1, 2, 3, 4, 5, 6}
            
            i = 10 , b[10] = 5
            pop - 6, max - 8        
            stack {1, 4, 5, 6, 8} - > {1, 2, 3, 4, 5}

            5, 1, 5, 4, 2 , 3, 4, 6, 5, 6, 5 - 4, 3, 4, 2 , 1

            i = 11 , b[11] = 4
            pop - 5, max - 20           
            stack {1, 4, 5, 6} - > {1, 2, 3, 4}

            i = 12 , b[12] = 3
            pop - 4, max - 24           
            stack {1, 4, 5} - > {1, 2, 3}

            i = 13 , b[13] = 4
            push - 4
            stack {1, 4, 5, 13} - > {1, 2, 3, 4}

            i = 14 , b[14] = 2
            pop - 4, pop - 3 , max - 27            
            stack {1, 4} - > {1, 2}

            i = 15 , b[15] = 1
            pop - 2          
            stack {1} - > {15}

            pop - 1          
            stack {1}
            */
            #endregion

            int i = 1;

            indexes.Push(0);

            while (i < n)
            {
                while (indexes.Count > 0 && bars[indexes.Peek()] > bars[i])
                {
                    int poppedIndex = indexes.Pop();
                    int tillIndex = 0;

                    if (indexes.Count > 0)
                    {
                        tillIndex = indexes.Peek() + 1;
                    }

                    int area = bars[poppedIndex] * (poppedIndex + 1 - tillIndex);
                    Console.WriteLine(" area {0} with bar {1} from index {2} to index {3}", area, bars[poppedIndex], tillIndex, poppedIndex);
                    if (area > maxAreaSoFar)
                    {
                        Console.WriteLine(" max area updated {0} from {1}", area, maxAreaSoFar);
                        maxAreaSoFar = area;
                    }
                }

                if (indexes.Count > 0 && bars[indexes.Peek()] == bars[i])
                {
                    indexes.Pop();
                }

                indexes.Push(i);
                ++i;
            }

            while (indexes.Count > 0 )
            {
                int poppedIndex = indexes.Pop();
                int tillIndex = 0;

                if (indexes.Count > 0)
                {
                    tillIndex = indexes.Peek() + 1;
                }

                int area = bars[poppedIndex] * (poppedIndex + 1 - tillIndex);
                Console.WriteLine(" area {0} with bar {1} from index {2} to index {3}", area, bars[poppedIndex], tillIndex, poppedIndex);
                if (area > maxAreaSoFar)
                {
                    Console.WriteLine(" max area updated {0} from {1}", area, maxAreaSoFar);
                    maxAreaSoFar = area;
                }
            }

            return maxAreaSoFar;
        }
    }
}
