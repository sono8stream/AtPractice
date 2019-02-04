using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_091
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
            int[] bArray = ReadInts();
            var aMods = new int[30][];
            var bMods = new int[30][];
            for (int i = 0; i < 30; i++)
            {
                aMods[i] = new int[n];
                bMods[i] = new int[n];
                int div = 2 << i;
                for (int j = 0; j < n; j++)
                {
                    aMods[i][j] = array[j] % div;
                    bMods[i][j] = bArray[j] % div;
                }
            }

            var cnts = new long[30];
            for (int i = 0; i < 30; i++)
            {
                Array.Sort(aMods[i]);
                Array.Reverse(aMods[i]);
                Array.Sort(bMods[i]);
                int t = 1 << i;
                int[] itrs = new int[4];
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        while (itrs[k] < n
                            && bMods[i][itrs[k]] < t * (k + 1) - aMods[i][j])
                            itrs[k]++;
                    }
                    cnts[i] += itrs[1] - itrs[0];
                    cnts[i] += itrs[3] - itrs[2];
                    //Console.Write(cnts[i] + " ");
                }
                //Console.WriteLine();
            }
            long res = 0;
            for (int i = 0; i < 30; i++)
            {
                //Console.WriteLine(cnts[i]);
                if (cnts[i] % 2 > 0) res += 1 << i;
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
