using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_069
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] hw = ReadInts();
            int n = ReadInt();
            int[] array = ReadInts();
            var colors = new int[n][];
            for (int i = 0; i < n; i++)
            {
                colors[i] = new int[2] { array[i], i };
            }
            Array.Sort(colors, (a, b) => a[0] - b[0]);
            var grid = new int[hw[0], hw[1]];
            bool forward = true;
            int x = 0;
            int y = 0;
            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine(colors[i][0]);
                for (int j = 0; j < colors[i][0]; j++)
                {
                    grid[y, x] = colors[i][1] + 1;
                    x = forward ? x + 1 : x - 1;
                    if (forward && x == hw[1])
                    {
                        forward = false;
                        x--;
                        y++;
                    }
                    else if (!forward && x == -1)
                    {
                        forward = true;
                        x++;
                        y++;
                    }
                }
            }

            for (int i = 0; i < hw[0]; i++)
            {
                for (int j = 0; j < hw[1]; j++)
                {
                    Console.Write(grid[i, j] + " ");
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
