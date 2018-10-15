using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_087
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var lrds = new long[nm[1]][];
            for(int i = 0; i < nm[1]; i++)
            {
                lrds[i] = ReadLongs();
                if (lrds[i][0] > lrds[i][1])//swap
                {
                    lrds[i][0] += lrds[i][1];
                    lrds[i][1] = lrds[i][0] - lrds[i][1];
                    lrds[i][0] -= lrds[i][1];
                    lrds[i][2] *= -1;
                }
            }
            Array.Sort(lrds, (a, b) => (int)a[0] - (int)b[0]);
            /*var unionFind = new long[nm[0]];
            for (int i = 0; i < nm[0]; i++)
            {
                unionFind[i] = -1;
            }
            for(int i = 0; i < nm[1]; i++)
            {
                int minIndex = (int)Math.Min(lrds[i][0], lrds[i][1]);
                int maxIndex = (int)Math.Max(lrds[i][0], lrds[i][1]);
                if (unionFind[maxIndex - 1] == -1)
                {
                    unionFind[maxIndex - 1] = minIndex - 1;
                }
            }*/
            var poses = new long[nm[0]];
            var posSetted = new bool[nm[0]];
            posSetted[0] = true;
            for (int i = 0; i < nm[1]; i++)
            {
                if (!posSetted[lrds[i][1] - 1])
                {
                    poses[lrds[i][1] - 1]
                        = poses[lrds[i][0] - 1] + lrds[i][2];
                    posSetted[lrds[i][1] - 1] = true;
                }
                else if (poses[lrds[i][1] - 1]
                    != poses[lrds[i][0] - 1] + lrds[i][2])
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
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
