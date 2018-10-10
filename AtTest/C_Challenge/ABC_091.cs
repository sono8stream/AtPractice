using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_091
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var ab = new int[n][];
            var cd = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] input = ReadInts();
                ab[i] = new int[2];
                ab[i][0] = input[0];
                ab[i][1] = input[1];
            }
            for (int i = 0; i < n; i++)
            {
                int[] input = ReadInts();
                cd[i] = new int[2];
                cd[i][0] = input[0];
                cd[i][1] = input[1];
            }
            Array.Sort(ab, (a, b) => a[0] - b[0]);
            Array.Sort(cd, (a, b) => a[0] - b[0]);
            int pairCnt = 0;
            for (int i = 0; i < n; i++)
            {
                int aIndex = n - 1;
                for (; aIndex >= 0; aIndex--)
                {
                    if (ab[aIndex][0] > cd[i][0])
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                if (aIndex == -1)
                {
                    continue;
                }
                int redIndex = -1;
                for (int j = 0; j <=aIndex; j++)
                {
                    if (cd[i][1] < ab[j][1])
                    {
                        continue;
                    }
                    else if (redIndex == -1
                            || ab[redIndex][1] < ab[j][1])
                    {
                        redIndex = j;
                    }
                }
                if (redIndex != -1)
                {
                    pairCnt++;
                    ab[redIndex][1] = 3000;
                }
            }
            Console.WriteLine(pairCnt);
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
