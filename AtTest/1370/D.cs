using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._1370
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
            int[]nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] array = ReadInts();

            int oddCnt = k / 2;
            if (k % 2 == 1)
            {
                oddCnt++;
            }
            int evenCnt = k / 2;
            int bottom = 0;
            int top = 1000000000;
            while (bottom + 1 < top)
            {
                int mid = (bottom + top) / 2;
                // とれるか
                int oddTmp = 0;
                for (int i = 0; i < n; i++)
                {
                    if (array[i] <= mid)
                    {
                        if (oddCnt > evenCnt || i + 1 < n)
                            oddTmp++;
                        i++;
                    }
                }

                int evenTmp = 0;
                for (int i = 1; i < n; i++)
                {
                    if (array[i] <= mid)
                    {
                        if (oddCnt == evenCnt || i + 1 < n)
                        {
                            evenTmp++;
                            i++;
                        }
                    }
                }

                if (oddTmp >= oddCnt || evenTmp >= evenCnt)
                {
                    top = mid;
                }
                else
                {
                    bottom = mid;
                }
            }
            WriteLine(top);
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
