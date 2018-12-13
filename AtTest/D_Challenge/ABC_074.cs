using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest.D_Challenge
{
    class ABC_074
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var distances = new long[n * (n - 1) / 2][];
            int itr = 0;
            for (int i = 0; i < n; i++)
            {
                long[] dist = ReadLongs();
                for (int j = i + 1; j < n; j++)
                {
                    distances[itr] = new long[3] { dist[j], i, j };
                    itr++;
                }
            }
            distances = distances.OrderBy(a => a[0]).ToArray();
            var tempDists = new long[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i != j)
                        tempDists[i, j] = -1;
                }
            }

            long res = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                long minDist = long.MaxValue;
                int start = (int)distances[i][1];
                int goal = (int)distances[i][2];
                for(int j = 0; j < n; j++)
                {
                    if (tempDists[start, j] == -1
                        || tempDists[j, goal] == -1) continue;

                    long dist = tempDists[start, j] + tempDists[j, goal];
                    minDist = Math.Min(minDist, dist);
                }
                if (minDist > distances[i][0])
                {
                    tempDists[start, goal] = distances[i][0];
                    tempDists[goal,start] = distances[i][0];
                    res += distances[i][0];
                }
                else if (minDist == distances[i][0])
                {
                    tempDists[start, goal] = distances[i][0];
                    tempDists[goal,start] = distances[i][0];
                }
                else if (minDist < distances[i][0])
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            /*for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write(tempDists[i, j] + " ");
                }
                Console.WriteLine();
            }*/
            Console.WriteLine(res);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
