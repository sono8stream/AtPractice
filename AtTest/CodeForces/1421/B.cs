using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1421
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
                int n = ReadInt();
                int[,] grid = new int[n, n];
                for (int j = 0; j < n; j++)
                {
                    string row = Read();
                    for (int k = 0; k < n; k++)
                    {
                        if (row[k] == '0')
                        {
                            grid[j, k] = 1;
                        }
                        if (row[k] == '1')
                        {
                            grid[j, k] = 2;
                        }
                    }
                }

                int[] changeXs = new int[4] { 1, 2, n - 1, n  };
                int[] changeYs = new int[4] { 2, 1, n, n - 1 };
                int[] states = new int[4];
                for(int j = 0; j < 4; j++)
                {
                    states[j] = grid[changeYs[j]-1, changeXs[j]-1];
                }

                bool startDelta = states[0] != states[1];
                bool endDelta = states[2] != states[3];
                if (startDelta && endDelta)
                {
                    WriteLine(2);
                    WriteLine(changeYs[1] + " " + changeXs[1]);
                    if (states[0] == states[2])
                    {
                        WriteLine(changeYs[2] + " " + changeXs[2]);
                    }
                    else
                    {
                        WriteLine(changeYs[3] + " " + changeXs[3]);
                    }
                }
                else if(startDelta)
                {
                    WriteLine(1);
                    if (states[0] == states[2])
                    {
                        WriteLine(changeYs[0] + " " + changeXs[0]);
                    }
                    else
                    {
                        WriteLine(changeYs[1] + " " + changeXs[1]);
                    }
                }
                else if (endDelta)
                {
                    WriteLine(1);
                    if (states[0] == states[2])
                    {
                        WriteLine(changeYs[2] + " " + changeXs[2]);
                    }
                    else
                    {
                        WriteLine(changeYs[3] + " " + changeXs[3]);
                    }
                }
                else
                {
                    if (states[0] == states[2])
                    {
                        WriteLine(2);
                        WriteLine(changeYs[0] + " " + changeXs[0]);
                        WriteLine(changeYs[1] + " " + changeXs[1]);
                    }
                    else
                    {
                        WriteLine(0);
                    }
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
