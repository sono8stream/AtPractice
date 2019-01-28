using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ToStreak
{
    class ABC116_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int s = ReadInt();
            int[] array = new int[1000000];
            array[0] = s;
            var dict = new Dictionary<int, bool>();
            dict.Add(array[0], true);
            for(int i = 1; i < array.Length; i++)
            {
                int prev = array[i - 1];
                if (prev % 2 == 0) array[i] = prev / 2;
                else array[i] = prev * 3 + 1;
                if (dict.ContainsKey(array[i]))
                {
                    Console.WriteLine(i + 1);
                    return;
                }
                else
                {
                    dict.Add(array[i], true);
                }
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
