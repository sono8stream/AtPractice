using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Codeforces._1426
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
            int t = ReadInt();
            for (int i = 0; i < t; i++)
            {
                int[] nm = ReadInts();
                int n = nm[0];
                int m = nm[1];
                int[][] blocks = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    blocks[j] = new int[4] { 0, 0, 0, 0 };
                    int[] line = ReadInts();
                    blocks[j][0] = line[0];
                    blocks[j][1] = line[1];
                    line = ReadInts();
                    blocks[j][2] = line[0];
                    blocks[j][3] = line[1];
                }

                if (m % 2 == 1)
                {
                    WriteLine("NO");
                }
                else
                {
                    bool[] symmetric = new bool[n];
                    bool ok = false;
                    for (int j = 0; j < n; j++)
                    {
                        symmetric[j] = blocks[j][1] == blocks[j][2];
                        if (symmetric[j])
                        {
                            ok = true;
                            break;
                        }
                    }

                    WriteLine(ok ? "YES" : "NO");
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
