using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_173
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
            int n = ReadInt();
            int[] cnts = new int[4];
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                if (s == "AC")
                {
                    cnts[0]++;
                }
                if (s == "WA")
                {
                    cnts[1]++;
                }
                if (s == "TLE")
                {
                    cnts[2]++;
                }
                if (s == "RE")
                {
                    cnts[3]++;
                }
            }

            WriteLine("AC x " + cnts[0]);
            WriteLine("WA x " + cnts[1]);
            WriteLine("TLE x " + cnts[2]);
            WriteLine("RE x " + cnts[3]);
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
