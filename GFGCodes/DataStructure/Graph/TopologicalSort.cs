using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GFGCodes
{
    public class TopologicalSort
    {
        public static void EntryPoint()
        {
        // DAG
        // https://en.wikipedia.org/wiki/Topological_sorting#/media/File:Directed_acyclic_graph_2.svg

            var ret = GetTopologicalSortDFS(
                new HashSet<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }).OrderBy(p=>p).ToHashSet(),
                new HashSet<KeyValuePair<int, int>>(
                    new[] {
                        new KeyValuePair<int,int>(1, 4),
                        new KeyValuePair<int,int>(2, 4),
                        new KeyValuePair<int,int>(3, 1),                        
                        new KeyValuePair<int,int>(3, 2),
                        new KeyValuePair<int,int>(4, 7),
                        new KeyValuePair<int,int>(4, 8),                        
                        new KeyValuePair<int,int>(5, 1),
                        new KeyValuePair<int,int>(5, 4),
                        new KeyValuePair<int,int>(5, 6),                           
                        new KeyValuePair<int,int>(6, 10),
                        new KeyValuePair<int,int>(6, 11),
                        new KeyValuePair<int,int>(7, 9),
                        new KeyValuePair<int,int>(8, 9),
                        new KeyValuePair<int,int>(8, 10),
                        new KeyValuePair<int,int>(9, 12),
                        new KeyValuePair<int,int>(10, 12),
                        new KeyValuePair<int,int>(10, 13),
                        new KeyValuePair<int,int>(11, 10),
                    }
                )
            );

            Console.WriteLine(string.Join(",", ret));
            Console.ReadLine();
            //System.Diagnostics.Debug.Assert(ret.SequenceEqual(new[] { 5, 7, 3, 11, 8, 2, 9, 10 }));
        }       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static List<int> GetTopologicalSortKhan(HashSet<int> nodes, HashSet<KeyValuePair<int, int>> edges)
        {
            var dictAdj = new Dictionary<int, List<int>>();

            // initialize the adjecent matrix.
            foreach (var edge in edges)
            {
                if (dictAdj.ContainsKey(edge.Key))
                {
                    dictAdj[edge.Key].Add(edge.Value);
                }
                else
                {
                    dictAdj[edge.Key] = new List<int>() { edge.Value };
                }
            }

            var dictInDegreeCount = new Dictionary<int, int>();

            // initialize the indegree count, this can be achieved from adj matrix as well ..
            foreach (var edge in edges)
            {
                if (dictInDegreeCount.ContainsKey(edge.Value))
                {
                    dictInDegreeCount[edge.Value]++;
                }
                else
                {
                    dictInDegreeCount.Add(edge.Value, 1);
                }
            }

            var queue1 = new Queue<int>();
           
            // initialize the queue
            foreach (var node in nodes)
            {
                if (!dictInDegreeCount.ContainsKey(node))
                {
                    queue1.Enqueue(node);
                }
            }

            var sortedList = new List<int>();

            var queue = new Queue<int>();
            while (queue1.Count > 0)
            {
                queue.Enqueue(queue1.Dequeue());
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    sortedList.Add(node);
                    Console.WriteLine("start visiting from {0}", node);

                    if (dictAdj.ContainsKey(node))
                    {
                        foreach (var adjNode in dictAdj[node])
                        {
                            Console.WriteLine("start visiting from {0} to {1}", node, adjNode);
                            dictInDegreeCount[adjNode]--;
                            if (dictInDegreeCount[adjNode] == 0)
                            {
                                queue.Enqueue(adjNode);
                            }
                        }
                    }
                }
            }

            return sortedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public static List<int> GetTopologicalSortDFS(HashSet<int> nodes, HashSet<KeyValuePair<int, int>> edges)
        {
            var visited= new HashSet<int>();
            var finalStack = new Stack<int>();

            var dictAdj = new Dictionary<int, List<int>>();

            // initialize the adjecent matrix.
            foreach (var edge in edges)
            {
                if (dictAdj.ContainsKey(edge.Key))
                {
                    dictAdj[edge.Key].Add(edge.Value);
                }
                else
                {
                    dictAdj[edge.Key] = new List<int>() { edge.Value };
                }
            }

            foreach (var node in nodes)
            {
                if (!visited.Contains(node))
                {
                    visited.Add(node);

                    // visit this node
                    VisitNode(node, visited, dictAdj, finalStack);
                }
            }

            return finalStack.ToList();
        }

        private static void VisitNode(int node, HashSet<int> visited, Dictionary<int, List<int>> adjacent, Stack<int>  finalStack)
        {
            List<int> adjNodes;
            var hasOutEdges= adjacent.TryGetValue(node, out adjNodes);
            if (hasOutEdges)
            {
                while (adjNodes != null && adjNodes.Count > 0)
                {
                    var adjNode = adjNodes[0];
                    Console.WriteLine("visiting node from {0} to {1},", node, adjNode);
                    if (!visited.Contains(adjNode))
                    {
                        visited.Add(adjNode);
                        VisitNode(adjNode, visited, adjacent, finalStack);
                    }
                    else
                    {
                        Console.WriteLine("node already visited {0}", adjNode);
                    }

                    adjNodes.RemoveAt(0);
                }
            }

            finalStack.Push(node);
        }
    }
}
