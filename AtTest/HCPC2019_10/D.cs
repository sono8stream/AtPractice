using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_10
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            string[] reses = new string[t];
            for(int i = 0; i < t; i++)
            {
                int[] hw = ReadInts();
                long gcd = GCD(hw[0], hw[1]);
                long h = hw[0] / gcd;
                long w = hw[1] / gcd;
                long proc = h + w - 1;
                if (proc % 2 == 0) reses[i] = "1 1";
                else
                {
                    long a = proc / 2 + 1;
                    long b = proc / 2;
                    //long gcd2 = GCD(a, b);
                    reses[i] = a.ToString() 
                        + ' ' + b.ToString();
                }
            }

            for (int i = 0; i < t; i++) WriteLine(reses[i]);
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
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
