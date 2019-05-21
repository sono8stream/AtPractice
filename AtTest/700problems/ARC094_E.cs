using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC094_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();

            long res = 0;
            long sameCnt = 0;
            List<long[]> remains = new List<long[]>();
            for(int i = 0; i < n; i++)
            {
                long[] ab = ReadLongs();
                if (ab[0] < ab[1])
                {
                    res += ab[0];
                }
                else
                {
                    if (ab[0] == ab[1])
                    {
                        sameCnt++;
                        res += ab[0];
                    }
                    else remains.Add(ab);
                }
            }

            if (sameCnt == n)
            {
                WriteLine(0);
                return;
            }

            long aSum = remains.Sum(a => a[0]);
            long max = 0;
            for(int i = 0; i < remains.Count; i++)
            {
                max = Max(max, aSum - remains[i][1]);
            }

            res += max;
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
