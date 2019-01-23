using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeForces._535
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            string lamp = Read();
            char[] lamps = lamp.ToCharArray();
            int res = int.MaxValue;
            char[] resCs = new char[n];
            string[] pats = new string[6] {
                "RGB", "RBG", "GRB", "GBR", "BRG", "BGR", };
            for(int i = 0; i < pats.Length; i++)
            {
                int cnt = 0;
                char[] cs = new char[n];
                for(int j = 0; j < n; j++)
                {
                    if (lamps[j] != pats[i][j % 3]) cnt++;
                    cs[j] = pats[i][j % 3];
                }
                if (res > cnt)
                {
                    res = cnt;
                    resCs = cs;
                }
            }
            Console.WriteLine(res);
            Console.WriteLine(resCs);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read(), System.Globalization.CultureInfo.InvariantCulture); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), i => Convert.ToDouble(i, System.Globalization.CultureInfo.InvariantCulture)); }
    }
}
