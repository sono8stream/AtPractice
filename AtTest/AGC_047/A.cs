using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_047
{
    class A
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[,] cnts = new int[20, 20];
            long res = 0;
            for(int i = 0; i < n; i++)
            {
                int decimalCnt = -1;
                long val = 0;
                string valS = Read();
                for(int j = 0; j < valS.Length; j++)
                {
                    if (valS[j] == '.')
                    {
                        decimalCnt = 0;
                    }
                    else
                    {
                        if (decimalCnt >= 0)
                        {
                            decimalCnt++;
                        }
                        val = val * 10 + (valS[j] - '0');
                    }
                }
                if (decimalCnt < 0)
                {
                    decimalCnt++;
                }
                while (decimalCnt < 9)
                {
                    val *= 10;
                    decimalCnt++;
                }
                int twoI = 0;
                while (val % 2 == 0)
                {
                    val /= 2;
                    twoI++;
                }
                int fiveI = 0;
                while (val % 5 == 0)
                {
                    val /= 5;
                    fiveI++;
                }

                twoI = Min(twoI, 18);
                fiveI = Min(fiveI, 18);
                for(int j = 18 - twoI; j < 20; j++)
                {
                    for(int k = 18 - fiveI; k < 20; k++)
                    {
                        res += cnts[j, k];
                    }
                }

                cnts[twoI, fiveI]++;
            }

            WriteLine(res);
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
