using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_day2
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            long[] aArray = ReadLongs();
            long[] bArray = ReadLongs();

            int length = 200000 + 10;
            long sum = 0;
            int[] cnts = new int[length];
            long aMax = 0;
            for(int i = 0; i < n; i++)
            {
                sum += aArray[i];
                aMax = Max(aMax, aArray[i]);
                cnts[aArray[i]]++;
            }
            for(int i = 1; i < length; i++)
            {
                cnts[i] += cnts[i - 1];
            }

            Array.Sort(bArray);
            List<long[]> bList = new List<long[]>();
            for(int i = 0; i < m; i++)
            {
                if (bList.Count == 0) bList.Add(new long[2] { bArray[i], 1 });
                else
                {
                    if (bList[bList.Count - 1][0] == bArray[i])
                    {
                        bList[bList.Count - 1][1]++;
                    }
                    else
                    {
                        bList.Add(new long[2] { bArray[i], 1 });
                    }
                }
            }

            long res = 0;
            for (int i = 0; i < bList.Count; i++)
            {
                long cnt = 0;
                for (int j = 1; j * bList[i][0] <=aMax; j++)
                {
                    long maxIndex = Min(aMax, (j + 1) * bList[i][0] - 1);
                    cnt += (cnts[maxIndex]
                        - cnts[j * bList[i][0] - 1]) * j;
                }
                res += (sum - cnt * bList[i][0]) * bList[i][1];
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
