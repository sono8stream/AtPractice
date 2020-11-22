using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_184
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
            int[] abc = ReadInts();

            int aRemain = 100 - abc[0];
            int bRemain = 100 - abc[1];
            int cRemain = 100 - abc[2];
            int all = abc[0] + abc[1] + abc[2];

            double[,] combis = new double[305, 305];
            combis[0, 0] = 1;
            for(int i = 1; i <= 300; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    if (j == 0)
                    {
                        combis[i, j] = 1;
                    }
                    else
                    {
                        combis[i, j] = combis[i, j - 1] * (i - j + 1) / j;
                    }
                }
            }

            double res = 0;
            {
                double tmp = 1;
                for(int i = 1; i <= aRemain; i++)
                {
                    tmp *= (abc[0] + i - 1.0) / (all + i - 1);
                }
                for (int i = 0; i < bRemain; i++)
                {
                    if (i > 0)
                    {
                        tmp *= (abc[1] + i - 1.0) / (all + aRemain + i - 1);
                    }
                    double tmp2 = tmp;

                    for (int j = 0; j < cRemain; j++)
                    {
                        if (j > 0)
                        {
                            tmp2 *= (abc[2] + j - 1.0) / (all + aRemain + i + j - 1);
                        }
                        int cnt = aRemain - 1 + i + j;
                        res += (cnt+1)*tmp2 * combis[cnt, aRemain - 1] * combis[cnt - aRemain + 1, i];
                    }
                }
            }
            {
                double tmp = 1;
                for (int i = 1; i <= bRemain; i++)
                {
                    tmp *= (abc[1] + i - 1.0) / (all + i - 1);
                }
                for (int i = 0; i < aRemain; i++)
                {
                    if (i > 0)
                    {
                        tmp *= (abc[0] + i - 1.0) / (all + bRemain + i - 1);
                    }
                    double tmp2 = tmp;

                    for (int j = 0; j < cRemain; j++)
                    {
                        if (j > 0)
                        {
                            tmp2 *= (abc[2] + j - 1.0) / (all + bRemain + i + j - 1);
                        }
                        int cnt = bRemain - 1 + i + j;
                        res += (cnt + 1) * tmp2 * combis[cnt, bRemain - 1] * combis[cnt - bRemain + 1, i];
                    }
                }
            }
            {
                double tmp = 1;
                for (int i = 1; i <= cRemain; i++)
                {
                    tmp *= (abc[2] + i - 1.0) / (all + i - 1);
                }
                for (int i = 0; i < aRemain; i++)
                {
                    if (i > 0)
                    {
                        tmp *= (abc[0] + i - 1.0) / (all + cRemain + i - 1);
                    }
                    double tmp2 = tmp;

                    for (int j = 0; j < bRemain; j++)
                    {
                        if (j > 0)
                        {
                            tmp2 *= (abc[1] + j - 1.0) / (all + cRemain + i + j - 1);
                        }
                        int cnt = cRemain - 1 + i + j;
                        res += (cnt + 1) * tmp2 * combis[cnt, cRemain - 1] * combis[cnt - cRemain + 1, i];
                    }
                }
            }

            WriteLine(res);

            /*
            double[,,] dp = new double[105, 105, 105];
            for (int i = abc[0]; i < 100; i++)
            {
                for (int j = abc[1]; j < 100; j++)
                {
                    for (int k = abc[2]; k < 100; k++)
                    {
                        dp[i + 1, j, k] += (dp[i, j, k] + 1) * i / (i + j + k);
                        dp[i, j + 1, k] += (dp[i, j, k] + 1) * j / (i + j + k);
                        dp[i, j, k + 1] += (dp[i, j, k] + 1) * k / (i + j + k);
                    }
                }
            }



            double res = 0;
            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    res += dp[100, i, j];
                    res += dp[i, 100, j];
                    res += dp[i, j, 100];
                }
            }

            WriteLine(res);
            */
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
