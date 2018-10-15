using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_097
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int[] ps = ReadInts();
            var xy = new int[nm[1]][];
            for(int i = 0; i < nm[1]; i++)
            {
                xy[i] = ReadInts();
                Array.Sort(xy[i]);
            }
            Array.Sort(xy, (a, b) => a[1] - b[1]);
            Array.Sort(xy, (a, b) => a[0] - b[0]);
            var unionFind = new int[nm[0]];
            for(int i = 0; i < nm[0]; i++)
            {
                unionFind[i] = i;
            }
            for (int i = 0; i < nm[1]; i++)
            {
                //親取得
                int indexL = xy[i][0] - 1;
                while (unionFind[indexL] != indexL)
                {
                    indexL = unionFind[indexL];
                }
                int indexR = xy[i][1] - 1;
                while (unionFind[indexR] != indexR)
                {
                    indexR = unionFind[indexR];
                }
                if(indexL< indexR)
                {
                    unionFind[indexR] = indexL;
                }
                else
                {
                    unionFind[indexL] = indexR;
                }
            }

            for (int i = 0; i < nm[0]; i++)
            {
                int index = i;
                while (unionFind[index] != index)
                {
                    index = unionFind[index];
                }
                unionFind[i] = index;
            }

            var groupDict = new Dictionary<int, Dictionary<int,bool>>();
            for(int i = 0; i < nm[0]; i++)
            {
                if (!groupDict.ContainsKey(unionFind[i]))
                {
                    groupDict.Add(unionFind[i],
                        new Dictionary<int, bool>());
                }
                groupDict[unionFind[i]].Add(ps[i]-1, true);
            }
            int cnt = 0;
            for(int i = 0; i < nm[0]; i++)
            {
                if (groupDict[unionFind[i]].ContainsKey(i))
                {
                    cnt++;
                }
            }

            Console.WriteLine(cnt);
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
