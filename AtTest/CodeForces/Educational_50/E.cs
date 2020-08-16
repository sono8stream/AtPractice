using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces.Educational_50
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
            int n = ReadInt();
            int[][] lines = new int[n][];
            for (int i = 0; i < n; i++)
            {
                lines[i] = ReadInts();
                if ((lines[i][0] > lines[i][2])
                    || (lines[i][0] == lines[i][2]
                    && lines[i][1] > lines[i][3]))
                {
                    int tmp = lines[i][0];
                    lines[i][0] = lines[i][2];
                    lines[i][2] = tmp;
                    tmp = lines[i][1];
                    lines[i][1] = lines[i][3];
                    lines[i][3] = tmp;
                }
            }

            long res = 0;
            long[][] bases = new long[n][];
            for (int i = 0; i < n; i++)
            {
                long cnt;
                if (lines[i][0] == lines[i][2])
                {
                    cnt = Abs(lines[i][3] - lines[i][1]) + 1;
                    bases[i] = new long[2] { 0, 1 };
                }
                else if (lines[i][1] == lines[i][3])
                {
                    cnt = Abs(lines[i][2] - lines[i][0]) + 1;
                    bases[i] = new long[2] { 1, 0 };
                }
                else
                {
                    long gcd = GCD(Abs(lines[i][2] - lines[i][0]),
                    Abs(lines[i][3] - lines[i][1]));
                    cnt = gcd + 1;
                    bases[i] = new long[2] {
                        (lines[i][2]-lines[i][0])/gcd,
                        (lines[i][3]-lines[i][1])/gcd
                    };
                }

                var hashSet = new HashSet<long>();
                for (int j = 0; j < i; j++)
                {
                    if (bases[i][0] == bases[j][0] && bases[i][1] == bases[j][1])
                    {
                        continue;
                    }

                    var cross = GetCross(lines[i][0], lines[i][1], lines[i][2], lines[i][3],
                        lines[j][0], lines[j][1], lines[j][2], lines[j][3]);

                    if (cross[0] < lines[i][0] || cross[0] > lines[i][2]
                        || cross[1] < Min(lines[i][1], lines[i][3])
                        || cross[1] > Max(lines[i][1], lines[i][3])
                        || cross[0] < lines[j][0] || cross[0] > lines[j][2]
                        || cross[1] < Min(lines[j][1], lines[j][3])
                        || cross[1] > Max(lines[j][1], lines[j][3]))
                    {
                        continue;
                    }

                    double eps = 1e-7;
                    if (Abs(Round(cross[0]) - cross[0]) < eps
                        && Abs(Round(cross[1]) - cross[1]) < eps)
                    {
                        long key = (long)(Round(cross[0]) * 10000000 + Round(cross[1]));
                        if (hashSet.Contains(key))
                        {
                            continue;
                        }

                        hashSet.Add(key);
                        cnt--;
                    }
                }
            
                res += cnt;
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

        static double[] GetCross(long x1, long y1, long x2, long y2,
            long x3, long y3, long x4, long y4)
        {
            double s1 = 0.5 * ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3));
            double s2 = 0.5 * ((x4 - x3) * (y3 - y2) - (y4 - y3) * (x3 - x2));

            double cx = x1 + (x2 - x1) * s1 / (s1 + s2);
            double cy = y1 + (y2 - y1) * s1 / (s1 + s2);

            return new double[2] { cx, cy };
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
