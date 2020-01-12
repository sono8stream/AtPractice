using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_151
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
            double[][] xys = new double[n][];
            for(int i = 0; i < n; i++)
            {
                xys[i] = ReadDoubles();
            }
            double res = long.MaxValue;
            double thres = 0.0000001;
            for(int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double x = (xys[i][0] + xys[j][0]) / 2;
                    double y = (xys[i][1] + xys[j][1]) / 2;
                    double r2 = (x - xys[i][0]) * (x - xys[i][0])
                        + (y - xys[i][1]) * (y - xys[i][1]);
                    bool ok = true;
                    for (int k = 0; k < n; k++)
                    {
                        double tmpR2 = (x - xys[k][0]) * (x - xys[k][0])
                            + (y - xys[k][1]) * (y - xys[k][1]);
                        if (tmpR2 < r2 + thres) continue;
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok) res = Min(res, r2);
                }
            }
            if (n == 2)
            {
                WriteLine(Sqrt(res));
                return;
            }

            for(int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        double[] a = new double[2]{xys[j][0] - xys[i][0],
                            xys[j][1] - xys[i][1]};
                        double[] b = new double[2]{xys[k][0] - xys[i][0],
                            xys[k][1] - xys[i][1]};
                        double a2 = a[0] * a[0] + a[1] * a[1];
                        double b2 = b[0] * b[0] + b[1] * b[1];
                        double ab = a[0] * b[0] + a[1] * b[1];
                        double s = 0.5 * (1 - ab * (ab - b2) / (ab * ab - a2 * b2));
                        double t = 0.5 * a2 * (ab - b2) / (ab * ab - a2 * b2);
                        double x = xys[i][0] + a[0] * s + b[0] * t;
                        double y = xys[i][1] + a[1] * s + b[1] * t;
                        double r2 = (x - xys[i][0]) * (x - xys[i][0])
                            + (y - xys[i][1]) * (y - xys[i][1]);
                        bool ok = true;
                        for (int l = 0; l < n; l++)
                        {
                            double tmpR2 = (x - xys[l][0]) * (x - xys[l][0])
                                + (y - xys[l][1]) * (y - xys[l][1]);
                            if (tmpR2 < r2 + thres) continue;
                            else
                            {
                                ok = false;
                                break;
                            }
                        }
                        if (ok) res = Min(res, r2);
                    }
                }
            }
            WriteLine(Sqrt(res));
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
