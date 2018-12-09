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
            long n = ReadInt();
            var xy = new int[n][];
            for(int i = 0; i < n; i++)
            {
                xy[i] = ReadInts();
            }

            long rightCnt = 0;
            long obtuseCnt = 0;
            for (int i = 0; i < n; i++)
            {
                var angles = new double[n-1];
                for (int j = 0; j < n; j++)
                {
                    if (j == i) continue;
                    double angle = Math.Atan2(
                        xy[j][1] - xy[i][1], xy[j][0] - xy[i][0]);
                    if (j < i)
                    {
                        angles[j] = angle;
                    }
                    else
                    {
                        angles[j - 1] = angle;
                    }
                }
                Array.Sort(angles);
                Array.Reverse(angles);
                var anglesTwice = new double[2 * (n - 1)];
                for(int j = 0; j < n - 1; j++)
                {
                    anglesTwice[j] = angles[j];
                    anglesTwice[j + n - 1] = angles[j] - 2 * Math.PI;
                    //Console.WriteLine(angles[j] + " ");
                }
                //Console.WriteLine();
                int sharp = 0;
                int right = 0;
                int obtuse = 0;
                for(int j = 0; j < n - 1; j++)
                {
                    while (sharp<anglesTwice.Length
                        &&anglesTwice[j] - anglesTwice[sharp] < Math.PI / 2)
                    {
                        sharp++;
                    }
                    right = sharp;
                    while (right < anglesTwice.Length
                        &&anglesTwice[j] - anglesTwice[right] == Math.PI / 2)
                    {
                        right++;
                    }
                    obtuse = right;
                    while (obtuse < anglesTwice.Length
                        && anglesTwice[j] - anglesTwice[obtuse] < Math.PI)
                    {
                        obtuse++;
                    }
                    rightCnt += right - sharp;
                    obtuseCnt += obtuse - right;
                    //Console.WriteLine(sharp + " " + right + " " + obtuse);
                }
            }
            long sharpCnt = n * (n -1) * (n - 2) / 6 - rightCnt - obtuseCnt;
            Console.WriteLine(sharpCnt + " " + rightCnt + " " + obtuseCnt);
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
