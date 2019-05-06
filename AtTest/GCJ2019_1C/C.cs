using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2019_1C
{
    class C
    {
        static int[] winOrNot;

        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            Action[] res = new Action[t];
            winOrNot = new int[(int)Pow(3, 16)];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int[] rc = ReadInts();
            int r = rc[0];
            int c = rc[1];
            int all = (int)Pow(3, r * c);
            for (int i = 0; i < all; i++) winOrNot[i] = -1;
            int status = 0;
            int div = 1;
            for(int i = 0; i < r; i++)
            {
                string s = Read();
                for(int j = 0; j < c; j++)
                {
                    int val = s[j] == '.' ? 0 : 1;
                    status += val * div;
                    div *= 3;
                }
            }
            int cnt =  DFS(r, c, status, ref winOrNot);
            return () => WriteLine(cnt);
        }

        static int DFS(int r,int c,int status,ref int[] winOrNot)
        {
            if (winOrNot[status] >= 0) return winOrNot[status];

            int ret = 0;
            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    bool puttable = true;
                    int status2 = status;
                    for(int k = i; k >= 0; k--)
                    {
                        int value = (status / (int)Pow(3, k * c + j + 1)) % 3;
                        if (value == 0)
                        {
                            status2 = (-value + 2) * (int)Pow(3, k * c + j);
                            continue;
                        }
                        if (value == 1)
                        {
                            puttable = false;
                            break;
                        }
                        if (value == 2)
                        {
                            break;
                        }
                    }
                    if (puttable)
                    {
                        for (int k = i; k < r; k++)
                        {
                            int value = (status / (int)Pow(3, k * c + j + 1)) % 3;
                            if (value == 0)
                            {
                                status2 = (-value + 2) * (int)Pow(3, k * c + j);
                                continue;
                            }
                            if (value == 1)
                            {
                                puttable = false;
                                break;
                            }
                            if (value == 2)
                            {
                                break;
                            }
                        }
                    }
                    if (puttable)
                    {
                        ret += DFS(r, c, status2, ref winOrNot) > 0 ? 1 : 0;
                    }
                    puttable = true;
                    status2 = status;
                    for (int k = j; k >= 0; k--)
                    {
                        int value = (status / (int)Pow(3, i * c + k + 1)) % 3;
                        if (value == 0)
                        {
                            status2 = (-value + 2) * (int)Pow(3, i * c + k);
                            continue;
                        }
                        if (value == 1)
                        {
                            puttable = false;
                            break;
                        }
                        if (value == 2)
                        {
                            break;
                        }
                    }
                    for (int k = i; k <c; k++)
                    {
                        int value = (status / (int)Pow(3, i * c + k + 1)) % 3;
                        if (value == 0)
                        {
                            status2 = (-value + 2) * (int)Pow(3, i * c + k);
                            continue;
                        }
                        if (value == 1)
                        {
                            puttable = false;
                            break;
                        }
                        if (value == 2)
                        {
                            break;
                        }
                    }
                    if (puttable)
                    {
                        ret += DFS(r, c, status2, ref winOrNot) > 0 ? 1 : 0;
                    }
                }
            }
            winOrNot[status] = ret;
            return ret;
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
