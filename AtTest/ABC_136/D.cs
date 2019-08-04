using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_136
{
    class D
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
            int[] res = new int[s.Length];
            int odd = 0;
            int even = 0;
            for(int i = 0; i < s.Length; i++)
            {
                int tmp = odd;
                odd = even;
                even = tmp;
                if (s[i] == 'L')
                {
                    res[i - 1] += odd;
                    res[i] += even;
                    odd = 0;
                    even = 0;
                }
                else
                {
                    even++;
                }
            }
            for (int i = s.Length-1; i >=0; i--)
            {
                int tmp = odd;
                odd = even;
                even = tmp;
                if (s[i] == 'R')
                {
                    res[i + 1] += odd;
                    res[i] += even;
                    odd = 0;
                    even = 0;
                }
                else
                {
                    even++;
                }
            }

            for(int i = 0; i < s.Length; i++)
            {
                Write(res[i]);
                if (i < s.Length - 1) Write(" ");
            }
            WriteLine();
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
