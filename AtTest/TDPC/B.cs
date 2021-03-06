﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] ab = ReadInts();
            int a = ab[0];
            int b = ab[1];
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            var dp = new int[a+1, b+1];
            //aをi個目から,bをj個目から開始したときの先攻の得点
            for (int i = 0; i < a + 1; i++)
                for (int j = 0; j < b + 1; j++)
                    dp[i, j] = -1;
            int all = a + b;

            Console.WriteLine(dp[a, b]);
        }

        static void DFS(ref int[,] dp,int aNow,int bNow)
        {
            if (aNow == dp.GetLength(0)
                &&bNow==dp.GetLength(1))
            {
                dp[aNow, bNow] = 0;
                return;
            }
            if (aNow == dp.GetLength(0))
            {

            }
            
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
