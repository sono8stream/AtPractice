using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_065
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var xys = new int[n][];
            var xys2 = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] xy = ReadInts();
                xys[i] = new int[3] { xy[0], xy[1], i };
                xys2[i] = new int[3] { xy[0], xy[1],i };
            }
            Array.Sort(xys, (a, b) => a[0] - b[0]);
            Array.Sort(xys2, (a, b) => a[1] - b[1]);
            var indexArray = new int[n][];
            for(int i = 0; i < n; i++)
            {
                indexArray[xys[i][2]] = new int[2] { i, 0 };
            }
            for(int i = 0; i < n; i++)
            {
                indexArray[xys2[i][2]][1] = i;
            }
            long res = 0;

            for(int i = 0; i < n; i++)
            {
                int delta = int.MaxValue;
                if (indexArray[i][0] > 0)
                    delta = Math.Min(delta,
                        Math.Abs(xys[indexArray[i][0]][0]
                        - xys[indexArray[i][0]-1][0]));
                if (indexArray[i][0] < n - 1)
                    delta = Math.Min(delta,
                        Math.Abs(xys[indexArray[i][0]][0]
                        - xys[indexArray[i][0]+1][0]));
                if (indexArray[i][1] > 0)
                    delta = Math.Min(delta,
                        Math.Abs(xys2[indexArray[i][1]][1]
                        - xys2[indexArray[i][1] - 1][1]));
                if (indexArray[i][1] <n-1)
                    delta = Math.Min(delta,
                        Math.Abs(xys2[indexArray[i][1]][1]
                        - xys2[indexArray[i][1] + 1][1]));
                Console.WriteLine(delta);
                res += delta;
            }
            Console.WriteLine(res);
            /*
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(indexArray[i][0] + " " + indexArray[i][1]);
            }
            */
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
