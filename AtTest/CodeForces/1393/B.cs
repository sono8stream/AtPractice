using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1393
{
    class B
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            int q = ReadInt();

            int all = 100000;
            int[] cnts = new int[all];
            int[] multis = new int[9];
            for(int i = 0; i < n; i++)
            {
                int len = array[i] - 1;
                cnts[len]++;
            }
            for(int i = 0; i < all; i++)
            {
                int cnt = Min(cnts[i], 8);
                multis[cnt]++;
            }

            for (int i = 0; i < q; i++)
            {
                string[] row = Read().Split();
                int len = int.Parse(row[1]) - 1;
                multis[Min(cnts[len], 8)]--;
                if (row[0][0] == '+')
                {
                    cnts[len]++;
                }
                else
                {
                    cnts[len]--;
                }
                multis[Min(cnts[len], 8)]++;

                int moreEight = multis[8];
                int moreSix = multis[6] + multis[7];
                int moreFour = multis[4] + multis[5];
                int moreTwo = multis[2] + multis[3];
                if (moreEight >= 1
                    || (moreSix >= 1 && (moreSix >= 2 || moreFour >= 1 || moreTwo >= 1))
                    || (moreFour >= 1 && (moreFour >= 2 || moreTwo >= 2)))
                {
                    WriteLine("YES");
                }
                else
                {
                    WriteLine("NO");
                }
            }
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
