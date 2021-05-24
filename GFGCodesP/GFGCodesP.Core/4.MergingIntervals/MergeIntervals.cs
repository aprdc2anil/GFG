using System;
using System.Collections.Generic;

namespace GFGCodesP.Core
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Interval()
        {
        }

        public Interval(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public void PrintInterval()
        {
            Console.Write("[{0}, {1}],  ", this.Start, this.End);

        }
    };

    public class MergeIntervals
    {
        public static void EntryPoint()
        {
            List<Interval> intervalList = GetListOfIntervals();
            List<Interval> intervalList2 = GetListOfIntervals2();

            PrintIntervalList(intervalList);
            PrintIntervalList(intervalList2);

            PrintIntervalList(GetMergedIntervals(intervalList));

            PrintIntervalList(GetMergedIntervals(intervalList2));

            PrintIntervalList(IntervalIntersection(intervalList, intervalList2));

            Console.ReadLine();
        }

        private static void PrintIntervalList(List<Interval> intervalList)
        {
            foreach (var item in intervalList)
            {
                item.PrintInterval();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        private static List<Interval> GetListOfIntervals()
        {
            List<Interval> list = new List<Interval>();
            list.Add(new Interval(10, 13));
            list.Add(new Interval(15, 17));
            list.Add(new Interval(12, 14));
            list.Add(new Interval(1, 4));
            list.Add(new Interval(4, 9));
            list.Add(new Interval(2, 3));
            list.Add(new Interval(3, 7));
            return list;
        }

        private static List<Interval> GetListOfIntervals2()
        {
            List<Interval> list = new List<Interval>();
            list.Add(new Interval(10, 12));
            list.Add(new Interval(2, 6));
            list.Add(new Interval(3, 7));
            list.Add(new Interval(9, 16));
            return list;
        }

        /// <summary>
        /// optimal implimentation
        /// </summary>
        private static List<Interval> GetMergedIntervals(List<Interval> intervalList)
        {
            if (intervalList.Count <= 1)
            {
                return intervalList;
            }

            intervalList.Sort(CompareIntervals);
            PrintIntervalList(intervalList);

            List<Interval> result = new List<Interval>();

            result.Add(intervalList[0]);

            int topIndex = 0;

            for (int i = 1; i < intervalList.Count; ++i)
            {
                if (intervalList[i].Start > result[topIndex].End)
                {
                    result.Add(intervalList[i]);
                    topIndex++;
                }
                else if (intervalList[i].End > result[topIndex].End)
                {
                    result[topIndex].End = intervalList[i].End;
                }
            }

            return result;
        }

        private static List<Interval> IntervalIntersection(List<Interval> intervalList1, List<Interval> intervalList2)
        {
            List<Interval> result = new List<Interval>();
            int i = 0; int j = 0;
            while (i < intervalList1.Count && j < intervalList2.Count)
            {
                if (intervalList1[i].Start > intervalList2[j].End || intervalList2[j].Start > intervalList1[i].End)
                {
                    if (intervalList1[i].End < intervalList2[j].Start)
                    {
                        ++i;
                    }
                    else
                    {
                        ++j;
                    }
                }
                else
                {
                    Interval x = new Interval();
                    x.Start = Math.Max(intervalList1[i].Start, intervalList2[j].Start);
                    x.End = Math.Min(intervalList1[i].End, intervalList2[j].End);
                    result.Add(x);

                    if (intervalList1[i].End > x.End)
                    {
                        intervalList1[i].Start = x.Start + 1;
                        ++j;
                    }
                    else if (intervalList2[j].End > x.End)
                    {
                        intervalList2[j].Start = x.Start + 1;
                        ++i;
                    }
                }
            }

            return GetMergedIntervals(result);
        }

        private static int CompareIntervals(Interval x, Interval y)
        {
            return x.Start - y.Start;
        }
    }
}
