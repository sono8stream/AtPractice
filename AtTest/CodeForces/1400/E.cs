using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1400
{
    class E
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();

            WriteLine(GetCnt(array, 0, n - 1));
        }

        static int GetCnt(int[] array,int l,int r)
        {
            // separate
            List<int[]> areas = new List<int[]>();
            int left = -1;
            for(int i = l; i <= r; i++)
            {
                if (array[i] == 0)
                {
                    if (left != -1)
                    {
                        areas.Add(new int[2] { left, i - 1 });
                    }
                    left = -1;
                }
                else
                {
                    if (left == -1)
                    {
                        left = i;
                    }
                }
            }
            if (left != -1)
            {
                areas.Add(new int[2] { left, r });
            }

            int cnt = 0;
            for(int i = 0; i < areas.Count; i++)
            {
                int tmp = areas[i][1] - areas[i][0] + 1;

                int min = int.MaxValue;
                for(int j = areas[i][0]; j <= areas[i][1]; j++)
                {
                    min = Min(min, array[j]);
                }

                if (tmp >= min)
                {
                    for (int j = areas[i][0]; j <= areas[i][1]; j++)
                    {
                        array[j] -= min;
                    }
                    tmp = Min(tmp, min + GetCnt(array, areas[i][0], areas[i][1]));
                }
                cnt += tmp;
            }
            return cnt;
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
