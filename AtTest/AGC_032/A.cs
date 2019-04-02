using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_032
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            for(int i = 0; i < n; i++)
            {
                if (array[i] > i + 1)
                {
                    WriteLine(-1);
                    return;
                }
            }
            List<int> list = new List<int>();
            list.AddRange(array);
            int[] res = new int[n];
            for(int i = 0; i < n; i++)
            {
                for(int j = list.Count - 1; j >= 0; j--)
                {
                    if (list[j] == j + 1)
                    {
                        res[i] = list[j];
                        list.RemoveAt(j);
                        break;
                    }
                }
            }
            Array.Reverse(res);
            for(int i = 0; i < n; i++)
            {
                WriteLine(res[i]);
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
