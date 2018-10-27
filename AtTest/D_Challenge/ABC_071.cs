using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_071
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string s1 = Read();
            string s2 = Read();
            var xys = new List<bool>();
            for(int i = 0; i < n;)
            {
                if (s1[i] == s2[i])
                {
                    xys.Add(true);
                    i++;
                }
                else
                {
                    xys.Add(false);
                    i += 2;
                }
            }
            long mask = 1000000000 + 7;
            long res = xys[0] ? 3 : 6;
            for(int i = 1; i < xys.Count; i++)
            {
                if (xys[i])
                {
                    if (xys[i - 1])
                    {
                        res *= 2;
                        res %= mask;
                    }
                    else
                    {
                        res *= 1;
                        res %= mask;
                    }
                }
                else
                {
                    if (xys[i - 1])
                    {
                        res *= 2;
                        res %= mask;
                    }
                    else
                    {
                        res *= 3;
                        res %= mask;
                    }
                }
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
