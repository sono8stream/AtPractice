using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest.AGC_029
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] hwn = ReadInts();
            int h = hwn[0];
            int w = hwn[1];
            int n = hwn[2];
            var obsPos = new int[n][];
            for (int i = 0; i < n; i++)
            {
                obsPos[i] = ReadInts();
            }
            obsPos = obsPos.OrderBy(a => a[0]).ToArray();
            var xList = new List<int>[w];
            for (int i = 0; i < w; i++) xList[i] = new List<int>();
            for (int i = 0; i < n; i++)
            {
                xList[obsPos[i][1] - 1].Add(obsPos[i][0]);
            }
            for (int i = 0; i < w; i++) xList[i].Add(h + 1);

            int res = h;
            int min = 0;
            for (int i = 0; i < w; i++)
            {
                min++;
                int j = 0;
                while (j < xList[i].Count && xList[i][j] <= min)
                {
                    if (xList[i][j] == min) min++;
                    j++;
                }
                if (j < xList[i].Count) res = Math.Min(res, xList[i][j] - 1);
            }
            Console.WriteLine(res);
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
