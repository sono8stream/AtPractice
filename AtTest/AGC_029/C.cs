using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_029
{
    class C
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            var dict = new Dictionary<int, int>();
            var lenDict = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(array[i]))
                {
                    if (!lenDict.ContainsKey(array[i]))
                    {
                        lenDict.Add(array[i], 0);
                    }
                    lenDict[array[i]] 
                        = Math.Max(lenDict[array[i]], i - dict[array[i]]);
                    dict[array[i]] = i;
                }
                else
                {
                    dict.Add(array[i], i);
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
