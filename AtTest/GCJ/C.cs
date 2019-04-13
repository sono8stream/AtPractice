using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            int[][] ns = new int[t][];
            int[] ls = new int[t];
            int[][][] vals = new int[t][][];
            for(int i = 0; i < t; i++)
            {
                string[] nl = Read().Split();
                ls[i] = int.Parse(nl[1]);
                string[] vs = Read().Split();
                vals[i] = new int[vs.Length][];
                for (int j = 0; j < vs.Length; j++)
                {
                    vals[i][j] = new int[55];
                    int val = 0;
                    int dig = 1;
                    for(int k = 0; k < vs[j].Length; k++)
                    {
                        if (k % 4 == 0)
                        {
                            val = 0;
                            dig = 1;
                        }
                        val += (vs[j][vs[j].Length - 1 - k] - '0') * dig;
                        dig *= 10;
                        vals[i][j][k / 4] = val;
                    }
                }
            }
            for (int i = 0; i < t; i++)
            {
                int[][][] tmps = new int[ls[i]+1][][];
                int now = 0;
                for (int j = 0; j < ls[i] - 1; j++)
                {
                    if (Compare(vals[i][j], vals[i][j + 1]) == 0) continue;

                    tmps[j + 1] = new int[2][];
                    if (Compare(vals[i][j], vals[i][j + 1]) == 1)
                    {
                        tmps[j+1][0] = GCD(vals[i][j], vals[i][j + 1]);
                    }
                    else
                    {
                        tmps[j+1][0] = GCD(vals[i][j + 1], vals[i][j]);
                    }
                    tmps[j + 1][1] = new int[1] { j+1 };
                    now = j;
                    break;
                }
                for (int j = now; j >= 0; j--)
                {
                    tmps[j] = new int[2][];
                    tmps[j][0] = Divide(vals[i][j], tmps[j + 1][0]);
                    tmps[j][1] = new int[1] { j };
                }
                for (int j = now + 2; j <= ls[i]; j++)
                {
                    tmps[j] = new int[2][];
                    tmps[j][0] = Divide(vals[i][j - 1], tmps[j - 1][0]);
                    tmps[j][1] = new int[1] { j };
                }
                Array.Sort(tmps, (a, b) => Compare(a[0], b[0]));
                char[] res = new char[ls[i]+1];
                int pos = 0;
                for(int j = 0; j <= ls[i]; j++)
                {
                    if (j > 0 && Compare(tmps[j][0], tmps[j - 1][0]) != 0) {
                        pos++;
                    }
                    res[tmps[j][1][0]] = (char)('A' + pos);
                }
                Write("Case #" + (i + 1) + ": ");
                WriteLine(res);
            }
        }

        static int[] GCD(int[] a, int[] b)
        {
            int[] c = new int[a.Length];
            do
            {
                c = Reminder(a, b);
                a = b;
                b = c;
            } while (Compare(c, new int[a.Length]) > 0);
            return a;
        }

        static int[] Reminder(int[] a,int[] b)
        {
            int[] aa = new int[a.Length];
            int[] bb = new int[a.Length];
            for (int i = 0; i < a.Length; i++) aa[i] = a[i];
            for (int i = 0; i < b.Length; i++) bb[i] = b[i];
            
            while (Compare(aa, bb) == 1)
            {
                for (int i = b.Length - 1; i >= 0; i--)
                {
                    if (i + 1 < b.Length) bb[i + 1] += bb[i] / 1000;
                    bb[i] *= 10;
                    bb[i] %= 10000;
                }
            }
            while (Compare(aa, b) >= 0)
            {
                while (Compare(aa, bb) >= 0)
                {
                    for (int i = 0; i < a.Length - 1; i++)
                    {
                        aa[i] -= bb[i];
                        if (aa[i] < 0)
                        {
                            aa[i] += 10000;
                            aa[i + 1]--;
                        }
                    }
                }
                for (int i = 0; i < a.Length; i++)
                {
                    if (i > 0) bb[i - 1] += (bb[i] % 10) * 1000;
                    bb[i] /= 10;
                }
            }
            return aa;
        }

        static int[] Divide(int[] a, int[] b)
        {
            int[] aa = new int[a.Length];
            int[] bb = new int[a.Length];
            for (int i = 0; i < a.Length; i++) aa[i] = a[i];
            for (int i = 0; i < b.Length; i++) bb[i] = b[i];
            
            int delta = 0;
            while (Compare(aa, bb) == 1)
            {
                for (int i = b.Length - 1; i >= 0; i--)
                {
                    if (i + 1 < b.Length) bb[i + 1] += bb[i] / 1000;
                    bb[i] *= 10;
                    bb[i] %= 10000;
                }
                delta++;
            }
            int[] result = new int[a.Length];
            while (Compare(aa, b) >= 0)
            {
                while (Compare(aa, bb) >= 0)
                {
                    for (int i = 0; i < a.Length - 1; i++)
                    {
                        aa[i] -= bb[i];
                        if (aa[i] < 0)
                        {
                            aa[i] += 10000;
                            aa[i + 1]--;
                        }
                    }
                    result[delta / 4] += (int)Pow(10, delta % 4);
                }
                delta--;
                for (int i = 0; i < a.Length; i++)
                {
                    if (i > 0) bb[i - 1] += (bb[i] % 10) * 1000;
                    bb[i] /= 10;
                }
            }
            return result;
        }

        static int Compare(int[] a,int[] b)
        {
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] > b[i]) return 1;
                if (a[i] < b[i]) return -1;
            }
            return 0;
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
