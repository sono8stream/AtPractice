using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.TKPPC_004_2
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            long[] array = ReadLongs();
            long[] aArray = new long[n];
            long[] bArray = new long[n];
            long[] cArray = new long[n];

            for (int i = 0; i <= n - 2 * k + 1; i++)
            {
                if (i > 0)
                {
                    aArray[i] += aArray[i - 1];
                    bArray[i] += bArray[i - 1];
                    cArray[i] += cArray[i - 1];
                }

                long dec = aArray[i] * i;
                dec = (dec + bArray[i]) * i;
                dec += cArray[i];

                if (array[i] < dec)
                {
                    WriteLine("No");
                    return;
                }
                else if (array[i] == dec) continue;
                else
                {
                    long delta = array[i] - dec;

                    aArray[i] += delta;
                    bArray[i] -= 2 * (i - 1) * delta;
                    cArray[i] += (i - 1) * (i - 1) * delta;

                    aArray[i + k] -= delta;
                    bArray[i + k] += 2 * (i - 1) * delta;
                    cArray[i + k] -= (i - 1) * (i - 1) * delta;

                    aArray[i + k] += delta;
                    bArray[i + k] -= 2 * (i + 2 * k-1) * delta;
                    cArray[i + k] += (i + 2 * k - 1) * (i + 2 * k - 1) * delta;

                    if (i + 2 * k - 1 < n)
                    {
                        aArray[i + 2 * k - 1] -= delta;
                        bArray[i + 2 * k - 1] += 2 * (i + 2 * k - 1) * delta;
                        cArray[i + 2 * k - 1]
                            -= (i + 2 * k - 1) * (i + 2 * k - 1) * delta;
                    }
                }
            }

            for (int i = n - 2 * k + 2; i < n; i++)
            {
                aArray[i] += aArray[i - 1];
                bArray[i] += bArray[i - 1];
                cArray[i] += cArray[i - 1];
                long dec = aArray[i] * i;
                dec = (dec + bArray[i]) * i;
                dec += cArray[i];
                if (array[i] != dec)
                {
                    WriteLine("No");
                    return;
                }
            }
            WriteLine("Yes");
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
