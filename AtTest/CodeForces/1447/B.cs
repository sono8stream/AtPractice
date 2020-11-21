using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1447
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

                int[] vals = new int[n * m];
                int minuses = 0;
                int sum = 0;
                for(int j = 0; j < n; j++)
                {
                    int[] row = ReadInts();
                    for(int k = 0; k < m; k++)
                    {
                        vals[j * m + k] = Abs(row[k]);
                        sum += Abs(row[k]);
                        if (row[k] < 0)
                        {
                            minuses++;
                        }
                    }
                }

                Array.Sort(vals);
                if (minuses % 2 == 1)
                {
                    WriteLine(sum - vals[0] * 2);
                }
                else
                {
                    WriteLine(sum);
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
