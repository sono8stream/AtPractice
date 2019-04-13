using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string[] strs = new string[n];
            for(int i = 0; i < n; i++)
            {
                strs[i] = Read();
            }
            for(int i = 0; i < n; i++)
            {
                List<char> a = new List<char>();
                List<char> b = new List<char>();
                for (int j = 0; j < strs[i].Length; j++)
                {
                    if (strs[i][j] == '4')
                    {
                        a.Add('3');
                        b.Add('1');
                    }
                    else
                    {
                        a.Add(strs[i][j]);
                        if (b.Count > 0) b.Add('0');
                    }
                }
                Write("Case #" + (i + 1));
                Write(": ");
                Write(a.ToArray());
                Write(" ");
                Write(b.ToArray());
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
