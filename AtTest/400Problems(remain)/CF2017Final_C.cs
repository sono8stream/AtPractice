using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class CF2017Final_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] hw = ReadInts();
            int h = hw[0];
            int w = hw[1];
            int[] counts = new int[26];
            for (int i = 0; i < h; i++)
            {
                string s = Read();
                for (int j = 0; j < w; j++)
                {
                    counts[s[j] - 'a']++;
                }
            }
            Array.Sort(counts);
            Array.Reverse(counts);
            int count1 = (h % 2) * (w % 2);
            int count2 = (w / 2) * (h % 2) + (h / 2) * (w % 2);
            int count4 = (h / 2) * (w / 2);
            for (int i = 0; i < counts.Length; i++)
            {
                int minusCount;
                minusCount = Math.Min(counts[i] / 4, count4);
                count4 -= minusCount;
                counts[i] -= minusCount * 4;
                minusCount = Math.Min(counts[i] / 2, count2);
                count2 -= minusCount;
                counts[i] -= minusCount * 2;
                minusCount = Math.Min(counts[i], count1);
                count1 -= minusCount;
                counts[i] -= minusCount;
                if (counts[i] > 0)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
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
