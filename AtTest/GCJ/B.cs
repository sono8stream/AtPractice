using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            int[] ns = new int[t];
            string[] ps = new string[t];
            for(int i = 0; i < t; i++)
            {
                ns[i] = ReadInt();
                ps[i] = Read();
            }
            for(int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                for(int j = 0; j < ps[i].Length; j++)
                {
                    Write(ps[i][j] == 'E' ? 'S' : 'E');
                }
                WriteLine();
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
