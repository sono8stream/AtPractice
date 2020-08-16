using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_044
{
    class A
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
                long[] nabcd = ReadLongs();
                long n = nabcd[0];
                long a = nabcd[1];
                long b = nabcd[2];
                long c = nabcd[3];
                long d = nabcd[4];

                var dict = new Dictionary<long, long>();
                var que = new Queue<long[]>();
                que.Enqueue(new long[2] { n, 0 });
                while (que.Count > 0)
                {
                    long[] val = que.Dequeue();
                    long now = val[0];
                    long cnt = val[1];
                    if (dict.ContainsKey(now) && dict[now] <= cnt)
                    {
                        continue;
                    }

                    if (dict.ContainsKey(now))
                    {
                        dict[now] = cnt;
                    }
                    else
                    {
                        dict.Add(now, cnt);
                    }

                    if (now == 0)
                    {
                        continue;
                    }

                    if (now >= 2)
                    {
                        que.Enqueue(new long[2] { now / 2, cnt + a + now % 2 * d });
                        que.Enqueue(new long[2] { now / 2 + 1, cnt + a + (2 - now % 2) * d });
                    }
                    if (now >= 3)
                    {
                        que.Enqueue(new long[2] { now / 3, cnt + b + now % 3 * d });
                        que.Enqueue(new long[2] { now / 3 + 1, cnt + b + (3 - now % 3) * d });
                    }
                    if (now >= 5)
                    {
                        que.Enqueue(new long[2] { now / 5, cnt + c + now % 5 * d });
                        que.Enqueue(new long[2] { now / 5 + 1, cnt + c + (5 - now % 5) * d });
                    }
                    if ((double)now * d < long.MaxValue)
                    {
                        que.Enqueue(new long[2] { 0, cnt + now * d });
                    }
                }

                WriteLine(dict[0]);
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
