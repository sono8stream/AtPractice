using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_158
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
            char[] s = Read().ToCharArray();
            int q = ReadInt();
            bool rev = false;
            List<char> left = new List<char>();
            List<char> right = new List<char>();
            for(int i = 0; i < q; i++)
            {
                string[] input = Read().Split();
                if (input.Length == 1)
                {
                    rev = !rev;
                }
                else
                {
                    int f = int.Parse(input[1]);
                    if (f == 1)
                    {
                        if (rev)
                        {
                            right.Add(input[2][0]);
                        }
                        else
                        {
                            left.Add(input[2][0]);
                        }
                    }
                    else
                    {
                        if (rev)
                        {
                            left.Add(input[2][0]);
                        }
                        else
                        {
                            right.Add(input[2][0]);
                        }
                    }
                }
            }

            if (rev)
            {
                for (int i = 0; i < right.Count; i++)
                {
                    Write(right[right.Count - 1 - i]);
                }
                for (int i = 0; i < s.Length; i++)
                {
                    Write(s[s.Length-i-1]);
                }
                for (int i = 0; i < left.Count; i++)
                {
                    Write(left[i]);
                }
            }
            else
            {
                for(int i = 0; i < left.Count; i++)
                {
                    Write(left[left.Count - 1 - i]);
                }
                for(int i = 0; i < s.Length; i++)
                {
                    Write(s[i]);
                }
                for(int i = 0; i < right.Count; i++)
                {
                    Write(right[i]);
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
