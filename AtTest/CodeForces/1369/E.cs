using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1369
{
    class E
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
            int[] ws = ReadInts();
            int[][] vals = new int[m][];

            for(int i = 0; i < m; i++)
            {
                vals[i] = ReadInts();
                vals[i][0]--;
                vals[i][1]--;
                Array.Sort(vals[i]);
            }

            Stack<int[]>[] subs = new Stack<int[]>[n];
            for(int i = 0; i < n; i++)
            {
                subs[i] = new Stack<int[]>();
            }
            int[] res = new int[m];
            int[] cnts = new int[n];
            for(int i = 0; i < m; i++)
            {
                int l = vals[i][0];
                int r = vals[i][1];

                if (cnts[l] < ws[l])
                {
                    cnts[l]++;
                    subs[l].Push(new int[2] { i, r });
                }
                else if (cnts[r] < ws[r])
                {
                    cnts[r]++;
                    subs[r].Push(new int[2] { i, l });
                }
                else
                {
                    if (subs[l].Count == 0 && subs[r].Count == 0)
                    {
                        WriteLine("DEAD");
                        return;
                    }
                    else
                    {
                        if (subs[l].Count > 0)
                        {

                        }
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
