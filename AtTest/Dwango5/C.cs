using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtTest.Dwango5
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string s = Read();
            int q = ReadInt();
            int[] ks = ReadInts();

            long[] mCnts = new long[n];
            long[] cCnts = new long[n];
            long[] mcCnts = new long[n];
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    mCnts[i] = mCnts[i - 1];
                    cCnts[i] = cCnts[i - 1];
                    mcCnts[i] = mcCnts[i - 1];
                }
                if (s[i] == 'M') mCnts[i]++;
                if (s[i] == 'C')
                {
                    cCnts[i]++;
                    mcCnts[i] += mCnts[i];
                }
            }

            for (int i = 0; i < q; i++)
            {
                long res = 0;
                for (int j = 0; j < n; j++)
                {
                    if (s[j] != 'D') continue;

                    int maxI = Math.Min(j + ks[i] - 1, n - 1);
                    res += mcCnts[maxI] - mcCnts[j]
                        - (cCnts[maxI] - cCnts[j]) * mCnts[j];
                }
                Console.WriteLine(res);
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
