using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
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
            int[] ab = ReadInts();
            var grid = new bool[100, 100];
            for(int i = 50; i< 100; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    grid[i, j] = true;
                }
            }
            ab[0]--;
            ab[1]--;
            for(int i = 0; i < 100; i += 2)
            {
                if (i < 49)
                {
                    for (int j = 0; j < 100; j += 2)
                    {
                        if (ab[1] > 0)
                        {
                            grid[i, j] = !grid[i, j];
                            ab[1]--;
                        }
                    }
                }
                else if (50 < i)
                {
                    for (int j = 0; j < 100; j += 2)
                    {
                        if (ab[0] > 0)
                        {
                            grid[i, j] = !grid[i, j];
                            ab[0]--;
                        }
                    }
                }
                else continue;
            }

            Console.WriteLine("100 100");
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    char c = grid[i, j] ? '#' : '.';
                    Console.Write(c);
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
