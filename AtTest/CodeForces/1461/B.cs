using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1461
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
                bool[,] grid = new bool[n, m];
                for(int j = 0; j < n; j++)
                {
                    string row = Read();
                    for(int k = 0; k < m; k++)
                    {
                        grid[j, k] = row[k] == '*';
                    }
                }

                int[,] lefts = new int[n, m];
                for (int j = 0; j < n; j++)
                {
                    int left = -1;
                    for (int k = 0; k < m; k++)
                    {
                        if (grid[j, k])
                        {
                            if (left == -1)
                            {
                                lefts[j, k] = 1;
                                left = k;
                            }
                            else
                            {
                                lefts[j, k] = k - left + 1;
                            }
                        }
                        else
                        {
                            left = -1;
                        }
                    }
                }
                int[,] rights = new int[n, m];
                for (int j = 0; j < n; j++)
                {
                    int right = -1;
                    for (int k = m-1; k >=0; k--)
                    {
                        if (grid[j, k])
                        {
                            if (right == -1)
                            {
                                rights[j, k] = 1;
                                right = k;
                            }
                            else
                            {
                                rights[j, k] = right-k + 1;
                            }
                        }
                        else
                        {
                            right = -1;
                        }
                    }
                }

                int[,] maxHeights = new int[n, m];
                int res = 0;
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < m; k++)
                    {
                        int prev = j > 0 ? maxHeights[j - 1, k] : 0;
                        int len = Min(lefts[j, k], rights[j, k]);
                        maxHeights[j, k] = Min(prev + 1, len);
                        res += maxHeights[j, k];
                    }
                }

                WriteLine(res);
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
