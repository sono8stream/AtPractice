using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_147
{
    class C
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
            int n = ReadInt();
            List<int[]>[] xys = new List<int[]>[n];
            for(int i = 0; i < n; i++)
            {
                int a = ReadInt();
                xys[i] = new List<int[]>();
                for(int j = 0; j < a; j++)
                {
                    xys[i].Add(ReadInts());
                }
            }

            int all = 1 << 15;
            int res = 0;
            for(int i = 0; i < all; i++)
            {
                int[] honests = new int[n];
                int cnt = 0;
                for(int j = 0; j < n; j++)
                {
                    honests[j] = (i & (1 << j)) > 0 ? 1 : 0;
                    if (honests[j]==1) cnt++;
                }

                bool ok = true;
                for(int j = 0; j < n; j++)
                {
                    if (honests[j] == 0) continue;
                    for(int k = 0; k < xys[j].Count; k++)
                    {
                        if (honests[xys[j][k][0]-1]!=xys[j][k][1])
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (!ok) break;
                }
                if (ok) res = Max(res, cnt);
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
