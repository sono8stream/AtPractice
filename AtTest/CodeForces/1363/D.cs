using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1363
{
    class D
    {
        static void ain(string[] args)
        {
            //var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            //SetOut(sw);

            Method(args);

            //Out.Flush();
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                int[] nk = ReadInts();
                int n = nk[0];
                int k = nk[1];
                var sets = new HashSet<int>[n];
                for(int j = 0; j < k; j++)
                {
                    int[] vals = ReadInts();
                    sets[j] = new HashSet<int>();
                    for(int l = 1; l < vals.Length; l++)
                    {
                        sets[j].Add(vals[l]);
                    }
                }

                Write("? " + n);
                for(int j = 1;j<= n; j++)
                {
                    Write(" " + j);
                }
                WriteLine();
                int max = ReadInt();
                int bottom = 0;
                int top = n - 1;
                while (bottom < top)
                {
                    int mid = (bottom + top) / 2;
                    Write("? "+(mid-bottom+1));
                    for(int j = bottom + 1; j <= mid + 1; j++)
                    {
                        Write(" " + j);
                    }
                    WriteLine();
                    int now = ReadInt();
                    if (now == max)
                    {
                        top = mid;
                    }
                    else
                    {
                        bottom = mid + 1;
                    }
                }

                int maxIdx = bottom;
                int maxContainsIdx = 0;
                for (; maxContainsIdx < k; maxContainsIdx++)
                {
                    if (sets[maxContainsIdx].Contains(maxIdx + 1))
                    {
                        break;
                    }
                }
                int secondMax;
                if (maxContainsIdx < k)
                {
                    Write("? " + (n - sets[maxContainsIdx].Count));
                    for (int j = 1; j <= n; j++)
                    {
                        if (!sets[maxContainsIdx].Contains(j))
                        {
                            Write(" " + j);
                        }
                    }
                    WriteLine();
                    secondMax = ReadInt();
                }
                else
                {
                    secondMax = max;
                }
                Write("! ");
                for(int j = 0; j < k; j++)
                {
                    if (j == maxContainsIdx)
                    {
                        Write(" " + secondMax);
                    }
                    else
                    {
                        Write(" " + max);
                    }
                }
                WriteLine();
                ReadLine();
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
