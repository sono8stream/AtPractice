using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1447
{
    class C
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
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                long[] nw = ReadLongs();
                int n = (int)nw[0];
                long w = nw[1];
                int[] vals = ReadInts();
                int[][] array = new int[n][];
                for(int j = 0; j < n; j++)
                {
                    array[j] = new int[2] { vals[j], j };
                }
                Array.Sort(array, (a, b) => a[0] - b[0]);

                long min = (w + 1) / 2;
                bool[] use = new bool[n];
                long sum = 0;
                int useCnt = 0;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (sum + array[j][0] <= w)
                    {
                        sum += array[j][0];
                        use[array[j][1]] = true;
                        useCnt++;
                    }
                }

                if (sum < min)
                {
                    WriteLine(-1);
                }
                else
                {
                    WriteLine(useCnt);
                    int nowCnt = 0;
                    for(int j = 0; j < n; j++)
                    {
                        if (use[j])
                        {
                            Write(j + 1);
                            nowCnt++;
                            if (nowCnt < useCnt)
                            {
                                Write(" ");
                            }
                        }
                    }
                    WriteLine();
                }
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
