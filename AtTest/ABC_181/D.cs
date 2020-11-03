using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_181
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
            int[] cnts = new int[10];
            for(int i = 0; i < s.Length; i++)
            {
                cnts[s[i] - '0']++;
            }

            for(int i = 8; i < 1000; i += 8)
            {
                int[] cnt = new int[10];
                int now = i;
                int dig = 0;
                while (now > 0)
                {
                    cnt[now % 10]++;
                    now /= 10;
                    dig++;
                }

                bool ok = true;
                for(int j = 0; j < 10; j++)
                {
                    if (cnts[j] < cnt[j])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok && (dig == 3 || dig == s.Length))
                {
                    WriteLine("Yes");
                    return;
                }
            }

            WriteLine("No");
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
