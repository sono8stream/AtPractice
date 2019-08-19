using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_130
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[][] xys = new long[n][];
            char[] dirs = new char[n];
            for(int i = 0; i < n; i++)
            {
                string[] ss = Read().Split();
                xys[i] = new long[2] { int.Parse(ss[0]), int.Parse(ss[1]) };
                dirs[i] = ss[2][0];
            }

            List<long>[] poses = new List<long>[6];
            for (int i = 0; i < 6; i++) poses[i] = new List<long>();
            for(int i = 0; i < n; i++)
            {
                switch (dirs[i])
                {
                    case 'L':
                        poses[0].Add(xys[i][0]);
                        poses[5].Add(xys[i][1]);
                        break;
                    case 'R':
                        poses[1].Add(xys[i][0]);
                        poses[5].Add(xys[i][1]);
                        break;
                    case 'U':
                        poses[4].Add(xys[i][1]);
                        poses[2].Add(xys[i][0]);
                        break;
                    case 'D':
                        poses[3].Add(xys[i][1]);
                        poses[2].Add(xys[i][0]);
                        break;
                }
            }
            for(int i = 0; i < 6; i++)
            {
                poses[i].Sort();
            }
            List<double> times = new List<double>();
            times.Add(0);
            for (int i = 0; i < 6; i += 3) {
                if (poses[i].Count > 0 && poses[i + 1].Count > 0)
                {
                    if (poses[i][poses[i].Count - 1] 
                        > poses[i + 1][poses[i+1].Count-1])
                    {
                        times.Add((poses[i][poses[i].Count - 1]
                            - poses[i + 1][poses[i + 1].Count - 1]) * 0.5);
                    }
                    if (poses[i][0] > poses[i+1][0])
                    {
                        times.Add((poses[i][0]
                            - poses[i + 1][0]) * 0.5);
                    }
                }
                if (poses[i].Count > 0 && poses[i + 2].Count > 0)
                {
                    if (poses[i][poses[i].Count - 1]
                        > poses[i + 2][poses[i + 2].Count - 1])
                    {
                        times.Add(poses[i][poses[i].Count - 1]
                            - poses[i + 2][poses[i + 2].Count - 1]);
                    }
                    if (poses[i][0] > poses[i + 2][0])
                    {
                        times.Add(poses[i][0] - poses[i + 2][0]);
                    }
                }
                if (poses[i + 1].Count > 0 && poses[i + 2].Count > 0)
                {
                    if(poses[i+1][poses[i+1].Count-1]
                        < poses[i + 2][poses[i + 2].Count - 1])
                    {
                        times.Add(poses[i + 2][poses[i + 2].Count - 1]
                            - poses[i + 1][poses[i + 1].Count - 1]);
                    }
                    if (poses[i + 1][0] < poses[i + 2][0])
                    {
                        times.Add(poses[i + 2][0] - poses[i + 1][0]);
                    }
                }
            }
            double res = long.MaxValue;
            for(int i = 0; i < times.Count; i++)
            {
                double tmp = 1;
                for(int j = 0; j < 6; j += 3)
                {
                    double min = long.MaxValue;
                    double max = long.MinValue;
                    if (poses[j].Count > 0)
                    {
                        min = Min(min,poses[j][0] - times[i]);
                        max = Max(max,
                            poses[j][poses[j].Count - 1] - times[i]);
                    }
                    if (poses[j+1].Count > 0)
                    {
                        min = Min(min, poses[j+1][0] + times[i]);
                        max = Max(max,
                            poses[j+1][poses[j+1].Count - 1] + times[i]);
                    }
                    if (poses[j+2].Count > 0)
                    {
                        min = Min(min, poses[j+2][0]);
                        max = Max(max, poses[j+2][poses[j+2].Count - 1]);
                    }
                    tmp *= (max - min);
                }
                res = Min(res, tmp);
            }

            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            // Write output here
            WriteLine(res);

            Out.Flush();
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
