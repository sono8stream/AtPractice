using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_151
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            int acs = 0;
            int pens = 0;
            int[] penCnts = new int[n];
            bool[] solved = new bool[n];
            for(int i = 0; i < m; i++)
            {
                string[] val = Read().Split();
                int num = int.Parse(val[0]) - 1;
                string state = val[1];
                if (state.Equals("AC"))
                {
                    if (!solved[num])
                    {
                        acs++;
                        pens += penCnts[num];
                        solved[num] = true;
                    }
                }
                else
                {
                    penCnts[num]++;
                }
            }
            WriteLine(acs + " " + pens);
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
