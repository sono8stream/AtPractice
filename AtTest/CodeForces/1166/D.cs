using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1166
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int q = ReadInt();
            long[][] abrs = new long[q][];
            for (int i = 0; i < q; i++) abrs[i] = ReadLongs();

            for(int i = 0; i < q; i++)
            {
                if (abrs[i][0] == abrs[i][1])
                {
                    WriteLine(1 + " " + abrs[i][0]);
                    continue;
                }

                long min = abrs[i][0];
                long max = abrs[i][0];

                bool ok = true;
                int cnt = 0;
                for (int j = 1; j <= 55; j++)
                {
                    if (j == 1)
                    {
                        min++;
                        max += abrs[i][2];
                    }
                    else
                    {
                        min = 2 * min;
                        max = 2 * max;
                    }

                    if (abrs[i][1] < min)
                    {
                        ok = false;
                        break;
                    }
                    if (max < abrs[i][1]) continue;

                    cnt = j;
                    break;
                }

                if (ok)
                {
                    Write((cnt + 1) + " ");
                    Write(abrs[i][0] + " ");
                    long[] rs = new long[cnt];
                    long div = (long)Pow(2, cnt - 1);
                    long remain = abrs[i][1] - div * abrs[i][0];
                    for (int j = 0; j < cnt; j++)
                    {
                        if (div > 1) div /= 2;

                        rs[j] = Min((remain - div) / div, abrs[i][2]);
                        remain -= rs[j] * div;
                    }
                    rs[cnt - 1]++;

                    for(int j = 0; j <cnt; j++)
                    {
                        long divTmp = (long)Pow(2, j);
                        long tmp = abrs[i][0] * divTmp;
                        if (j == 0) tmp += rs[0];
                        else
                        {
                            for (int k = 0; k < cnt; k++)
                            {
                                divTmp /= 2;
                                tmp += rs[k] * divTmp;
                                if (divTmp == 1)
                                {
                                    tmp += rs[k + 1] * divTmp;
                                    break;
                                }
                            }
                        }

                        Write(tmp);
                        if (j < cnt - 1) Write(" ");
                    }
                    WriteLine();
                }
                else
                {
                    WriteLine(-1);
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
