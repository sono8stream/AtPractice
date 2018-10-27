using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_098
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            var twice = new int[n][];
            for(int i = 0; i < n; i++)
            {
                twice[i] = new int[20];
                int val = array[i];
                int digit = 0;
                while (val > 0)
                {
                    twice[i][digit] = val % 2;
                    val /= 2;
                    digit++;
                }
            }
            long res = 0;
            int r = 0;
            var sum = new int[20];
            for (int l = 0; l < n; l++)
            {
                bool sumed = false;
                for (; r < n; r++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        sum[j] += twice[r][j];
                        if (sum[j] > 1)
                        {
                            sumed = true;
                        }
                    }
                    if (sumed)
                    {
                        break;
                    }
                }
                res += r - l;

                for (int j = 0; j < 20; j++)
                {
                    sum[j] -= twice[l][j];
                    if (r < n)
                    {
                        sum[j] -= twice[r][j];
                    }
                }
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
