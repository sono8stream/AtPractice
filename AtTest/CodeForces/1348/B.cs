using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1348
{
    class B
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] nk = ReadInts();
                int n = nk[0];
                int k = nk[1];
                int[] array = ReadInts();
                var hashSet = new HashSet<int>();
                for(int j = 0; j < n; j++)
                {
                    hashSet.Add(array[j]);
                }
                if (hashSet.Count > k)
                {
                    WriteLine(-1);
                    continue;
                }

                List<int> res = new List<int>();
                foreach (int val in hashSet)
                {
                    res.Add(val);
                }
                while (res.Count < k)
                {
                    res.Add(res[0]);
                }
                for(int j = 1; j < n; j++)
                {
                    for(int l = 0; l < k; l++)
                    {
                        res.Add(res[res.Count - k]);
                    }
                }

                WriteLine(res.Count);
                for(int j = 0; j < res.Count; j++)
                {
                    Write(res[j]);
                    if (j + 1 < res.Count)
                    {
                        Write(" ");
                    }
                    else
                    {
                        WriteLine();
                    }
                }
            }
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
