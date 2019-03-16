using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.NikkeiEx
{
    class G
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            var dict = new Dictionary<char, long>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i])) dict.Add(s[i], 0);
                dict[s[i]]++;
            }
            long cnt = 0;
            long others = 0;
            foreach (long val in dict.Values)
            {
                cnt += val - val % 2;
                if (val % 2 > 0) others++;
            }
            if (others > 0)
            {
                cnt++;
                others--;
            }
            WriteLine(cnt * cnt + others);
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
