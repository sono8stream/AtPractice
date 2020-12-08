using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1409
{
    class E
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
                int[] nk = ReadInts();
                int n = nk[0];
                int k = nk[1];
                int[] xs = ReadInts();
                Array.Sort(xs);
                ReadInts();

                List<int[]> poses = new List<int[]>();
                for(int j = 0; j < n; j++)
                {
                    if (poses.Count == 0 || poses[poses.Count - 1][0] < xs[j])
                    {
                        poses.Add(new int[2] { xs[j], 1 });
                    }
                    else
                    {
                        poses[poses.Count - 1][1]++;
                    }
                }

                long[] accs = new long[poses.Count];
                for(int j = 0; j < poses.Count; j++)
                {
                    accs[j] = poses[j][1];
                    if (j > 0)
                    {
                        accs[j] += accs[j - 1];
                    }
                }

                long[] sums = new long[poses.Count];
                long[] maxSums = new long[poses.Count];
                long[] rights = new long[poses.Count];
                for(int j = poses.Count - 1; j >= 0; j--)
                {
                    int bottom = j;
                    int top = poses.Count;
                    while (bottom + 1 < top)
                    {
                        int mid = (bottom + top) / 2;
                        if (poses[mid][0] - poses[j][0] <= k)
                        {
                            bottom = mid;
                        }
                        else
                        {
                            top = mid;
                        }
                    }
                    sums[j] = accs[bottom];
                    if (j > 0)
                    {
                        sums[j] -= accs[j - 1];
                    }
                    rights[j] = bottom;
                    maxSums[j] = sums[j];
                    if (j + 1 < poses.Count)
                    {
                        maxSums[j] = Max(maxSums[j], maxSums[j + 1]);
                    }
                }

                long res = 0;
                for(int j = 0; j < poses.Count; j++)
                {
                    long sum = sums[j];
                    if (rights[j] + 1 < poses.Count)
                    {
                        sum += maxSums[rights[j] + 1];
                    }

                    res = Max(res, sum);
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
