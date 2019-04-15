using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC8
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nq = ReadInts();
            int n = nq[0];
            int q = nq[1];
            int[] res = new int[q];
            for (int i = 0; i < q; i++)
            {
                int[] abst = ReadInts();
                int a = abst[0];
                int b = abst[1];
                int s = abst[2];
                int t = abst[3];
                if (s <= a && b <= t)
                {
                    res[i]=(a-s + t-b) * 100;
                }
                else if (s <= a && a <= t && t <= b)
                {
                    res[i] = (a - s) * 100;
                }
                else if (a <= s && s <= b && b <= t)
                {
                    res[i]=(t - b) * 100;
                }
                else if (a <= s && t <= b)
                {
                    res[i]=0;
                }
                else res[i]=(t-s) * 100;
            }
            for (int i = 0; i < q; i++) WriteLine(res[i]);
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
