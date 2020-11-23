using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1422
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
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];
                long[,] vals = new long[n, m];

                for(int j = 0; j < n; j++)
                {
                    long[] row = ReadLongs();
                    for(int k = 0; k < m; k++)
                    {
                        vals[j, k] = row[k];
                    }
                }

                long res = 0;
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < m; k++)
                    {
                        int otherJ = n - 1 - j;
                        int otherK = m - 1 - k;

                        if (j > otherJ || k > otherK)
                        {
                            continue;
                        }

                        if (j == otherJ && k == otherK)
                        {
                            continue;
                        }

                        if (j == otherJ)
                        {
                            res += Abs(vals[j, k] - vals[j, otherK]);
                            continue;
                        }

                        if (k == otherK)
                        {
                            res += Abs(vals[j, k] - vals[otherJ, k]);
                            continue;
                        }

                        long[] nows = new long[4] {
                            vals[j,k],vals[otherJ,k],vals[j,otherK],vals[otherJ,otherK]
                        };
                        Array.Sort(nows);
                        res += nows[3] + nows[2] - nows[1] - nows[0];
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
