using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_127
{
    class D
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
            long[] array = ReadLongs();
            Array.Sort(array);
            long[][] bcs = new long[m][];
            for(int i = 0; i < m; i++)
            {
                bcs[i] = ReadLongs();
            }
            bcs = bcs.OrderBy(a => -a[1]).ToArray();

            int now = 0;
            bool interrupt = false;
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < bcs[i][0]; j++)
                {
                    if (array[now] >= bcs[i][1])
                    {
                        interrupt = true;
                        break;
                    }

                    array[now] = bcs[i][1];
                    now++;
                    if (now >= n)
                    {
                        interrupt = true;
                        break;
                    }
                }
                if (interrupt) break;
            }

            long sum = 0;
            for (int i = 0; i < n; i++) sum += array[i];

            WriteLine(sum);
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
