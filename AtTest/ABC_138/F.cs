using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_138
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
            long[] lr = ReadLongs();
            long l = lr[0];
            long r = lr[1];
            int digit = 1;
            while (l >= Pow(2, digit)) digit++;
            int min = digit;
            while (r >= Pow(2, digit)) digit++;
            int max = digit;
            long res = 0;
            long mask = 1000000000 + 7;
            long[] threePows = new long[100];
            threePows[0] = 1;
            for(int i = 1; i < 100; i++)
            {
                threePows[i] = threePows[i - 1] * 3;
                threePows[i] %= mask;
            }
            for (int i = min; i <= max; i++)
            {
                if (i == min && i == max)
                {
                    long[,] dp = new long[i, 4];//not, min, max,minmax
                    dp[0, 3] = 1;
                    long div = (long)Pow(2, i - 2);
                    for (int j = 1; j < i; j++)
                    {
                        dp[j, 0] = dp[j - 1, 0] * 3;
                        if ((l & div) > 0 && (r & div) > 0)
                        {
                            dp[j, 3] = dp[j - 1, 3];
                        }
                        else if ((r & div) > 0)
                        {
                            dp[j, 3] = dp[j - 1, 3];
                            dp[j, 2] = dp[j - 1, 3];
                            //dp[j,1]=
                            //dp[j,2]+=dp[j-1,]
                        }
                        else if ((l & div) > 0)
                        {

                        }
                        else
                        {

                        }
                        dp[j, 0] %= mask;
                        dp[j, 1] %=mask;
                        dp[j, 2] %= mask;
                        dp[j, 3] %= mask;
                        div /= 2;
                    }
                    res += dp[i - 1, 0] + dp[i - 1, 1];
                    res %= mask;
                }
                else if (i==min)
                {
                    long[,] dp = new long[i, 2];//not min,min
                    dp[0, 1] = 1;
                    long div = (long)Pow(2, i - 2);
                    for(int j = 1; j < i; j++)
                    {
                        dp[j, 0] = dp[j - 1, 0] * 3;
                        if ((l & div) > 0)
                        {
                            dp[j, 1] = dp[j - 1, 1];
                        }
                        else
                        {
                            dp[j, 1] = dp[j - 1, 1] * 2;
                            dp[j, 0] += dp[j-1, 1];
                        }
                        dp[j, 0] %= mask;
                        dp[j, 1] %= mask;
                        div /= 2;
                    }
                    res += dp[i - 1, 0] + dp[i - 1, 1];
                    res %= mask;
                }
                else if (i == max)
                {
                    long[,] dp = new long[i, 2];//not max,max
                    dp[0, 1] = 1;
                    long div = (long)Pow(2, i - 2);
                    for (int j = 1; j < i; j++)
                    {
                        dp[j, 0] = dp[j - 1, 0] * 3;
                        if ((r & div) > 0)
                        {
                            dp[j, 1] = dp[j - 1, 1]*2;
                            dp[j, 0] += dp[j - 1, 1];
                        }
                        else
                        {
                            dp[j, 1] = dp[j - 1, 1];
                        }
                        dp[j, 0] %= mask;
                        dp[j, 1] %= mask;
                        div /= 2;
                    }
                    res += dp[i - 1, 0] + dp[i - 1, 1];
                    res %= mask;
                }
                else
                {
                    res += threePows[i - 1];
                }
            }
            WriteLine(res);
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
