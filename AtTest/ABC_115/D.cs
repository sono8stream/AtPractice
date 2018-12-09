using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_115
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
            long[] nx = ReadLongs();
            long n = nx[0];
            long x = nx[1];
            var pCnt = new long[n+1][];// all, p  L= 0 ~ n
            pCnt[0] = new long[2] { 1, 1 };
            for(int i = 1; i <= n; i++)
            {
                pCnt[i] = new long[2] {
                    pCnt[i-1][0] * 2 + 3, pCnt[i - 1][1] * 2 + 1 };
            }
            long cnt = 0;
            long nn = n;
            long now = x - 1;
            while (nn > 0)
            {
                if (now == 0)
                {
                    Console.WriteLine(cnt);
                    return;
                }
                else if (now < pCnt[nn][0] / 2)
                {
                    now--;
                    nn--;
                }
                else if(now==pCnt[nn][0]/2)
                {
                    Console.WriteLine(cnt + pCnt[nn - 1][1] + 1);
                    return;
                }
                else if (now < pCnt[nn][0]-1)
                {
                    now -= pCnt[nn - 1][0] + 2;
                    cnt += pCnt[nn - 1][1] + 1;
                    nn--;
                }
                else if (now == pCnt[nn][0]-1)
                {
                    Console.WriteLine(cnt + pCnt[nn][1]);
                    return;
                }

            }
            Console.WriteLine(cnt + 1);
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
