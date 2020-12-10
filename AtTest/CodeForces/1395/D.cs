using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1395
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
            int[] ndm = ReadInts();
            int n = ndm[0];
            long d = ndm[1];
            long m = ndm[2];
            long[] array = ReadLongs();
            Array.Sort(array);

            List<long> unders = new List<long>();
            List<long> uppers = new List<long>();
            for(int i = 0; i < n; i++)
            {
                if (array[i] <= m)
                {
                    unders.Add(array[i]);
                }
                else
                {
                    uppers.Add(array[i]);
                }
            }

            if (uppers.Count == 0)
            {
                WriteLine(unders.Sum());
                return;
            }

            long useMin = uppers.Count / (d + 1);
            if (uppers.Count % (d + 1) > 0)
            {
                useMin++;
            }

            long[] underSums = new long[unders.Count];
            for(int i = unders.Count-1; i >=0;i--)
            {
                underSums[i] = unders[i];
                if (i + 1 < unders.Count)
                {
                    underSums[i] += underSums[i + 1];
                }
            }
            long[] upperSums = new long[uppers.Count];
            for (int i = uppers.Count - 1; i >= 0; i--)
            {
                upperSums[i] = uppers[i];
                if (i + 1 < uppers.Count)
                {
                    upperSums[i] += upperSums[i + 1];
                }
            }


            long res = 0;
            for(long i = useMin; i <= uppers.Count; i++)
            {
                long minCnt = d * (i - 1);
                long remain = n - i;
                if (remain < minCnt)
                {
                    continue;
                }

                long tmp = upperSums[uppers.Count - i];
                long underUsed = Max(minCnt - (uppers.Count - i), 0);
                if (underUsed < unders.Count)
                {
                    tmp += underSums[underUsed];
                }
                res = Max(res, tmp);
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
