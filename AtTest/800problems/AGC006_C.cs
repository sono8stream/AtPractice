using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._800problems
{
    class AGC006_C
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
            long[] xs = ReadLongs();
            long[] mk = ReadLongs();
            long m = mk[0];
            long k = mk[1];
            int[] array = ReadInts();
            long[] deltas = new long[n - 1];
            for(int i = 0; i < n-1; i++)
            {
                deltas[i] = xs[i + 1] - xs[i];
            }
            int[][] swaps = new int[100][];
            swaps[0] = new int[n - 1];
            for(int i = 0; i < n-1; i++)
            {
                swaps[0][i] = i;
            }
            for(int i = 0; i < m; i++)
            {
                int left = array[i] - 2;
                int right = left + 1;
                int tmp = swaps[0][left];
                swaps[0][left] = swaps[0][right];
                swaps[0][right] = tmp;
            }
            for(int i = 1; i < 100; i++)
            {
                swaps[i] = new int[n - 1];
                for(int j = 0; j < n-1; j++)
                {
                    swaps[i][j] = swaps[i - 1][swaps[i - 1][j]];
                }
            }

            int[] kSwap = new int[n - 1];
            for (int i = 0; i < n - 1; i++) kSwap[i] = i;
            long cnt = 1;
            int pow = 0;
            while (cnt<=k)
            {
                if ((k & cnt)>0)
                {
                    int[] next = new int[n - 1];
                    for(int i = 0; i < n - 1; i++)
                    {
                        next[i] = kSwap[swaps[pow][i]];
                    }
                    kSwap = next;
                }
                cnt *= 2;
                pow++;
            }

            WriteLine(xs[0]);
            long now = xs[0];
            for(int i = 0; i < n - 1; i++)
            {
                now += deltas[kSwap[i]];
                WriteLine(now);
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
