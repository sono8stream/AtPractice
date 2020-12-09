using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1453
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
            List<long> vals = new List<long>();
            vals.Add(2);
            while (vals[vals.Count - 1] < 1e18)
            {
                vals.Add(vals[vals.Count - 1] * 2 + 2);
            }
            for(int i = 0; i < t; i++)
            {
                long k = ReadLong();
                long[] uses = new long[vals.Count];
                long length = 0;
                for(int j = vals.Count - 1; j >= 0; j--)
                {
                    while (k >= vals[j])
                    {
                        uses[j]++;
                        length += j + 1;
                        k -= vals[j];
                    }
                }

                if (k > 0||length>3000)
                {
                    WriteLine(-1);
                }
                else
                {
                    WriteLine(length);
                    for(int j = 0; j < vals.Count; j++)
                    {
                        while (uses[j] > 0)
                        {
                            for(int l = 0; l < j + 1; l++)
                            {
                                Write(l == 0 ? 1 : 0);
                                if (length > 1)
                                {
                                    Write(" ");
                                }
                                length--;
                            }
                            uses[j]--;
                        }
                    }
                    WriteLine();
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
