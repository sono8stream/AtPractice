using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1451
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] nq = ReadInts();
                int n = nq[0];
                int q = nq[1];
                string s = Read();
                bool[,] left = new bool[n, 2];
                bool[,] right = new bool[n, 2];
                for(int j = 0; j < n; j++)
                {
                    left[j, s[j] - '0'] = true;
                    if (j > 0)
                    {
                        left[j, 0] |= left[j - 1, 0];
                        left[j, 1] |= left[j - 1, 1];
                    }
                }
                for (int j = n - 1; j >= 0; j--)
                {
                    right[j, s[j] - '0'] = true;
                    if (j + 1 < n)
                    {
                        right[j, 0] |= right[j + 1, 0];
                        right[j, 1] |= right[j + 1, 1];
                    }
                }

                for (int j = 0; j < q; j++)
                {
                    int[] lr = ReadInts();
                    int l = lr[0] - 1;
                    int r = lr[1] - 1;
                    int top = s[l] == '1' ? 1 : 0;
                    int bottom = s[r] == '1' ? 1 : 0;
                    if ((l > 0 && left[l - 1, top]) || (r + 1 < n && right[r + 1, bottom]))
                    {
                        WriteLine("YES");
                    }
                    else
                    {
                        WriteLine("NO");
                    }
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
