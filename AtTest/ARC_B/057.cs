using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ARC_B
{
    class _057
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] array = new int[n];
            for(int i = 0; i < n; i++)
            {
                array[i] = ReadInt();
            }
            int[] remains = new int[n];
            remains[n - 1] = 0;
            for(int i = n - 2; i >= 0; i--)
            {
                remains[i] = remains[i + 1] + array[i + 1];
            }
            int won = 1;
            int total = array[0];
            int res = 1;
            for (int i = 1; i < n; i++)
            {
                int win = won * array[i] / total + 1;
                int min = Math.Max(k - won - remains[i], 0);
                win = Math.Max(win, min);
                if (win <= Math.Min(array[i], k - won))
                {
                    res++;
                    won += win;
                }
                total += array[i];
            }
            Console.WriteLine(res);
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
