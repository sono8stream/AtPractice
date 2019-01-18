using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeFestival2018final
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
            var abs = new int[n+1][];
            for(int i = 0; i < n; i++)
            {
                abs[i] = ReadInts();
            }
            abs[n] = new int[2] { int.MaxValue, int.MaxValue };
            int m = ReadInt();
            var ts = new int[m];
            for(int i = 0; i < m; i++)
            {
                ts[i] = ReadInt();
            }
            Array.Sort(abs, (a, b) => a[0] - b[0]);
            for(int i = 0; i < m; i++)
            {
                int bottom = 0;
                int top = n;
                while (bottom + 1 < top)
                {
                    int x = (bottom + top) / 2;
                    if (ts[i] < abs[x][0])
                    {
                        top = x;
                    }
                    else
                    {
                        bottom = x;
                    }
                }
                int val = 0;
                if (ts[i] < abs[bottom][0])
                {
                    val = abs[bottom][1];
                }
                else
                {
                    val = Math.Min(abs[bottom][1] + ts[i] - abs[bottom][0],
                       abs[bottom + 1][1]);
                } 
                Console.WriteLine(val);
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
