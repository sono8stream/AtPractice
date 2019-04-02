using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Exerwizerds2019
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            string s = "a" + Read() + "b";
            char[][] tds = new char[q+2][];
            for(int i =0; i < q; i++)
            {
                string[] ss = Read().Split();
                tds[i] = new char[2] { ss[0][0], ss[1][0] };
            }
            int bottom = 0;
            int top = n + 2;
            while (bottom + 1 < top)
            {
                int mid= (bottom + top) / 2;
                int now = mid;
                for (int i = 0; i < q; i++)
                {
                    if (s[now] == tds[i][0])
                    {
                        if (tds[i][1] == 'L') now--;
                        else now++;

                        if (now == 0)
                        {
                            break;
                        }
                    }
                }
                if (now == 0)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }
            int res = bottom;

            bottom = -1;
            top = n + 1;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                int now = mid;
                for (int i = 0; i < q; i++)
                {
                    if (s[now] == tds[i][0])
                    {
                        if (tds[i][1] == 'L') now--;
                        else now++;

                        if (now == n + 1)
                        {
                            break;
                        }
                    }
                }
                if (now == n+1)
                {
                    top = mid;
                }
                else
                {
                    bottom = mid;
                }
            }
            res += n+1 - top;
            res = n - res;
            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
