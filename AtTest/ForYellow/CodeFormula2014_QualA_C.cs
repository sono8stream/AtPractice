using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class CodeFormula2014_QualA_C
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            bool[] win = new bool[1000000];
            int[][] arrays = new int[n][];
            bool[][] check= new bool[n][];
            int lim = k;
            for(int i = 0; i < n; i++)
            {
                arrays[i] = ReadInts();
                check[i] = new bool[k];
            }
            for (int i = 0; i < n; i++)
            {
                List<int> winners = new List<int>();
                int tmp = 0;
                while (tmp < lim)
                {
                    int y = tmp % n;
                    int x = tmp / n;
                    if (check[y][x])
                    {
                    }
                    else if (win[arrays[y][x]])
                    {
                        check[y][x] = true;
                        lim++;
                    }
                    else
                    {
                        check[y][x] = true;
                        win[arrays[y][x]] = true;
                        winners.Add(arrays[y][x]);
                    }
                    tmp++;
                    if (tmp % n > i)
                    {
                        tmp += n - i - 1;
                    }
                }
                winners.Sort();
                winners.ForEach(id =>
                {
                    Write(id+" ");
                });
                WriteLine();
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
