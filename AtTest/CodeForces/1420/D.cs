using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1420
{
    class D
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
            for (int i = 0; i < t; i++)
            {
                int[] nq = ReadInts();
                int n = nq[0];
                int q = nq[1];
                long[] array = ReadLongs();
                int[][] lrs = new int[q][];
                for(int j = 0; j < q; j++)
                {
                    lrs[j] = ReadInts();
                }

                long[] neoArray = new long[n + 2];
                for (int j = 0; j < n; j++)
                {
                    neoArray[j + 1] = array[j];
                }
                long now = 0;
                for(int j = 1; j < neoArray.Length; j++)
                {
                    if (neoArray[j - 1] < neoArray[j])
                    {
                        now += neoArray[j] - neoArray[j - 1];
                    }
                }
                WriteLine(now);

                for(int j = 0; j < q; j++)
                {
                    int lI = lrs[j][0];
                    int rI = lrs[j][1];
                    long l = neoArray[lI];
                    long r = neoArray[rI];

                    if (lI + 1 == rI)
                    {
                        if (neoArray[lI - 1] < l)
                        {
                            now -= l - neoArray[lI - 1];
                        }
                        if (neoArray[lI + 1] > l)
                        {
                            now -= neoArray[lI + 1] - l;
                        }
                        if (neoArray[rI + 1] > r)
                        {
                            now -= neoArray[rI + 1] - r;
                        }
                        neoArray[lI] = r;
                        neoArray[rI] = l;

                        if (neoArray[lI - 1] < r)
                        {
                            now += r - neoArray[lI - 1];
                        }
                        if (neoArray[lI + 1] > r)
                        {
                            now += neoArray[lI + 1] - r;
                        }
                        if (neoArray[rI + 1] > l)
                        {
                            now += neoArray[rI + 1] - l;
                        }
                    }
                    else
                    {
                        if (neoArray[lI - 1] < l)
                        {
                            now -= l - neoArray[lI - 1];
                        }
                        if (neoArray[lI + 1] > l)
                        {
                            now -= neoArray[lI + 1] - l;
                        }
                        if (neoArray[rI - 1] < r)
                        {
                            now -= r - neoArray[rI - 1];
                        }
                        if (neoArray[rI + 1] > r)
                        {
                            now -= neoArray[rI + 1] - r;
                        }

                        if (neoArray[lI - 1] < r)
                        {
                            now += r - neoArray[lI - 1];
                        }
                        if (neoArray[lI + 1] > r)
                        {
                            now += neoArray[lI + 1] - r;
                        }
                        if (neoArray[rI - 1] < l)
                        {
                            now += l - neoArray[rI - 1];
                        }
                        if (neoArray[rI + 1] > l)
                        {
                            now += neoArray[rI + 1] - l;
                        }
                        neoArray[lI] = r;
                        neoArray[rI] = l;
                    }

                    WriteLine(now);
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
