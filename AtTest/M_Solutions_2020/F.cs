using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.M_Solutions_2020
{
    class F
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
            int[][] xyus = new int[n][];
            for(int i = 0; i < n; i++)
            {
                string[] input = Read().Split();
                xyus[i] = new int[3] { int.Parse(input[0]), int.Parse(input[1]), 0 };
                if (input[2][0] == 'R')
                {
                    xyus[i][2] = 1;
                }
                if (input[2][0] == 'D')
                {
                    xyus[i][2] = 2;
                }
                if (input[2][0] == 'L')
                {
                    xyus[i][2] = 3;
                }
            }

            List<int[]> uxs = new List<int[]>();
            List<int[]> dxs = new List<int[]>();
            List<int[]> rys = new List<int[]>();
            List<int[]> lys = new List<int[]>();

            List<int[]> uxxs = new List<int[]>();
            List<int[]> dxxs = new List<int[]>();
            List<int[]> ryys = new List<int[]>();
            List<int[]> lyys = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                if (xyus[i][2] == 0)
                {
                    rys.Add(new int[2] { xyus[i][0] + xyus[i][1], i });
                    lys.Add(new int[2] { 200000 - xyus[i][0] + xyus[i][1], i });
                    uxxs.Add(new int[2] { xyus[i][0], i });
                }
                if (xyus[i][2] == 1)
                {
                    uxs.Add(new int[2] { xyus[i][1] + xyus[i][0], i });
                    dxs.Add(new int[2] { 200000 - xyus[i][1] + xyus[i][0], i });
                    ryys.Add(new int[2] { xyus[i][1], i });
                }
                if (xyus[i][2] == 2)
                {
                    rys.Add(new int[2] { xyus[i][0] - xyus[i][1], i });
                    lys.Add(new int[2] { 200000 - xyus[i][0] - xyus[i][1], i });
                    dxxs.Add(new int[2] { xyus[i][0], i });
                }
                if (xyus[i][2] == 3)
                {
                    uxs.Add(new int[2] { xyus[i][1] - xyus[i][0], i });
                    dxs.Add(new int[2] { 200000 - xyus[i][1] - xyus[i][0], i });
                    lyys.Add(new int[2] { xyus[i][1], i });
                }
            }

            uxs = uxs.OrderBy(a => a[0]).ToList();
            dxs = dxs.OrderBy(a => a[0]).ToList();
            rys = rys.OrderBy(a => a[0]).ToList();
            lys = lys.OrderBy(a => a[0]).ToList();

            uxxs = uxxs.OrderBy(a => a[0]).ToList();
            dxxs = dxxs.OrderBy(a => a[0]).ToList();
            ryys = ryys.OrderBy(a => a[0]).ToList();
            lyys = lyys.OrderBy(a => a[0]).ToList();

            int res = int.MaxValue;
            for(int i = 0; i < n; i++)
            {
                if (xyus[i][2] == 0)
                {
                    int idx = BinarySearch(dxxs, xyus[i][0]);
                    if (idx >= 0 && xyus[i][1] < xyus[dxxs[idx][1]][1])
                    {
                        int hoge = xyus[dxxs[idx][1]][1];
                        res = Min(res, (xyus[dxxs[idx][1]][1] - xyus[i][1]) * 5);
                    }
                    idx = BinarySearch(uxs, xyus[i][1] + xyus[i][0]);
                    if (idx >= 0)
                    {
                        while (idx >= 0 && uxs[idx][0] == xyus[i][1] + xyus[i][0])
                        {
                            if (xyus[i][1] < xyus[uxs[idx][1]][1])
                            {
                                res = Min(res, (xyus[uxs[idx][1]][1] - xyus[i][1]) * 10);
                            }
                            idx--;
                        }
                    }
                }
                if (xyus[i][2] == 1)
                {
                    int idx = BinarySearch(lyys, xyus[i][1]);
                    if (idx >= 0 && xyus[i][0] < xyus[lyys[idx][1]][0])
                    {
                        res = Min(res, (xyus[lyys[idx][1]][0] - xyus[i][0]) * 5);
                    }
                    idx = BinarySearch(rys, xyus[i][0] + xyus[i][1]);
                    if (idx >= 0)
                    {
                        while (idx >= 0 && rys[idx][0] == xyus[i][0] + xyus[i][1])
                        {
                            if (xyus[i][0] < xyus[rys[idx][1]][0])
                            {
                                res = Min(res, (xyus[rys[idx][1]][0] - xyus[i][0]) * 10);
                            }
                            idx--;
                        }
                    }
                }
                if (xyus[i][2] == 2)
                {
                    int idx = BinarySearch(uxxs, xyus[i][0]);
                    if (idx >= 0 && xyus[i][1] > xyus[uxxs[idx][1]][1])
                    {
                        res = Min(res, (xyus[i][1] - xyus[uxxs[idx][1]][1]) * 5);
                    }
                    idx = BinarySearch(dxs, 200000-xyus[i][1] + xyus[i][0]);
                    if (idx >= 0)
                    {
                        while (idx >= 0 && dxs[idx][0] == 200000-xyus[i][1] + xyus[i][0])
                        {
                            if (xyus[i][1] > xyus[uxs[idx][1]][1])
                            {
                                res = Min(res, (xyus[i][1] - xyus[dxs[idx][1]][1]) * 10);
                            }
                            idx--;
                        }
                    }
                }
                if (xyus[i][2] == 3)
                {
                    int idx = BinarySearch(ryys, xyus[i][1]);
                    if (idx >= 0 && xyus[i][0] > xyus[ryys[idx][1]][0])
                    {
                        res = Min(res, (xyus[i][0] - xyus[ryys[idx][1]][0]) * 5);
                    }
                    idx = BinarySearch(lys, 200000 - xyus[i][0] + xyus[i][1]);
                    if (idx >= 0)
                    {
                        while (idx >= 0 && lys[idx][0] == xyus[i][0] + xyus[i][1])
                        {
                            if (xyus[i][0] > xyus[rys[idx][1]][0])
                            {
                                res = Min(res, (xyus[i][0] - xyus[lys[idx][1]][0]) * 10);
                            }
                            idx--;
                        }
                    }
                }
            }

            if (res == int.MaxValue)
            {
                WriteLine("SAFE");
            }
            else
            {
                WriteLine(res);
            }
        }

        static int BinarySearch(List<int[]> list,int val)
        {
            if (list.Count == 0)
            {
                return -1;
            }

            if (val < list[0][0] && val > list[list.Count - 1][0])
            {
                return -1;
            }

            int bottom = 0;
            int top = list.Count;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                if (list[mid][0] <= val)
                {
                    bottom = mid;
                }
                else
                {
                    top = mid;
                }
            }

            if (list[bottom][0] == val)
            {
                return bottom;
            }
            else
            {
                return -1;
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
