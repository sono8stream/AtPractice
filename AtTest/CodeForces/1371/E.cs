using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1371
{
    class E
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
            int[] np = ReadInts();
            int n = np[0];
            int p = np[1];
            int[] array = ReadInts();
            Array.Sort(array);

            List<int> res = new List<int>();
            int[] cnts = new int[2005];
            for(int i = 1; i <= 2000; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (array[j] <= i)
                    {
                        cnts[i]++;
                    }
                }
            }

            for(int i = 1; i <= 2000; i++)
            {
                int cnt;
                bool ok = true;
                for (int j = 0; j < n; j++)
                {
                    cnt = cnts[Min(i + j, 2000)];
                    cnt -= j;

                    if (cnt == 0 || cnt % p == 0)
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    res.Add(i);
                }
            }

            WriteLine(res.Count);
            for(int i = 0; i < res.Count; i++)
            {
                Write(res[i]);
                if (i + 1 < res.Count)
                {
                    Write(" ");
                }
            }
            WriteLine();
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
