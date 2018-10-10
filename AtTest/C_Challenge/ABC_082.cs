using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_082
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
            long[] cntArray = new long[100000];
            long cnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > 100000)
                {
                    cnt++;
                }
                else
                {
                    cntArray[array[i] - 1]++;
                }
            }

            for(int i = 0; i < 100000; i++)
            {
                if (cntArray[i] == 0
                    || cntArray[i] == i + 1) continue;

                if (cntArray[i] > i + 1)
                {
                    cnt += cntArray[i] - (i + 1);
                }
                else if (cntArray[i] < i + 1)
                {
                    cnt += cntArray[i];
                }
            }
            Console.WriteLine(cnt);
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
