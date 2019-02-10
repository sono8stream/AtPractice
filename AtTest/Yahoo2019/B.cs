using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Yahoo2019
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[][] paths = new int[3][];
            paths[0] = ReadInts();
            paths[1] = ReadInts();
            paths[2] = ReadInts();
            int[] cnts = new int[4];
            for(int i = 0; i < 3; i++)
            {
                cnts[paths[i][0] - 1]++;
                cnts[paths[i][1] - 1]++;
            }
            Array.Sort(cnts);
            if(cnts[0]==1&& cnts[1] == 1
                && cnts[2] == 2&& cnts[3] == 2)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
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
