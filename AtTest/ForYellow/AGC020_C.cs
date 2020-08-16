using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class AGC020_C
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
            int[] array = ReadInts();
            BitArray bitArray = new BitArray(2000 * 2001);
            BitArray bitArray2 = new BitArray(2000 * 2001);

            bitArray.Set(0, true);
            bitArray2.Set(0, true);
            for (int i = 0; i < n; i++)
            {
                bitArray.Or(bitArray2.LeftShift(array[i]));
                bitArray2.Or(bitArray);
            }

            int sum = array.Sum();
            int res = sum;
            int cnt = 0;
            foreach (bool val in bitArray)
            {
                if (val && cnt * 2 >= sum)
                {
                    res = Min(res, cnt);
                }
                cnt++;
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
