using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1348
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
            int[] nk = ReadInts();
            int n = nk[0];
            long k = nk[1];
            long[][] abs = new long[n][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadLongs();
            }
            long[] aSums = new long[n];
            long[] bSums = new long[n];
            aSums[0] = abs[0][0];
            bSums[0] = abs[0][1];
            for(int i = 1; i < n; i++)
            {
                aSums[i] = aSums[i - 1] + abs[i][0];
                bSums[i] = bSums[i - 1] + abs[i][1];
            }

            var dict = new Dictionary<long, long>();
            dict.Add(0, 0);
            for(int i = 0; i < n; i++)
            {
                var next = new Dictionary<long, long>();
                foreach(long aTmp in dict.Keys)
                {
                    long all = 0;
                    if (i > 0)
                    {
                        all += aSums[i-1] + bSums[i - 1];
                    }
                    long bTmp = (all - k * dict[aTmp] - aTmp) % k;

                    for(long j = 0; j < k; j++)
                    {
                        if(j<=abs[i][0])
                        {
                            long nextVal = dict[aTmp];
                            long delta = (abs[i][0] - j + abs[i][1]) / k;
                            nextVal += delta;
                            long bRemain = abs[i][1] - (delta * k - (abs[i][0] - j));
                            if (aTmp + j >= k)
                            {
                                nextVal++;
                            }
                            if (bTmp + bRemain >= k)
                            {
                                nextVal++;
                            }
                            long nextKey = (aTmp + j) % k;
                            if (next.ContainsKey(nextKey))
                            {
                                next[nextKey] = Max(next[nextKey], nextVal);
                            }
                            else
                            {
                                next.Add(nextKey, nextVal);
                            }
                        }
                    }
                }
                dict = next;
            }

            long res = 0;
            foreach(long key in dict.Keys)
            {
                res = Max(res, dict[key]);
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
