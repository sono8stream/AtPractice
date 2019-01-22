using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class CF2016A_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            char[] chars = s.ToCharArray();
            int k = ReadInt();
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (chars[i] == 'a') continue;

                int delta = 'a' + 26 - chars[i];
                if (delta <= k)
                {
                    chars[i] = 'a';
                    k -= delta;
                }
            }
            //Console.WriteLine(k);
            k %= 26;
            chars[s.Length - 1] 
                = (char)('a'+(chars[s.Length - 1] + k-'a') % 26);
            Console.WriteLine(chars);
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
