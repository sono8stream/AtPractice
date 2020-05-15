using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2020_1C
{
    class C
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
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int[] nd = ReadInts();
            int n = nd[0];
            int d = nd[1];
            long[] array = ReadLongs();
            long sum = array.Sum();
            long div = d / sum + 1;
            long res = 0;
            long resTmp = 0;
            for(int i = 0; i < n; i++)
            {
                if (array[i] * div <= d - resTmp)
                {
                    resTmp += div;
                    res += div - 1;
                }
                else
                {
                    res += d - resTmp;
                }
            }
            Array.Sort(array);
            HashSet<long> divs = new HashSet<long>();
            for(int i = 0; i < n; i++)
            {
                for(long j = 1; j * j <= array[i]; j++)
                {
                    if (array[i] % j == 0)
                    {
                        divs.Add(j);
                        divs.Add(array[i] / j);
                    }
                }
            }

            foreach(long val in divs)
            {
                long tmp = 0;
                long cutTmp = 0;
                for(int i = 0; i < n; i++)
                {
                    if (array[i] % val == 0)
                    {
                        if (array[i] / val <= d - tmp)
                        {
                            tmp += array[i] / val;
                            cutTmp += array[i] / val - 1;
                        }
                        else
                        {
                            cutTmp += d - tmp;
                            break;
                        }
                    }
                }
                if (tmp < d)
                {
                    for(int i = 0; i < n; i++)
                    {
                        if (array[i] % val > 0)
                        {
                            if (array[i] / val <= d - tmp)
                            {
                                tmp += array[i] / val;
                                cutTmp += array[i] / val;
                            }
                            else
                            {
                                cutTmp += d - tmp;
                                break;
                            }
                        }
                    }
                }
                if (tmp == d)
                {
                    res = Min(res, cutTmp);
                }
            }
            return () => { WriteLine(res); };
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
