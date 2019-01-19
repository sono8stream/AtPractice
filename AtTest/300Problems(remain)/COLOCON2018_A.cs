using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class COLOCON2018_A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string s = Read();
            bool firstA = s[0] == 'A';
            bool lastA = s[s.Length - 1] == 'A';
            var list = new List<long>();
            bool nowA = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'A')
                {
                    if (nowA)
                    {
                        list[list.Count - 1]++;
                    }
                    else
                    {
                        nowA = true;
                        list.Add(1);
                    }
                }
                else
                {
                    nowA = false;
                }
            }
            long res = 0;
            if (list.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (firstA && lastA)
            {
                if (list.Count == 1)
                {
                    res += (list[0] * n) * (list[0] * n + 1) / 2;
                }
                else
                {
                    for (int i = 1; i < list.Count - 1; i++)
                    {
                        res += list[i] * (list[i] + 1) / 2 * n;
                    }
                    long first = list[0];
                    long last = list[list.Count - 1];
                    res += first * (first + 1) / 2;
                    res += (first + last) * (first + last + 1) / 2 * (n - 1);
                    res += last * (last + 1) / 2;
                }
            }
            else
            {
                for(int i = 0; i < list.Count; i++)
                {
                    res += list[i] * (list[i] + 1) / 2 * n;
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
