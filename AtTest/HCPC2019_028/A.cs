using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_028
{
    class A
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
            string[] week = new string[7] { "Mon", "Tue", "Wed", "Thu",
                "Fri", "Sat", "Sun" };
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Mon", 0);
            dict.Add("Tue", 1);
            dict.Add("Wed", 2);
            dict.Add("Thu", 3);
            dict.Add("Fri", 4);
            dict.Add("Sat", 5);
            dict.Add("Sun", 6);

            string[] ss = new string[n];
            for (int i = 0; i < n; i++) ss[i] = Read();

            for(int i = 0; i < n; i++)
            {
                int index = dict[ss[i]] + 1;
                index %= 7;
                WriteLine(week[index]);
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
