using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_188
{
    class C
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
            var list = new List<int[]>();
            for(int i = 0; i < array.Length; i++)
            {
                list.Add(new int[2] { array[i], i });
            }
            while (list.Count > 2)
            {
                var next = new List<int[]>();
                for(int i = 0; i < list.Count; i += 2)
                {
                    if (list[i][0] < list[i + 1][0])
                    {
                        next.Add(list[i+1]);
                    }
                    else
                    {
                        next.Add(list[i]);
                    }
                }
                list = next;
            }

            if (list[0][0] < list[1][0])
            {
                WriteLine(list[0][1] + 1);
            }
            else
            {
                WriteLine(list[1][1] + 1);
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
