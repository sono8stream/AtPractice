using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC111
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var poses = new int[n][];
            bool even = false;
            bool canMove = true;
            for(int i = 0; i < n; i++)
            {
                poses[i] = ReadInts();
                if (i == 0)
                {
                    even = (poses[i][0] + poses[i][1]) % 2 == 0;
                }
                else if(even!= ((poses[i][0] + poses[i][1]) % 2 == 0))
                {
                    canMove = false;
                }
            }
            if (!canMove)
            {
                Console.WriteLine(-1);
                return;
            }

            var ds = new long[32];
            for(int i = 0; i < ds.Length; i++)
            {
                ds[i] = (long)Math.Pow(2, i);
            }
            Array.Reverse(ds);
            Console.WriteLine(even ? ds.Length + 1 : ds.Length);
            for(int i = 0; i < ds.Length; i++)
            {
                Console.Write(ds[i]+" ");
            }
            if (even) Console.Write(1);
            Console.WriteLine();
            for(int i = 0; i < n; i++)
            {
                long x = poses[i][0];
                long y = poses[i][1];
                for(int j = 0; j < ds.Length; j++)
                {
                    if (Math.Abs(x) < Math.Abs(y))
                    {
                        if (0 < y)
                        {
                            Console.Write('U');
                            y -= ds[j];
                        }
                        else
                        {
                            Console.Write('D');
                            y += ds[j];
                        }
                    }
                    else
                    {
                        if (0 < x)
                        {
                            Console.Write('R');
                            x -= ds[j];
                        }
                        else
                        {
                            Console.Write('L');
                            x+= ds[j];
                        }
                    }
                }
                if (x != 0)
                {
                    Console.Write(x > 0 ? 'R' : 'L');
                }
                if (y != 0)
                {
                    Console.Write(y > 0 ? 'U' : 'D');
                }
                Console.WriteLine();
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
