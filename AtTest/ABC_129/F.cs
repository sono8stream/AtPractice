using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_129
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            long[] labm = ReadLongs();
            long l = labm[0];
            long a = labm[1];
            long b = labm[2];
            long m = labm[3];

            long[] dCnts = new long[18];
            long max = 0;
            long lower = 0;
            for(int i = 0; i < 18; i++)
            {
                max *= 10;
                max += 9;
                if (max - a < 0) continue;
                long upper = (max - a) / b + 1;
                dCnts[i] -= lower;
                if (l < upper)
                {
                    dCnts[i] += l;
                    break;
                }
                dCnts[i] += upper;
                lower = upper;
            }

            long[,] matrix = new long[3, 3];
            for(int i = 0; i < 3; i++)
            {
                matrix[i, i] = 1;
            }

            a %= m;
            b %= m;
            for (int i = 0; i < 18; i++)
            {
                long[,] tmp = new long[3, 3];
                tmp[0, 0] = ((long)Pow(10, i + 1)) % m;
                tmp[1, 0] = 1;
                tmp[1, 1] = 1;
                tmp[2, 1] = b;
                tmp[2, 2] = 1;

                long dig = 1;
                while (dig <= dCnts[i])
                {
                    if ((dCnts[i] & dig) > 0)
                    {
                        matrix = Dot(matrix, tmp, m);
                    }

                    tmp = Dot(tmp, tmp, m);
                    dig *= 2;
                }
            }

            long res = (matrix[1, 0] * a) % m;
            res += matrix[2, 0];
            res %= m;
            WriteLine(res);
        }

        static long[,] Dot(long[,] a,long[,] b,long mask)
        {
            int h = a.GetLength(0);
            int w = b.GetLength(1);
            long[,] ret = new long[h, w];
            for (int i = 0; i < h; i++)
            {
                for(int j = 0; j < w; j++)
                {
                    long val = 0;
                    for(int k = 0; k < a.GetLength(1); k++)
                    {
                        val += a[i, k] * b[k, j];
                        val %= mask;
                    }
                    ret[i, j] = val;
                }
            }

            return ret;
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
