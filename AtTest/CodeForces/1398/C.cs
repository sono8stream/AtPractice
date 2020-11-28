using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1398
{
    class C
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
                int n = ReadInt();
                string s = Read();

                int[] vals = new int[n];
                for(int j = 0; j < n; j++)
                {
                    vals[j] = s[j] - '1';
                }
                int[] sums = new int[n];
                sums[0] = vals[0];
                for(int j = 1; j < n; j++)
                {
                    sums[j] = sums[j - 1] + vals[j];
                }

                var dict = new Dictionary<int, long>();
                dict.Add(0, 1);
                long res = 0;
                for(int j = 0; j < n; j++)
                {
                    if (dict.ContainsKey(sums[j]))
                    {
                        res += dict[sums[j]];
                        dict[sums[j]]++;
                    }
                    else
                    {
                        dict.Add(sums[j], 1);
                    }
                }
                WriteLine(res);
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
