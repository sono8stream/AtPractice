using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1417
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
                int[] array = ReadInts();
                int sum = array.Sum();
                if (sum % n > 0)
                {
                    WriteLine(-1);
                    continue;
                }

                int target = sum / n;
                List<int[]> res = new List<int[]>();
                // 1以外0に
                for(int j = 1; j < n; j++)
                {
                    int margin = array[j] % (j + 1);
                    if (margin > 0)
                    {
                        res.Add(new int[3] { 1, j + 1, j + 1 - margin });
                        array[0] -= j + 1 - margin;
                        array[j] += j + 1 - margin;
                    }
                    res.Add(new int[3] { j + 1, 1, array[j] / (j + 1) });
                    array[0] += array[j];
                    array[j] = 0;
                }

                for(int j = 1; j < n; j++)
                {
                    res.Add(new int[3] { 1, j + 1, target });
                }

                WriteLine(res.Count);
                for(int j = 0; j < res.Count; j++)
                {
                    WriteLine(res[j][0] + " " + res[j][1] + " " + res[j][2]);
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
