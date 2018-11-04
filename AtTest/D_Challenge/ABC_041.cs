using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_041
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            var bList = new List<List<int>>();
            var eList = new List<List<int>>();
            for(int i = 0; i < nm[0]; i++)
            {
                bList.Add(new List<int>());
                eList.Add(new List<int>());
            }
            var xys = new int[nm[1]][];
            for(int i = 0; i < nm[1]; i++)
            {
                xys[i] = ReadInts();
                int x = xys[i][0] - 1;
                int y = xys[i][1] - 1;
                bList[y].Add(x);
                eList[x].Add(y);
            }
            for(int i = 0; i < nm[0]; i++)
            {
                //if(bList[i].Co)
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
}
