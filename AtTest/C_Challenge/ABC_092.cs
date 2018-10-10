using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_092
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
            long sum = 0;
            long now = 0;
            var eachFee = new long[n];
            var skipFee = new long[n];
            for (int i = 0; i < n; i++)
            {
                sum += Math.Abs(array[i] - now);
                if (i == n - 1)
                {
                    eachFee[i]= Math.Abs(array[i] - now)
                        + Math.Abs(array[i]);
                    skipFee[i]=Math.Abs(now);
                }
                else
                {
                    eachFee[i] = Math.Abs(array[i] - now)
                        + Math.Abs(array[i + 1] - array[i]);
                    skipFee[i] = Math.Abs(array[i + 1] - now);
                }
                now = array[i];
            }
            sum += Math.Abs(array[n - 1]);

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(sum - eachFee[i] + skipFee[i]);
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
