using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_056
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            long[] array = ReadLongs();
            Array.Sort(array);
            Array.Reverse(array);
            for(int i = 0; i < nk[0]; i++)
            {
                //Console.WriteLine(array[i]);
            }
            int validIndex = 0;
            for (int i = 0; i < nk[0]; i++)
            {
                long sum = array[i];
                for (int j = validIndex + 1; j < nk[0]; j++)
                {
                    if (sum >= nk[1])
                    {
                        validIndex = j;
                        break;
                    }
                    else
                    {
                        sum += array[j];
                    }
                }
            }
            Console.WriteLine(nk[0] - validIndex);
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
