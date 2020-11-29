﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ARC_109
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
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            string s = Read();
            if (n == 1)
            {
                WriteLine(s[0]);
                return;
            }

            List<char> pat = s.ToCharArray().ToList();
            for(int i = 0; i < k; i++)
            {
                List<char> next = new List<char>();
                for(int j = 0; j < n; j++)
                {
                    char left = pat[j * 2 % n];
                    char right = pat[(j * 2 + 1) % n];

                    if (left == right)
                    {
                        next.Add(left);
                    }
                    else if ((left == 'R' && right == 'S')
                        || (left == 'S' && right == 'R'))
                    {
                        next.Add('R');
                    }
                    else if ((left == 'S' && right == 'P')
                        || (left == 'P' && right == 'S'))
                    {
                        next.Add('S');
                    }
                    else if ((left == 'P' && right == 'R')
                        || (left == 'R' && right == 'P'))
                    {
                        next.Add('P');
                    }
                }
                pat = next;
            }
            WriteLine(pat[0]);
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
