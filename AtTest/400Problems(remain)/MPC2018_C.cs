using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtTest._400Problems_remain_
{
    class MPC2018_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            bool[,] ss = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                string s = Read();
                for (int j = 0; j < m; j++)
                {
                    ss[i, j] = s[j] == '.';
                }
            }
            long[,] sideParent = new long[n, m];
            long[,] sideCnt = new long[n, m];
            for (int i = 0; i < n; i++)
            {
                int left = -1;
                for (int j = 0; j < m; j++)
                {
                    if (ss[i, j])
                    {
                        if (left == -1)
                        {
                            left = j;
                            sideParent[i, j] = j;
                            sideCnt[i, j] = 1;
                        }
                        else
                        {
                            sideParent[i, j] = left;
                            sideCnt[i, left]++;
                        }
                    }
                    else left = -1;
                }
            }
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    //Console.Write(sideCnt[i, sideParent[i, j]] + " ");
                }
                //Console.WriteLine();
            }
            long res = 0;
            for (int j = 0; j < m; j++)
            {
                long cnt = 0;
                long sum = 0;
                for (int i = 0; i < n; i++)
                {
                    if (ss[i, j])
                    {
                        cnt++;
                        sum += sideCnt[i, sideParent[i, j]] - 1;
                    }
                    else
                    {
                        //Console.WriteLine(sum);
                        for(int k = 0; k < cnt; k++)
                        {
                            res += sum - (sideCnt[i - k - 1,
                                sideParent[i - k - 1, j]] - 1);
                            /*Console.WriteLine(
                                i - k - 1 + " " + sideParent[i - k - 1, j]);
                            Console.WriteLine(sum - (sideCnt[i - k - 1,
                                sideParent[i - k - 1, j]] - 1));*/
                        }
                        cnt = 0;
                        sum = 0;
                    }
                    //Console.WriteLine(res);
                }
                //Console.WriteLine(sum);
                for (int k = 0; k < cnt; k++)
                {
                    res += sum - (sideCnt[n-k - 1,
                        sideParent[n - k - 1, j]] - 1);
                }
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
