using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1407
{
    class C
    {
        static void ain(string[] args)
        {
            //var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            //SetOut(sw);

            Method(args);

            //Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] res = new int[n];
            Queue<int[]> que = new Queue<int[]>();
            for (int i = 0; i + 1 < n; i += 2)
            {
                que.Enqueue(new int[2] { i, i + 1 });
            }

            int leftNext = n % 2 == 1 ? n - 1 : -1;
            while (que.Count > 0)
            {
                int[] val = que.Dequeue();
                int left = val[0];
                int right = val[1];

                WriteLine("? " + (left + 1) + " " + (right + 1));
                int lMod = ReadInt();
                WriteLine("? " + (right + 1) + " " + (left + 1));
                int rMod = ReadInt();

                if (lMod < rMod)
                {
                    res[right] = rMod;
                    if (leftNext == -1)
                    {
                        leftNext = left;
                    }
                    else
                    {
                        que.Enqueue(new int[2] { leftNext, left });
                        leftNext = -1;
                    }
                }
                else
                {
                    res[left] = lMod;
                    if (leftNext == -1)
                    {
                        leftNext = right;
                    }
                    else
                    {
                        que.Enqueue(new int[2] { leftNext, right });
                        leftNext = -1;
                    }
                }
            }
            if (leftNext != -1)
            {
                res[leftNext] = n;
            }

            Write("! ");
            for(int i = 0; i < n; i++)
            {
                Write(res[i]);
                if (i + 1 < n)
                {
                    Write(" ");
                }
            }
            WriteLine();
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
