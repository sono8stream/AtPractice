using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.NikkeiEx
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            for (int i = 1; i <= n; i++)
            {
                string s = "";
                bool ok = false;
                for (int j = 2; j <= 6; j++)
                {
                    if (i % j == 0)
                    {
                        s += (char)('a' + j - 2);
                        ok = true;
                    }
                }
                if (!ok) s = i.ToString();
                Console.WriteLine(s);
            }
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
