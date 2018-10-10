using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_086
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var ts = new int[n];
            var xs = new int[n];
            var ys = new int[n];
            for(int i = 0; i < n; i++)
            {
                int[] input = ReadInts();
                ts[i] = input[0];
                xs[i] = input[1];
                ys[i] = input[2];
            }

            int time = 0;
            int nowX = 0;
            int nowY = 0;
            for(int i = 0; i < n; i++)
            {
                int span = ts[i] - time;
                int distance 
                    = Math.Abs(xs[i] - nowX) + Math.Abs(ys[i] - nowY);
                if (distance <= span && distance % 2 == span % 2)
                {
                    time = ts[i];
                    nowX = xs[i];
                    nowY = ys[i];
                    //Console.WriteLine("OK");
                    continue;
                }
                else
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
