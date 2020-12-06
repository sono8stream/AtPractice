using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_110
{
    class B
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
            string t = Read();
            long all = 10000000000;
            if (t == "1")
            {
                WriteLine(all * 2);
                return;
            }
            string pat = "110";
            for(int i = 0; i < 3; i++)
            {
                bool ok = true;
                for(int j = 0; j < n; j++)
                {
                    if (t[j] == pat[(i + j) % 3])
                    {
                        continue;
                    }
                    else
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    long use = (i + n) / 3;
                    if ((i + n) % 3 > 0)
                    {
                        use++;
                    }
                    WriteLine(all - use + 1);
                    return;
                }
            }
            WriteLine(0);
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
