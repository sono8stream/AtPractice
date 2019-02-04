using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest.ABC_117
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nk = ReadLongs();
            var array = ReadLongs();
            Array.Sort(array);
            long n = nk[0];
            long k = nk[1];
            int aDigit = 0;
            long aa = array[n - 1];
            while (aa > 1)
            {
                aDigit++;
                aa /= 2;
            }
            int kDigit = 0;
            long kk = k;
            while (kk > 1)
            {
                kDigit++;
                kk /= 2;
            }
            long res = 0;
            for(int i = kDigit+1; i >= 0; i--)
            {
                long val = 0;
                bool down = (k & (long)Math.Pow(2, i)) > 0;
                for (int j = Math.Max(aDigit,kDigit); j >= 0; j--)
                {
                    long div = (long)Math.Pow(2, j);
                    long cnt = 0;
                    for (int l = 0; l < n; l++)
                    {
                        if ((array[l] & div) > 0) cnt++;
                    }
                    if (cnt >= n - cnt)
                    {
                        val += div * cnt;
                    }
                    else
                    {
                        if (down)
                        {
                            if (j == i || (j > i && (k & div) == 0))
                                val += div * cnt;
                            else val += div * (n - cnt);
                        }
                        else
                        {
                            if ((k & div) == 0) val += div * cnt;
                            else val += div * (n - cnt);
                        }
                    }
                    //Console.WriteLine(cnt+" "+val);
                }
                res = Math.Max(res, val);
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
