using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class CF2017C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            string canS = s.Replace("x", "");
            for (int i = 0; i < canS.Length; i++)
            {
                if (canS[i] != canS[canS.Length - 1 - i])
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            int[] xCnts = new int[canS.Length + 1];
            int now = 0;
            for(int i =0; i < s.Length; i++)
            {
                if (s[i] == 'x') xCnts[now]++;
                else now++;
            }
            int res = 0;
            for (int i = 0; i < xCnts.Length / 2; i++)
            {
                res += Math.Abs(xCnts[i] - xCnts[xCnts.Length - 1 - i]);
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
