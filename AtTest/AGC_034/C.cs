using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_034
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nx = ReadInts();
            long n = nx[0];
            long x = nx[1];

            long[][] blus = new long[n][];
            for (int i = 0; i < n; i++) blus[i] = ReadLongs();
            blus = blus.OrderBy(a => -(a[0] * a[1] + (x - a[0]) * a[2])).ToArray();

            long need = 0;
            for (int i = 0; i < n; i++) need += blus[i][0] * blus[i][1];

            long sum = 0;
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                long now = blus[i][0] * blus[i][1] + (x - blus[i][0]) * blus[i][2];
                if (sum + now > need) break;

                sum += now;
                cnt++;
            }

            long res = cnt * x;
            long min = x;
            long remain = need - sum;
            if (remain == 0)
            {
                WriteLine(res);
                return;
            }

            for(int i = cnt; i < n; i++)
            {
                long tmp = 0;
                if (remain <= blus[i][0] * blus[i][1])
                {
                    tmp = remain / blus[i][1];
                    if (remain % blus[i][1] > 0) tmp++;
                }
                else
                {
                    long tmpRemain = remain - blus[i][0] * blus[i][1];
                    tmp = blus[i][0];
                    if (tmpRemain > (x - blus[i][0]) * blus[i][2])
                    {
                        continue;
                    }
                    tmp += tmpRemain / blus[i][2];
                    if (tmpRemain % blus[i][2] > 0) tmp++;
                }
                min = Min(min, tmp);
            }

            WriteLine(res+min);
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
