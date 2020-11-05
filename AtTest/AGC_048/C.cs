using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_048
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
            int[] nl = ReadInts();
            int n = nl[0];
            int l = nl[1];

            int[] aArray = new int[n + 2];
            int[] bArray = new int[n + 2];
            aArray[0] = 0;
            bArray[0] = 0;
            aArray[n + 1] = l + 1;
            bArray[n + 1] = l + 1;
            int[] aArrayTmp = ReadInts();
            int[] bArrayTmp = ReadInts();
            for(int i = 0; i < n; i++)
            {
                aArray[i + 1] = aArrayTmp[i];
                bArray[i + 1] = bArrayTmp[i];
            }

            n += 2;
            int[] dirs = new int[n];
            List<int> ends = new List<int>();
            List<int> starts = new List<int>();
            for(int i = 1; i < n; i++)
            {
                if (aArray[i] > bArray[i])
                {
                    dirs[i] = -1;
                    if (dirs[i - 1] == 1)
                    {
                        WriteLine(-1);
                        return;
                    }
                    if (dirs[i - 1] == 0)
                    {
                        ends.Add(i);
                    }
                }
                if (aArray[i] == bArray[i])
                {
                    if (dirs[i - 1] == -1)
                    {
                        starts.Add(i - 1);
                    }
                    if (dirs[i - 1] == 1)
                    {
                        ends.Add(i - 1);
                    }
                }
                if (aArray[i] < bArray[i])
                {
                    dirs[i] = 1;
                    if (dirs[i - 1] == -1)
                    {
                        starts.Add(i - 1);
                        starts.Add(i);
                    }
                    if (dirs[i - 1] == 0)
                    {
                        starts.Add(i);
                    }
                }
            }

            long res = 0;
            for (int i = 0; i < starts.Count; i++)
            {
                int dir = dirs[starts[i]];
                int front = starts[i];
                int cnt = Abs(starts[i] - ends[i]) + 1;
                for (int j = 0; j < cnt; j++)
                {
                    int idx = starts[i] + j * dir;
                    int to = bArray[starts[i] + j * dir];
                    bool move = false;

                    while (true)
                    {
                        int stop;
                        stop = aArray[front] - Abs(front - idx) * dir;
                        if (stop == to)
                        {
                            if (move)
                            {
                                res += Abs(front - idx);
                            }

                            break;
                        }
                        else
                        {
                            if (dirs[front] == 0)
                            {
                                WriteLine(-1);
                                return;
                            }
                            else
                            {
                                move = true;
                                front += dir;
                            }
                        }
                    }
                }
            }

            WriteLine(res);
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
