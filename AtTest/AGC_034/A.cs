using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_034
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nabcd = ReadInts();
            int n = nabcd[0];
            int a = nabcd[1]-1;
            int b = nabcd[2]-1;
            int c = nabcd[3]-1;
            int d = nabcd[4]-1;
            string s = Read();

            int notSeqCnt = 0;
            int nowNotCnt = 0;
            for(int i = a; i <= Max(c,d); i++)
            {
                if (s[i] == '.')
                {
                    nowNotCnt = 0;
                }
                else
                {
                    nowNotCnt++;
                    notSeqCnt = Max(notSeqCnt, nowNotCnt);
                }
            }

            if (notSeqCnt > 1)
            {
                WriteLine("No");
                return;
            }

            if (c < d)
            {
                WriteLine("Yes");
                return;
            }

            int canSeqCnt = 0;
            int nowCanCnt = 0;
            for (int i = b - 1; i <= d + 1; i++)
            {
                if (s[i] == '.')
                {
                    nowCanCnt++;
                    canSeqCnt = Max(canSeqCnt, nowCanCnt);
                }
                else
                {
                    nowCanCnt = 0;
                }
            }
            if (canSeqCnt >= 3)
            {
                WriteLine("Yes");
            }
            else WriteLine("No");
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
