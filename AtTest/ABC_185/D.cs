using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_185
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            if (m == 0)
            {
                Read();
                WriteLine(1);
                return;
            }
            int[] array = ReadInts();
            Array.Sort(array);
            int minBlock = n;
            int left = 0;
            List<int> blocks = new List<int>();
            for(int i = 0; i < m; i++)
            {
                int len = array[i] - left - 1;
                left = array[i];
                if (len == 0)
                {
                    continue;
                }

                minBlock = Min(minBlock, len);
                blocks.Add(len);
            }
            int lastLen = n - left;
            if (lastLen > 0)
            {
                minBlock = Min(minBlock, lastLen);
                blocks.Add(lastLen);
            }

            int res = 0;
            for(int i = 0; i < blocks.Count; i++)
            {
                int tmp = blocks[i] / minBlock;
                if (blocks[i] % minBlock > 0)
                {
                    tmp++;
                }
                res += tmp;
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
