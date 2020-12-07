using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1454
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
                int n = ReadInt();
                int[] array = ReadInts();
                var dict = new Dictionary<int, int>();
                for(int j = 0; j < n; j++)
                {
                    if (dict.ContainsKey(array[j]))
                    {
                        dict[array[j]] = -1;
                    }
                    else
                    {
                        dict.Add(array[j], j + 1);
                    }
                }

                int uniqueMin = int.MaxValue;
                foreach(int key in dict.Keys)
                {
                    if (dict[key] != -1)
                    {
                        uniqueMin = Min(uniqueMin, key);
                    }
                }

                WriteLine(uniqueMin == int.MaxValue ? -1 : dict[uniqueMin]);
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
