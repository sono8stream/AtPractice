using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeFestival2018final
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var distDict = new Dictionary<int, List<int>>[nm[0]];
            for(int i = 0; i < nm[0]; i++)
            {
                distDict[i] = new Dictionary<int, List<int>>();
            }
            var edges = new int[nm[1]][];
            for (int i = 0; i < nm[1]; i++)
            {
                int[] abl = ReadInts();
                if (!distDict[abl[0] - 1].ContainsKey(abl[2]))
                {
                    distDict[abl[0] - 1].Add(abl[2], new List<int>());
                }
                distDict[abl[0] - 1][abl[2]].Add(abl[1] - 1);
                if (!distDict[abl[1] - 1].ContainsKey(abl[2]))
                {
                    distDict[abl[1] - 1].Add(abl[2], new List<int>());
                }
                distDict[abl[1] - 1][abl[2]].Add(abl[0] - 1);
                edges[i] = new int[3] { abl[0] - 1, abl[1] - 1, abl[2] };
            }

            for(int i = 0; i < nm[0]; i++)
            {
                foreach(var list in distDict[i].Values)
                {
                    list.Sort();
                }
            }

            int cnt = 0;
            for(int i = 0; i < nm[0]; i++)
            {
                foreach(int dist in distDict[i].Keys)
                {
                    if (dist > 1270) continue;
                    
                    if (dist == 1270)
                    {
                        cnt += (distDict[i][dist].Count
                            * (distDict[i][dist].Count - 1)) / 2;
                    }
                }
            }
            /*
            for (int i = 0; i < nm[1]; i++)
            {
                int a = edges[i][0];
                int b = edges[i][1];
                int distance = edges[i][2];
                if (distance > 1540) continue;
                if (distDict[b].ContainsKey(2540 - distance))
                {
                    var list = distDict[b][2540 - distance];
                    int bottom = 0;
                    int top = list.Count;
                    while (top - bottom > 1)
                    {
                        int x = (bottom + top) / 2;
                        if (a < list[x])
                        {
                            top = x;
                        }
                        else
                        {
                            bottom = x;
                        }
                    }
                    cnt += list.Count - top + 1;
                }
            }
            */
            /*
            var listTest = new List<int>();
            listTest.Add(1);
            listTest.Add(3);
            listTest.Add(5);
            listTest.Add(8);
            Console.WriteLine(listTest.BinarySearch(2));
            Console.WriteLine(listTest.BinarySearch(3));
            Console.WriteLine(listTest.BinarySearch(6));
            */

            Console.WriteLine(cnt);
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
