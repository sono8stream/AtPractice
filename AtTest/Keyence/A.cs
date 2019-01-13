using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Keyence
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            var dict = new Dictionary<int, bool>();
            int[] ns = ReadInts();
            for(int i = 0; i < 4; i++)
            {
                if (!dict.ContainsKey(ns[i])) dict.Add(ns[i], true);
            }
            int cnt = 0;
            if (dict.ContainsKey(1)) cnt++;
            if (dict.ContainsKey(9)) cnt++;
            if (dict.ContainsKey(7)) cnt++;
            if (dict.ContainsKey(4)) cnt++;
            Console.WriteLine(cnt == 4 ? "YES" : "NO");
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
