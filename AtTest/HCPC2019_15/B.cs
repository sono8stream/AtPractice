using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_15
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int m = ReadInt();
            List<int[]> res = new List<int[]>();
            while (m > 0)
            {
                int[][] scores = new int[m][];
                for(int i = 0; i < m; i++)
                {
                    int[] score = ReadInts();
                    int now = 0;
                    int turnNow = 1;
                    for(int j = 1; j < score.Length; j++)
                    {
                        if (turnNow == 10)
                        {
                            while (j < score.Length)
                            {
                                now += score[j];
                                j++;
                            }
                        }
                        else
                        {
                            now += score[j];
                            if (score[j] == 10)
                            {
                                now += score[j + 1] + score[j + 2];
                            }
                            if (score[j] < 10)
                            {
                                j++;
                                now += score[j];
                                if (score[j - 1] + score[j] == 10)
                                {
                                    now += score[j + 1];
                                }
                            }
                            turnNow++;
                        }
                    }

                    scores[i] = new int[2] { score[0], now };
                }
                scores = scores.OrderBy(a => a[0]).ToArray();
                res.AddRange(scores.OrderBy(a => -a[1]));
                m = ReadInt();
            }

            for(int i = 0; i < res.Count; i++)
            {
                WriteLine(res[i][0] + " " + res[i][1]);
            }
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
