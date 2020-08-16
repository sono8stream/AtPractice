using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1379
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
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];
                int[][] abs = new int[m][];
                for(int j = 0; j < m; j++)
                {
                    abs[j] = ReadInts();
                }
                Array.Sort(abs, (a, b) => b[0] - a[0]);
                ReadLine();

                long[] sums = new long[m];
                for(int j = 0; j < m; j++)
                {
                    sums[j] = abs[j][0];
                    if (j > 0)
                    {
                        sums[j] += sums[j - 1];
                    }
                }

                long res = 0;
                for(int j = 0; j < m; j++)
                {
                    long tmp;
                    if (abs[j][1] >= abs[0][0])
                    {
                        tmp = abs[j][0] + (long)abs[j][1] * (n - 1);
                    }
                    else
                    {
                        int bottom = 0;
                        int top = m;
                        while (bottom + 1 < top)
                        {
                            int mid = (bottom + top) / 2;
                            if (abs[j][1] < abs[mid][0])
                            {
                                bottom = mid;
                            }
                            else
                            {
                                top = mid;
                            }
                        }

                        bottom = Min(bottom, n - 1);
                        if (bottom >= j)
                        {
                            tmp = sums[bottom];
                            tmp += (long)abs[j][1] * (n - bottom - 1);
                        }
                        else
                        {
                            tmp = abs[j][0];
                            if (bottom == n - 1)
                            {
                                bottom--;
                            }
                            if (bottom >= 0)
                            {
                                tmp += sums[bottom];
                                tmp += (long)abs[j][1] * (n - bottom - 2);
                            }
                        }
                    }
                    
                    res = Max(res, tmp);
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
