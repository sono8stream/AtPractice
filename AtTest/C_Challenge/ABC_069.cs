using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_069
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
            int fourCnt=0;
            int twoCnt=0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] % 4 == 0)
                {
                    fourCnt++;
                }
                else if (array[i] % 2 == 0)
                {
                    twoCnt++;
                }
            }
            if (fourCnt >= n / 2)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                int remain = n - fourCnt * 2;
                if (2 <= remain && remain <= twoCnt)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
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
