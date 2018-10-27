using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_082
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Read().Split('T');
            var xs = new int[(input.Length + 1) / 2];
            var ys = new int[input.Length / 2];
            int xSum = 0;
            int ySum = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {
                    xs[i / 2] = input[i].Length;
                    //Console.WriteLine("x: " + xs[i / 2]);
                    xSum += xs[i / 2];
                }
                else
                {
                    ys[i / 2] = input[i].Length;
                    //Console.WriteLine("y: " + ys[i / 2]);
                    ySum += ys[i / 2];
                }
            }
            if (ys.Length == 0) ys = new int[1] { 0 };
            int[] tarXY = ReadInts();
            bool xOK = false;
            bool yOK = false;
            var xSums = new Dictionary<int, bool>();
            xSums.Add(0, true);
            var ySums = new Dictionary<int, bool>();
            ySums.Add(0, true);
            if (xs.Length == 1)//最初は+のみ
            {
                xOK = xs[0] == tarXY[0];
            }
            else
            {
                for (int i = 1; i < xs.Length; i++)
                {
                    var tempDict = new Dictionary<int, bool>();
                    foreach (int key in xSums.Keys)
                    {
                        int val = key + xs[i];
                        if (xSum - val * 2 == tarXY[0]
                            || (val+xs[0]) * 2 - xSum == tarXY[0])
                        {
                            xOK = true;
                        }
                        else
                        {
                            tempDict.Add(key + xs[i], true);
                        }

                    }
                    if (xOK) break;
                    foreach (int key in tempDict.Keys)
                    {
                        if (!xSums.ContainsKey(key))
                        {
                            xSums.Add(key, true);
                        }
                    }
                }
            }
            for (int i = 0; i < ys.Length; i++)
            {
                var tempDict = new Dictionary<int, bool>();
                foreach (int key in ySums.Keys)
                {
                    int val = key + ys[i];
                    if (ySum - val * 2 == tarXY[1]
                        || val * 2 - ySum == tarXY[1])
                    {
                        yOK = true;
                    }
                    else
                    {
                        tempDict.Add(key + ys[i], true);
                    }

                }
                if (yOK) break;
                foreach (int key in tempDict.Keys)
                {
                    if (!ySums.ContainsKey(key))
                    {
                        ySums.Add(key, true);
                    }
                }
            }

            if (xOK && yOK)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
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
