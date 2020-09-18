using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.M_Solutions_2020
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
            int n = ReadInt();
            int[][] xyus = new int[n][];
            for (int i = 0; i < n; i++)
            {
                string[] input = Read().Split();
                xyus[i] = new int[3] { int.Parse(input[0]), int.Parse(input[1]), 0 };
                if (input[2][0] == 'R')
                {
                    xyus[i][2] = 1;
                }
                if (input[2][0] == 'D')
                {
                    xyus[i][2] = 2;
                }
                if (input[2][0] == 'L')
                {
                    xyus[i][2] = 3;
                }
            }

            Array.Sort(xyus, (a, b) =>
            {
                if (a[0] == b[0])
                {
                    return a[1] - b[1];
                }
                else
                {
                    return a[0] - b[0];
                }
            });

            int lineLength = 200000 + 10;
            int[,] horizon = new int[lineLength * 2, 4];
            int[,] vertical = new int[lineLength * 2, 4];
            int[,] tilt1 = new int[lineLength * 2, 4]; // 45
            int[,] tilt2 = new int[lineLength * 2, 4]; // -45
            for (int i = 0; i < lineLength * 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    horizon[i, j] = -1;
                    vertical[i, j] = -1;
                    tilt1[i, j] = -1;
                    tilt2[i, j] = -1;
                }
            }

            int res = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int horizonId = xyus[i][1];
                int verticalId = xyus[i][0];
                int tilt1Id = xyus[i][0] + lineLength - xyus[i][1];
                int tilt2Id = xyus[i][0] + xyus[i][1];

                if (xyus[i][2] == 0)
                {
                    if (tilt2[tilt2Id, 1] >= 0)
                    {
                        res = Min(res, 10 * (xyus[i][0] - tilt2[tilt2Id, 1]));
                    }
                }
                if (xyus[i][2] == 2)
                {
                    if (vertical[verticalId, 0] >= 0)
                    {
                        res = Min(res, 5 * (xyus[i][1] - vertical[verticalId, 0]));
                    }
                    if (tilt1[tilt1Id, 1] >= 0)
                    {
                        res = Min(res, 10 * (xyus[i][0] - tilt1[tilt1Id, 1]));
                    }
                }
                if (xyus[i][2] == 3)
                {
                    if (horizon[horizonId, 1] >= 0)
                    {
                        res = Min(res, 5 * (xyus[i][0] - horizon[horizonId, 1]));
                    }
                    if (tilt1[tilt1Id, 0] >= 0)
                    {
                        res = Min(res, 10 * (xyus[i][0] - tilt1[tilt1Id, 0]));
                    }
                    if (tilt2[tilt2Id, 2] >= 0)
                    {
                        res = Min(res, 10 * (xyus[i][0] - tilt2[tilt2Id, 2]));
                    }
                }

                horizon[horizonId, xyus[i][2]] = xyus[i][0];
                vertical[verticalId, xyus[i][2]] = xyus[i][1];
                tilt1[tilt1Id, xyus[i][2]] = xyus[i][0];
                tilt2[tilt2Id, xyus[i][2]] = xyus[i][0];
            }

            if (res == int.MaxValue)
            {
                WriteLine("SAFE");
            }
            else
            {
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
