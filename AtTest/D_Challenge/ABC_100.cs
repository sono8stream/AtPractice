using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_100
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var xs = new long[nm[0]];
            var ys = new long[nm[0]];
            var zs = new long[nm[0]];
            for (int i = 0; i < nm[0]; i++)
            {
                long[] input = ReadLongs();
                xs[i] = input[0];
                ys[i] = input[1];
                zs[i] = input[2];
            }

            if (nm[1] == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var absMax = new Value[nm[0], nm[1]];//1つめからi個目まででj個選んだ時の最大値
            absMax[0, 1]
                = new Value(xs[0], ys[0], zs[0],
                    Math.Abs(xs[0]) + Math.Abs(ys[0]) + Math.Abs(zs[0]));
            for (int i = 1; i < nm[0]; i++)
            {

            }

            Console.WriteLine("text");
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }

    struct Value
    {
        public long x;
        public long y;
        public long z;
        public long sum;

        public Value(long x,long y,long z,long sum)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.sum = sum;
        }
    }
}
