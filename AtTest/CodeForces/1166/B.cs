using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1166
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int k = ReadInt();
            int h = 1;
            for(int i = 1; i <= k; i++)
            {
                if (i > k / i) break;

                if (k % i == 0) h = i;
            }
            int w = k / h;

            if (h < 5)
            {
                WriteLine(-1);
                return;
            }

            char[] chars = new char[5] { 'a', 'i', 'u', 'e', 'o' };
            for(int i = 0; i < k; i++)
            {
                int wTemp = i % w;
                int hTemp = i / w;
                Write(chars[(wTemp + hTemp) % 5]);
            }
            WriteLine();
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
