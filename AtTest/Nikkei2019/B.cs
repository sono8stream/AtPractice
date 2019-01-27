using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Nikkei2019
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string a = Read();
            string b = Read();
            string c = Read();
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                var dict = new Dictionary<char, bool>();
                dict.Add(a[i], true);
                if (!dict.ContainsKey(b[i])) dict.Add(b[i], true);
                if (!dict.ContainsKey(c[i])) dict.Add(c[i], true);
                if (dict.Count == 1) res += 0;
                if (dict.Count == 2) res += 1;
                if (dict.Count == 3) res += 2;
            }
            Console.WriteLine(res);
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
