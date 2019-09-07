using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_140
{
    class F
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
            int[] ss = ReadInts();
            Array.Sort(ss);
            Array.Reverse(ss);
            List<int> blocks = new List<int>();
            blocks.Add(1);
            for (int i = 1; i < ss.Length; i++)
            {
                if (ss[i] == ss[i - 1])
                {
                    blocks[blocks.Count - 1]++;
                }
                else
                {
                    blocks.Add(1);
                }
            }
            if (blocks[0] > 1)
            {
                WriteLine("No");
                return;
            }
            int[] cnts = new int[n];
            for (int i = 0; i < n; i++) cnts[i] = 1;
            for (int i = 1; i < blocks.Count; i++)
            {
                int[] next = new int[n];
                int current = 0;
                for (int j = 0; j < blocks[i]; j++)
                {
                    while (cnts[current] == 0)
                    {
                        current++;
                        if (current >= n)
                        {
                            WriteLine("No");
                            return;
                        }
                    }
                    cnts[current]--;
                    for (int k = current + 1; k < n; k++) next[k]++;
                }
                for (int j = 0; j < n; j++) cnts[j] += next[j];
            }
            WriteLine("Yes");
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
