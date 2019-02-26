using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPCvirtual6
{
    class K
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            long n = ReadLong();
            long div = 5;
            long cnt = 1;
            List<int> margins = new List<int>();
            while (n>0)
            {
                margins.Add((int)(n % 5));
                n /= 5;
            }
            string s = "";
            for(int i = 0; i < margins.Count; i++)
            {
                if (i > 0) s += "+";
                for (int j = 0; j < i; j++)
                {
                    s += "5*";
                }
                s += (char)(margins[i] + '0');
            }
            WriteLine(s);
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
