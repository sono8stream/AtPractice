﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ1B
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] tw = ReadInts();
            int t = tw[0];
            int w = tw[1];
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
        }

        static Action Solve()
        {
            /*
            long[] rs = new long[6];
            WriteLine(300);
            long val56 = ReadLong();
            rs[4] = 
            long v4 = ReadLong();
            WriteLine(5);
            long v5 = ReadLong();

            for(int i1 = 0; i1 <= 100; i1++)
            {
                rs[0] = i1;
                rs[5]=
                for(int i2 = 0; i2 <= 100; i2++)
                {
                    rs[1] = i2;
                    for(int i3 = 0; i3 <= 100; i3++)
                    {
                        rs[2] = i3;
                        for(int i4 = 0; i4 <= 100; i4++)
                        {
                            rs[3] = i4;

                        }
                    }
                }
            }

            for(int i = 0; i < 6; i++)
            {
                Write(rs[i]);
                if (i < 5) Write(' ');
            }
            WriteLine();

            ReadLine();
            */
            return () => WriteLine("POSSIBLE");
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
