using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1400
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
            int t = ReadInt();
            for (int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[] array = ReadInts();

                long[] leftCnts = new long[n + 1];
                long[,] leftSums = new long[n + 1, n + 1];
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k <= n; k++)
                    {
                        leftSums[array[j], k] += leftCnts[k];
                    }
                    leftCnts[array[j]]++;
                }

                long res = 0;
                long[] rightCnts = new long[n + 1];
                for (int j = n - 1; j >=2; j--)
                {
                    leftCnts[array[j]]--;
                    for (int k = 0; k <= n; k++)
                    {
                        leftSums[array[j], k] -= leftCnts[k];
                    }

                    for(int k = 0; k <= n; k++)
                    {
                        res += rightCnts[k] * leftSums[k, array[j]];
                    }
                    rightCnts[array[j]]++;
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
