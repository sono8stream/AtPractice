using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ARC076_E
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
            int[] rcn = ReadInts();
            int r = rcn[0];
            int c = rcn[1];
            int n = rcn[2];
            List<int[]> vals = new List<int[]>();
            for(int i = 0; i < n; i++)
            {
                int[] xy = ReadInts();
                if ((xy[0] == 0 || xy[0] == r || xy[1] == 0 || xy[1] == c)
                    && (xy[2] == 0 || xy[2] == r || xy[3] == 0 || xy[3] == c))
                {
                    int left = 0;
                    if (xy[0] == 0)
                    {
                        left = xy[1];
                    }
                    else if (xy[1] == c)
                    {
                        left = c + xy[0];
                    }
                    else if (xy[0] == r)
                    {
                        left = c * 2 + r - xy[1];
                    }
                    else
                    {
                        left = c * 2 + r * 2 - xy[0];
                    }

                    int right = 0;
                    if (xy[2] == 0)
                    {
                        right = xy[3];
                    }
                    else if (xy[3] == c)
                    {
                        right = c + xy[2];
                    }
                    else if (xy[2] == r)
                    {
                        right = c * 2 + r - xy[3];
                    }
                    else
                    {
                        right = c * 2 + r * 2 - xy[2];
                    }

                    vals.Add(new int[2] { left, i });
                    vals.Add(new int[2] { right, i });
                }
            }

            vals = vals.OrderBy(a => a[0]).ToList();
            Stack<int> indexes = new Stack<int>();
            for(int i = 0; i < vals.Count; i++)
            {
                if (indexes.Count > 0 && indexes.Peek() == vals[i][1])
                {
                    indexes.Pop();
                }
                else
                {
                    indexes.Push(vals[i][1]);
                }
            }

            WriteLine(indexes.Count == 0 ? "YES" : "NO");
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
