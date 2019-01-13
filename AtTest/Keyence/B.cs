using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Keyence
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
            string s = Read();
            string tar = "keyence";
            if (s.Equals(tar))
            {
                Console.WriteLine("YES");
                return;
            }
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length - 1; j++)
                {
                    string trim = s.Substring(0, i);
                    trim += s.Substring(j + 1);
                    if (trim.Equals(tar))
                    {
                        Console.WriteLine("YES");
                        return;
                    }
                }
            }
            Console.WriteLine("NO");
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
