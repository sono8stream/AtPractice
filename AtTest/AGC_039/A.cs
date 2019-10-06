using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_039
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
            long k = ReadLong();

            List<long> blocks = new List<long>();
            blocks.Add(1);
            for(int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    blocks[blocks.Count - 1]++;
                }
                else
                {
                    blocks.Add(1);
                }
            }

            if (blocks.Count == 1)
            {
                WriteLine(blocks[0] * k / 2);
            }
            else if (s[s.Length - 1] == s[0])
            {
                long cnt = 0;
                cnt += blocks[0] / 2;
                for (int i = 1; i < blocks.Count - 1; i++) cnt += blocks[i] / 2 * k;
                cnt += (blocks[0] + blocks[blocks.Count - 1])/2 * (k - 1);
                cnt += blocks[blocks.Count - 1] / 2;
                WriteLine(cnt);
            }
            else
            {
                long cnt = 0;
                for (int i = 0; i < blocks.Count; i++) cnt += blocks[i] / 2 * k;
                WriteLine(cnt);
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
