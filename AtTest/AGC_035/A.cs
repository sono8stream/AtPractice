using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_035
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
            int[] array = ReadInts();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(array[i])) dict[array[i]]++;
                else dict.Add(array[i], 1);
            }

            List<int> keys = new List<int>();
            foreach (int key in dict.Keys) keys.Add(key);

            if (keys.Count == 1)
            {
                int val = dict.First().Key;
                if (val == 0)
                {
                    WriteLine("Yes");
                    return;
                }
            }

            if (n % 3 > 0)
            {
                WriteLine("No");
                return;
            }

            if (keys.Count == 2)
            {
                if(dict.ContainsKey(0)
                    && dict[0] == n / 3)
                {
                    WriteLine("Yes");
                    return;
                }
            }

            if (keys.Count == 3)
            {
                if(keys[0]==(keys[1]^keys[2])
                    && dict[keys[0]] == n / 3 && dict[keys[1]] == n / 3)
                {
                    WriteLine("Yes");
                    return;
                }
            }

            WriteLine("No");
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
