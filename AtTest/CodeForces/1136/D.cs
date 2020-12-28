using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1136
{
    class D
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int[] poses = ReadInts();
            var dict = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < m; i++)
            {
                int[] pair = ReadInts();
                if (dict.ContainsKey(pair[0]))
                {
                    dict[pair[0]].Add(pair[1]);
                }
                else
                {
                    dict.Add(pair[0], new HashSet<int>());
                    dict[pair[0]].Add(pair[1]);
                }
            }

            var remain = new HashSet<int>();
            int last = poses[n - 1];
            int res = 0;
            for(int j = n - 2; j >= 0; j--)
            {
                if (dict.ContainsKey(poses[j]) && dict[poses[j]].Contains(last))
                {
                    int cnt = 0;
                    foreach(int right in dict[poses[j]])
                    {
                        if (remain.Contains(right))
                        {
                            cnt++;
                        }
                    }
                    if (cnt == remain.Count)
                    {
                        res++;
                    }
                    else
                    {
                        remain.Add(poses[j]);
                    }
                }
                else
                {
                    remain.Add(poses[j]);
                }
            }

            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
