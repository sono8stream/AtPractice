using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1463
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
                var hashSet = new HashSet<int>();
                for(int j = 0; j < n; j++)
                {
                    hashSet.Add(array[j]);
                }
                int cnt = 0;
                int max = 0;
                for (int j = 1; j <= 2 * n; j++)
                {
                    if (hashSet.Contains(j))
                    {
                        cnt++;
                    }
                    else
                    {
                        if (cnt > 0)
                        {
                            max++;
                            cnt--;
                        }
                    }
                }
                cnt = 0;
                int min = n;
                for(int j = 2 * n; j >= 1; j--)
                {
                    if (hashSet.Contains(j))
                    {
                        cnt++;
                    }
                    else
                    {
                        if (cnt > 0)
                        {
                            min--;
                            cnt--;
                        }
                    }
                }
                WriteLine(max - min + 1);
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
