using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_037
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
            string s = Read();
            int cnt = 0;
            bool nowDouble = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (nowDouble)
                {
                    nowDouble = false;
                    cnt++;
                }
                else
                {
                    if (s[i] == s[i - 1])
                    {
                        nowDouble = true;
                        if (i < s.Length - 1) cnt++;
                        i++;
                    }
                    else
                    {
                        cnt++;
                    }
                }
            }
            WriteLine(cnt);
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
