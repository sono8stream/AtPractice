using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_128
{
    class C
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
            var ons = new HashSet<int>[m];
            for (int i = 0; i < m; i++)
            {
                ons[i] = new HashSet<int>();
                int[] vals = ReadInts();
                for(int j = 1; j <= vals[0]; j++)
                {
                    ons[i].Add(vals[j] - 1);
                }
            }
            int[] ps = ReadInts();

            int allPat = 1 << n;
            int res = 0;
            for(int i = 0; i < allPat; i++)
            {
                int[] cnts = new int[m];
                for(int j = 0; j < n; j++)
                {
                    if ((i & (1 << j)) == 0) continue;

                    for(int k = 0; k < m; k++)
                    {
                        if (ons[k].Contains(j)) cnts[k]++;
                    }
                }

                int onCnt = 0;
                for(int j = 0; j < m; j++)
                {
                    if (cnts[j] % 2 == ps[j]) onCnt++;
                }

                if (onCnt == m) res++;
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
