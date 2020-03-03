using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_157
{
    class C
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
            int?[] nums = new int?[n];
            int[][] scs = new int[m][];
            for(int i = 0; i < m; i++)
            {
                scs[i] = ReadInts();
            }

            for(int i = 0; i < m; i++)
            {
                int s = scs[i][0] - 1;
                int c = scs[i][1];
                if (nums[s] == null)
                {
                    nums[s] = c;
                }
                else if(nums[s]!=c)
                {
                    WriteLine(-1);
                    return;
                }
            }
            if (n > 1 & nums[0] == 0)
            {
                WriteLine(-1);
                return;
            }

            if (n==1)
            {
                Write(nums[0] ?? 0);
            }
            else
            {
                Write(nums[0] ?? 1);
            }

            for(int i = 1; i < n; i++)
            {
                Write(nums[i] ?? 0);
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
