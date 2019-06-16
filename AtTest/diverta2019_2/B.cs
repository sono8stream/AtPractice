using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.diverta2019_2
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[][] poses = new long[n][];
            for(int i = 0; i < n; i++)
            {
                poses[i] = ReadLongs();
            }
            poses = poses.OrderBy(a => a[1]).OrderBy(a => a[0]).ToArray();
            if (n == 1)
            {
                WriteLine(1);
                return;
            }

            int res = int.MaxValue;
            for(int i = 0; i < n; i++)
            {
                for(int j = i + 1; j < n; j++)
                {
                    long dx = poses[j][0] - poses[i][0];
                    long dy = poses[j][1] - poses[i][1];

                    bool[] used = new bool[n];
                    int tmp = 0;
                    for(int k = 0; k < n; k++)
                    {
                        if (used[k]) continue;
                        tmp++;
                        int now = 1;
                        for (int l = k+1; l < n; l++)
                        {
                            long ddx = poses[l][0] - poses[k][0];
                            long ddy = poses[l][1] - poses[k][1];
                            if (dx == 0)
                            {
                                if (ddx == 0 && ddy % dy == 0 && ddy / dy == now)
                                {
                                    used[l] = true;
                                    now++;
                                }
                            }
                            else if (dy == 0)
                            {
                                if (ddy == 0 && ddx % dx == 0 && ddx / dx == now)
                                {
                                    used[l] = true;
                                    now++;
                                }
                            }
                            else
                            {
                                if (ddx % dx == 0 && ddy % dy == 0
                              && ddx / dx == ddy / dy && ddx / dx == now)
                                {
                                    used[l] = true;
                                    now++;
                                }
                            }
                        }
                    }
                    res = Min(res, tmp);
                }
            }

            WriteLine(res);
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }

        static long LCM(long a, long b)
        {
            long c = GCD(a, b);
            return a * b / c;
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
