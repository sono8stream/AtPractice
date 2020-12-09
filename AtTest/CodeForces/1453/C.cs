using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1453
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[,] grid = new int[n, n];
                for(int j = 0; j < n; j++)
                {
                    string row = Read();
                    for(int k = 0; k < n; k++)
                    {
                        grid[j, k] = row[k] - '0';
                    }
                }

                // minY,maxY,minX,maxX
                int[,] minMaxs = new int[10, 4];
                for(int j = 0; j < 10; j++)
                {
                    minMaxs[j, 0] = -1;
                    minMaxs[j, 1] = -1;
                    minMaxs[j, 2] = -1;
                    minMaxs[j, 3] = -1;
                }
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        int now = grid[j, k];
                        if (minMaxs[now, 0] == -1)
                        {
                            minMaxs[now, 0] = j;
                            minMaxs[now, 1] = j;
                            minMaxs[now, 2] = k;
                            minMaxs[now, 3] = k;
                        }
                        else
                        {
                            minMaxs[now, 0] = Min(minMaxs[now, 0], j);
                            minMaxs[now, 1] = Max(minMaxs[now, 1], j);
                            minMaxs[now, 2] = Min(minMaxs[now, 2], k);
                            minMaxs[now, 3] = Max(minMaxs[now, 3], k);
                        }
                    }
                }

                int[] res = new int[10];
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        int now = grid[j, k];
                        int horHeight = Max(Abs(k - minMaxs[now, 2]), Abs(k - minMaxs[now, 3]));
                        int verHeight = Max(Abs(j - minMaxs[now, 0]), Abs(j - minMaxs[now, 1]));
                        res[now] = Max(res[now], horHeight * Max(j, n - 1 - j));
                        res[now] = Max(res[now], verHeight * Max(k, n - 1 - k));
                    }
                }

                for(int j = 0; j < 10; j++)
                {
                    Write(res[j]);
                    if (j + 1 < 10)
                    {
                        Write(" ");
                    }
                }
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
