using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1451
{
    class E
    {
        static void ain(string[] args)
        {
            //var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
           // SetOut(sw);

            Method(args);

            //Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] xors = new int[n];
            var dict = new Dictionary<int,List<int>>();
            int sameVal = -1;
            for (int i = 1; i < n; i++)
            {
                WriteLine("XOR " + 1 + " " + (i + 1));
                xors[i] = ReadInt();
                if (dict.ContainsKey(xors[i]))
                {
                    sameVal = xors[i];
                }
                else
                {
                    dict.Add(xors[i], new List<int>());
                }
                dict[xors[i]].Add(i);
            }

            int[] res = new int[n];
            if (dict.ContainsKey(0))
            {
                WriteLine("AND " + 1 + " " + (dict[0][0] + 1));
                res[0] = ReadInt();
            }
            else if (dict.Count == n - 1)
            {
                int otherIdx = dict[n - 1][0];
                int to = otherIdx == 1 ? 2 : 1;

                WriteLine("AND " + 1 + " " + (to + 1));
                int and1 = ReadInt();
                WriteLine("AND " + (to + 1) + " " + (otherIdx + 1));
                int and2 = ReadInt();

                int sum1 = 2 * and1 + xors[to];
                int sum2 = 2 * and2 + (xors[to] ^ xors[otherIdx]);
                int sum3 = n - 1;

                res[0] = (sum1 - sum2 + sum3) / 2;
            }
            else
            {
                WriteLine("AND " + (dict[sameVal][0] + 1) + " " + (dict[sameVal][1] + 1));
                res[0] = ReadInt() ^ xors[dict[sameVal][0]];
            }

            for (int i = 1; i < n; i++)
            {
                res[i] = xors[i] ^ res[0];
            }

            Write("!");
            for(int i = 0; i < n; i++)
            {
                Write(" " + res[i]);
            }
            WriteLine();
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
