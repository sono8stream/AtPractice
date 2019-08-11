using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_2
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
            int[] npq = ReadInts();
            int n = npq[0];
            int p = npq[1];
            int q = npq[2];
            long[] array = ReadLongs();
            if ((p + q) % 2 !=0)
            {
                WriteLine(0);
                return;
            }

            long res = 0;
            Dictionary<long, long> cntDict = new Dictionary<long, long>();
            long yzCnt = 0;
            for(int i = n - 1; i >= 0; i--)
            {
                if (2 * array[i] == p + q)
                {
                    res += yzCnt;
                }

                if (cntDict.ContainsKey((p - q) / 2 - array[i]))
                {
                    yzCnt += cntDict[(p - q) / 2 - array[i]];
                }

                if (!cntDict.ContainsKey(array[i]))
                {
                    cntDict.Add(array[i], 0);
                }
                cntDict[array[i]]++;
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
