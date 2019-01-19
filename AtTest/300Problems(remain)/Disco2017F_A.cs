using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class Disco2017F_A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int k = ReadInt();
            Console.WriteLine(GetGridCnt(200, k) + " " + GetGridCnt(300, k));
        }

        static int GetGridCnt(int d,int k)
        {
            int r = d / 2;
            int t = d / k;
            int cnt = 0;
            int rSq = r * r;
            for(int i = 0; i < t; i++)
            {
                for (int j = 0; j < t; j++)
                {
                    int w = k * i - r;
                    int h = k * j - r;
                    if (w * w + h * h <= rSq
                        && (w + k) * (w + k) + h * h <= rSq
                        && w * w + (h + k) * (h + k) <= rSq
                        && (w + k) * (w + k) + (h + k) * (h + k) <= rSq)
                        cnt++;
                }
            }
            return cnt;
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
