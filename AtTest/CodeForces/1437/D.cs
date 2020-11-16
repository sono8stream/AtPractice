using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1437
{
    class D
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
                int n = ReadInt();
                int[] array = ReadInts();
                Queue<int> que = new Queue<int>();
                for(int j = 1; j < n; j++)
                {
                    que.Enqueue(array[j]);
                }

                int depth = 0;
                int nodes = 1;
                while (true)
                {
                    int nextNodes = 0;
                    while (nodes > 0)// 葉に生やせるだけ生やす
                    {
                        int prev = 0;
                        while (que.Count > 0 && que.Peek() > prev)
                        {
                            nextNodes++;
                            prev = que.Dequeue();
                        }
                        nodes--;
                    }
                    depth++;
                    nodes = nextNodes;
                    if (que.Count == 0)
                    {
                        break;
                    }
                }
                WriteLine(depth);
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
