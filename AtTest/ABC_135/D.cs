using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_135
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
            int[] mods = new int[s.Length];
            mods[0] = 1;
            for(int i = 1; i < s.Length; i++)
            {
                mods[i] = (mods[i - 1] * 10) % 13;
            }
            Array.Reverse(mods);
            long mask = 1000000000 + 7;
            long defaultMod = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '?') continue;

                defaultMod += mods[i] * (s[i] - '0');
                defaultMod %= 13;
            }
            long[] cnts = new long[13];
            cnts[defaultMod] = 1;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] != '?') continue;

                long[] next = new long[13];
                for(int j = 0; j < 10; j++)
                {
                    int delta = mods[i] * j;
                    for(int k = 0; k < 13; k++)
                    {
                        next[(k + delta) % 13] += cnts[k];
                        next[(k + delta) % 13] %= mask;
                    }
                }
                cnts = next;
            }

            WriteLine(cnts[5]);
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
