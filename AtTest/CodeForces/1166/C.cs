using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1166
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            for (int i = 0; i < n; i++) array[i] = Abs(array[i]);
            Array.Sort(array);

            long res = 0;
            for(int i = 0; i < n; i++)
            {
                int bottom = i;
                int top = n;
                while (bottom + 1 < top)
                {
                    int mid = (bottom + top) / 2;

                    if (array[mid] - array[i] <= array[i]) bottom = mid;
                    else top = mid;
                }

                res += bottom - i;
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
