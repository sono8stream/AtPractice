using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
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
            long[] array = ReadLongs();
            var dict = new Dictionary<long, bool>();
            var pairList = new List<long>();
            for(int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(array[i]))
                {
                    pairList.Add(array[i]);
                    dict.Remove(array[i]);
                }
                else
                {
                    dict.Add(array[i], true);
                }
            }
            pairList.Sort();
            if (pairList.Count < 2)
            {
                Console.Write(0);
            }
            else
            {
                Console.Write(pairList[pairList.Count - 1]
                    * pairList[pairList.Count - 2]);
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
