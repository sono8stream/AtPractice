using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_188
{
    class F
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
            long[] xy = ReadLongs();
            long x = xy[0];
            long y = xy[1];

            if (x >= y)
            {
                WriteLine(x - y);
            }
            else
            {
                long res = long.MaxValue;
                var map = new Dictionary<long, long>();
                var que = new Queue<long>();
                que.Enqueue(y);
                res = y - x;
                map.Add(y, 0);
                while (que.Count > 0)
                {
                    long now = que.Dequeue();
                    long cost = map[now];

                    if (now % 2 == 0)
                    {
                        if (!map.ContainsKey(now / 2))
                        {
                            que.Enqueue(now / 2);
                            res = Min(res, cost + 1 + Abs(x - now / 2));
                            map.Add(now / 2, cost + 1);
                        }
                    }
                    else
                    {
                        if (!map.ContainsKey(now + 1))
                        {
                            que.Enqueue(now + 1);
                            res = Min(res, cost + 1 + Abs(x - (now + 1)));
                            map.Add(now + 1, cost + 1);
                        }
                        if (!map.ContainsKey(now - 1))
                        {
                            que.Enqueue(now - 1);
                            res = Min(res, cost + 1 + Abs(x - (now - 1)));
                            map.Add(now - 1, cost + 1);
                        }
                    }
                }

                WriteLine(res);
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
