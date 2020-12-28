using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1136
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
            int[,] a = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                int[] row = ReadInts();
                for(int j = 0; j < m; j++)
                {
                    a[i, j] = row[j];
                }
            }
            int[,] b = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int[] row = ReadInts();
                for (int j = 0; j < m; j++)
                {
                    b[i, j] = row[j];
                }
            }

            for(int i = 0; i < n + m - 1; i++)
            {
                List<int> aLine= new List<int>();
                List<int> bLine = new List<int>();
                int y = i < m ? 0 : i - m + 1;
                int x = i < m ? i : m - 1;
                while (x >= 0 && y < n)
                {
                    aLine.Add(a[y, x]);
                    bLine.Add(b[y, x]);
                    x--;
                    y++;
                }

                aLine.Sort();
                bLine.Sort();
                for(int j = 0; j < aLine.Count; j++)
                {
                    if (aLine[j] == bLine[j])
                    {
                        continue;
                    }
                    else
                    {
                        WriteLine("NO");
                        return;
                    }
                }
            }

            WriteLine("YES");
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
