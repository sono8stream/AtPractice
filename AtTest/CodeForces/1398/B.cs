using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1398
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
                string s = Read();

                List<int> ones = new List<int>();
                int left = -1;
                for(int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '1')
                    {
                        if (left == -1)
                        {
                            left = j;
                        }
                    }
                    else
                    {
                        if (left != -1)
                        {
                            ones.Add(j - left);
                            left = -1;
                        }
                    }
                }
                if (left != -1)
                {
                    ones.Add(s.Length - left);
                }

                ones.Sort();
                int res = 0;
                for(int j = ones.Count - 1; j >= 0; j -= 2)
                {
                    res += ones[j];
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
