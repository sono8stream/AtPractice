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

            var resCnts = new long[n];
            var sortKs = new int[n][];
            for(int i = 0; i < n; i++)
            {
                sortKs[i] = new int[2] { ks[i], i };
            }
            Array.Sort(sortKs, (a, b) => a[0] - b[0]);

            var bCnts = new int[n];
            bCnts[0] = 0;
            bCnts[1] = s[1] == 'M' ? 1 : 0;
            var cCnts = new int[n];
            cCnts[0] = cCnts[1] = 0;
            var aList = new List<int>();

            for (int i = 0; i < n; i++)
            {

            }

            for (int i = 0; i < q; i++)
            {
                long cnts = 0;
                foreach (int index in bDict.Keys)
                {
                    for (int j = 0; j < ks[i] - 2; j++)
                    {
                        int aIndex = index - (ks[i] - 2) + j;
                        //Console.WriteLine(aIndex);
                        int cIndex = index + j + 1;
                        if (aIndex < 0 || s[aIndex] != 'D') continue;
                        if (index == n - 1) continue;
                        if (cIndex >= n) cIndex = n - 1;
                        //Console.WriteLine(cCnts[cIndex]);
                        cnts += cCnts[cIndex] - cCnts[index];
                    }
                }
                Console.WriteLine(cnts);
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
