using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeForces._535
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var lrs = new int[n][];
            var reses = new int[n][];
            for(int i = 0; i < n; i++)
            {
                lrs[i] = ReadInts();
                reses[i] = new int[2] { lrs[i][0], lrs[i][2] };
                if (lrs[i][0] == lrs[i][2]) reses[i][0]++;
            }
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(reses[i][0] + " " + reses[i][1]);
            }
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read(),System.Globalization.CultureInfo.InvariantCulture); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), i => Convert.ToDouble(i, System.Globalization.CultureInfo.InvariantCulture)); }
    }
}
