using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_033
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var xy = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xy[i] = ReadInts();

            }
            var dists = new double[n,n];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double dist
                        = Math.Pow(xy[j][0] - xy[i][0], 2)
                        + Math.Pow(xy[j][1] - xy[i][1], 2);
                    dists[i, j] = dist;
                }
            }

            int sharp = 0;
            int right = 0;
            int obtuse = 0;
            for(int i = 0; i < n - 2; i++)
            {
                for(int j = i+1; j < n - 1; j++)
                {
                    for(int k = j + 1; k < n; k++)
                    {
                        var tempDists = new double[3] {
                            dists[i,j],dists[j,k],dists[i,k]};
                        Array.Sort(tempDists);
                        double margin 
                            = tempDists[2] - tempDists[1] - tempDists[0];
                        if (margin > 0) obtuse++;
                        else if (margin == 0) right++;
                        else sharp++;
                    }
                }
            }

            Console.WriteLine(sharp + " " + right + " " + obtuse);
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
