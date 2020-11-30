using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1389
{
    class B
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
                int[] nkz = ReadInts();
                int n = nkz[0];
                int k = nkz[1];
                int z = nkz[2];

                int[] array = ReadInts();
                long res = array[0];
                long deltaMax = 0;
                long sum = array[0];
                for(int j = 1; j < n; j++)
                {
                    sum += array[j];
                    long rets = k - j;
                    if (rets < 0)
                    {
                        break;
                    }
                    deltaMax = Max(deltaMax, array[j - 1] + array[j]);
                    if (rets <= z * 2)
                    {
                        if (rets % 2 == 0)
                        {
                            res = Max(res, sum + deltaMax * rets / 2);
                        }
                        else
                        {
                            res = Max(res, sum + array[j - 1] + deltaMax * (rets / 2));
                        }
                    }
                }

                WriteLine(res);
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
