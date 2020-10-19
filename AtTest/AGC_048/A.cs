using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_048
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
            int t = ReadInt();
            string atc = "atcoder";
            for(int i = 0; i < t; i++)
            {
                string s = Read();
                if (s.CompareTo(atc) > 0)
                {
                    WriteLine(0);
                    continue;
                }

                bool ok = false;
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] != 'a')
                    {
                        ok = true;
                        WriteLine(s[j] <= 't' ? j : j - 1);
                        break;
                    }
                }

                if (!ok)
                {
                    WriteLine(-1);
                }
            }
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
