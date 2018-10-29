using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_053
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            Array.Sort(array);
            var cntList = new List<int>();
            cntList.Add(1);
            bool requirePair = false;
            for(int i = 1; i < n; i++)
            {
                if (array[i] == array[i - 1])
                {
                    cntList[cntList.Count - 1]++;
                }
                else
                {
                    if (cntList[cntList.Count - 1] % 2 == 0)
                    {
                        requirePair = !requirePair;
                    }
                    cntList.Add(1);
                }
            }
            if (cntList[cntList.Count - 1] % 2 == 0)
            {
                requirePair = !requirePair;
            }
            if (requirePair)
            {
                Console.WriteLine(cntList.Count - 1);
            }
            else
            {
                Console.WriteLine(cntList.Count);
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
