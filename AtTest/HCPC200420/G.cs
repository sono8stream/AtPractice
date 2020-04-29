using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC200420
{
    class G
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
            while (true)
            {
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];
                if (n == 0)
                {
                    break;
                }

                int[][][] kds = new int[n][][];
                for(int i = 0; i < n; i++)
                {
                    int[] vals = ReadInts();
                    int k = vals[0];
                    kds[i] = new int[k][];
                    for(int j = 1; j < vals.Length; j += 2)
                    {
                        kds[i][j / 2] = new int[2] { vals[j], vals[j + 1] };
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
