using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_179
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
            long[] nxm = ReadLongs();
            long n = nxm[0];
            long x = nxm[1];
            long m = nxm[2];

            long res = 0;
            if (n <= m)
            {
                long tmp = x;
                for (int i = 0; i < n; i++)
                {
                    res += tmp;
                    tmp *= tmp;
                    tmp %= m;
                }
            }
            else
            {
                List<long> vals = new List<long>();
                Dictionary<long, int> dict = new Dictionary<long, int>();
                long tmp = x;
                int right = 0;
                for (int i = 0; i < n; i++)
                {
                    if (dict.ContainsKey(tmp))
                    {
                        right = dict[tmp];
                        break;
                    }
                    else
                    {
                        dict.Add(tmp, i);
                        vals.Add(tmp);
                    }
                    tmp *= tmp;
                    tmp %= m;
                }

                long[] sums = new long[vals.Count];
                for (int i = 0; i < vals.Count; i++)
                {
                    sums[i] = vals[i];
                    if (i > 0)
                    {
                        sums[i] += sums[i - 1];
                    }
                }

                long loops = (n - right) / (vals.Count - right);
                long rightSum = sums[vals.Count - 1];
                if (right > 0)
                {
                    rightSum -= sums[right - 1];
                }
                res = loops * rightSum;
                if(right - 1 + (n - right) % (vals.Count - right) >= 0)
                {
                    res+= sums[right - 1 + (n - right) % (vals.Count - right)];
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
