using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class ARC098_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nkq = ReadInts();
            int n = nkq[0];
            int k = nkq[1];
            int q = nkq[2];
            int[] array = new int[n + 1];
            int[] readArray = ReadInts();
            for (int i = 0; i < n; i++) array[i] = readArray[i];
            array[n] = 0;

            int res = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                var tempList = new List<int>();
                var valList = new List<int>();
                for (int j = 0; j <= n; j++)
                {
                    if (array[j] < array[i])
                    {
                        tempList.Sort();
                        for (int l = 0; l < tempList.Count - k + 1; l++)
                        {
                            valList.Add(tempList[l]);
                        }

                        tempList = new List<int>();
                    }
                    else
                    {
                        tempList.Add(array[j]);
                    }
                }

                valList.Sort();
                if (valList.Count >= q)
                {
                    res = Min(res, valList[q - 1] - valList[0]);
                }
            }

            WriteLine(res);
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
