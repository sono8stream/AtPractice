using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class CF2016C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] tArray = ReadInts();
            int[] aArray= ReadInts();
            bool[] tFixed = new bool[n];
            bool[] aFixed = new bool[n];
            tFixed[0] = true;
            aFixed[n - 1] = true;
            for(int i = 1; i < n; i++)
            {
                if (tArray[i] > tArray[i - 1]) tFixed[i] = true;
                if (aArray[n - 1 - i] > aArray[n - i]) aFixed[n-1-i] = true;
            }
            long res = 1;
            long mask = 1000000000 + 7;
            for(int i = 0; i < n; i++)
            {
                if (tFixed[i] && aFixed[i]){
                    if (tArray[i] == aArray[i]) continue;
                    else
                    {
                        Console.WriteLine(0);
                        return;
                    }
                }
                else if (tFixed[i])
                {
                    if (tArray[i] <= aArray[i]) continue;
                    else
                    {
                        Console.WriteLine(0);
                        return;
                    }
                }
                else if (aFixed[i])
                {
                    if (aArray[i] <= tArray[i]) continue;
                    else
                    {
                        Console.WriteLine(0);
                        return;
                    }
                }
                else
                {
                    res *= Math.Min(tArray[i], aArray[i]);
                    res %= mask;
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
