using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1435
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
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];

                int[][] rows = new int[n][];
                var hashes = new HashSet<int>[n];
                for(int j= 0; j < n; j++)
                {
                    hashes[j] = new HashSet<int>();
                    rows[j] = ReadInts();
                    for(int k = 0; k < m; k++)
                    {
                        hashes[j].Add(rows[j][k]);
                    }
                }

                int[,] res = new int[n, m];
                for(int j = 0; j < m; j++)
                {
                    int[] col = ReadInts();
                    if (j == 0)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            for(int l = 0; l < n; l++)
                            {
                                if (hashes[l].Contains(col[k]))
                                {
                                    for(int o = 0; o < m; o++)
                                    {
                                        res[k, o] = rows[l][o];
                                    }
                                }
                            }
                        }
                    }
                }

                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < m; k++)
                    {
                        Write(res[j, k]);

                        if (k + 1 < m)
                        {
                            Write(' ');
                        }
                    }
                    WriteLine();
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
