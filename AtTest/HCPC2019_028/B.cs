using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_028
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
            string s = Read();
            int[] g = ReadInts();
            int gx = g[0];
            int gy = g[1];

            if (gx == 0 && gy == 0)
            {
                WriteLine("Yes");
                return;
            }

            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };

            bool can = false;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (i == j) continue;
                    for(int k = 0; k < 4; k++)
                    {
                        if (k == i || k == j) continue;
                        for(int l = 0; l < 4; l++)
                        {
                            if (l == i || l == j || l == k) continue;

                            int x = 0;
                            int y = 0;
                            for(int ii = 0; ii < s.Length; ii++)
                            {
                                switch (s[ii])
                                {
                                    case 'W':
                                        x += dx[i];
                                        y += dy[i];
                                        break;
                                    case 'X':
                                        x += dx[j];
                                        y += dy[j];
                                        break;
                                    case 'Y':
                                        x += dx[k];
                                        y += dy[k];
                                        break;
                                    case 'Z':
                                        x += dx[l];
                                        y += dy[l];
                                        break;
                                }
                                if (x == gx && y == gy)
                                {
                                    can = true;
                                }
                            }
                        }
                    }
                }
            }

            if (can) WriteLine("Yes");
            else WriteLine("No");
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
