using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1395
{
    class B
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
            int[] nmxy = ReadInts();
            int n = nmxy[0];
            int m = nmxy[1];
            int x = nmxy[2] - 1;
            int y = nmxy[3] - 1;

            bool[,] visited = new bool[n, m];
            WriteLine((x + 1) + " " + (y + 1));
            visited[x, y] = true;
            VisitRow(visited, x,false);
            bool rev = true;
            for(int i = 0; i < n; i++)
            {
                if (visited[i, 0])
                {
                    continue;
                }
                VisitRow(visited, i,rev);
                rev = !rev;
            }
            // First line

        }

        static void VisitRow(bool[,] visited,int rowNo,bool reverse)
        {
            int width = visited.GetLength(1);
            for(int i = 0; i < visited.GetLength(1); i++)
            {
                int yy = reverse ? width - i - 1 : i;
                if (visited[rowNo, yy])
                {
                    continue;
                }
                WriteLine((rowNo + 1) + " " + (yy + 1));
                visited[rowNo, yy] = true;
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
