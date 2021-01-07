using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1348
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
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int now = 1;
                int cnt = 0;
                int sum = 1;
                while (sum < n)
                {
                    now *= 2;
                    sum += now;
                    cnt++;
                }

                WriteLine(cnt);
                int remain = n - cnt - 1;
                int min = 1;
                int cap = 1;
                int[] res = new int[cnt];
                for(int j = 0; j <cnt; j++)
                {
                    int vol = cap * (cnt - j);
                    if (vol < remain)
                    {
                        min += cap;
                        res[j] = min;
                        remain -= vol;
                    }
                    else
                    {
                        int delta = remain / (cnt - j);
                        for(int k = cnt - 1; k >= j;k--)
                        {
                            if ((cnt - 1 - k) < remain % (cnt - j))
                            {
                                res[k] = min + delta + 1;
                            }
                            else
                            {
                                res[k] = min + delta;
                            }
                        }
                        break;
                    }
                    cap *= 2;
                }

                for(int j = 0; j < cnt; j++)
                {
                    if (j == 0)
                    {
                        Write(res[j] - 1);
                    }
                    else
                    {
                        Write(res[j] - res[j - 1]);
                    }
                    if (j + 1 < cnt)
                    {
                        Write(" ");
                    }
                    else
                    {
                        WriteLine();
                    }
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
