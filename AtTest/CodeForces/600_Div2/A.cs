using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._600_Div2
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
                int n = ReadInt();
                int[] aArray = ReadInts();
                int[] bArray = ReadInts();

                bool start = false;
                bool end = false;
                int delta = 0;
                bool can = true;
                for(int j = 0; j < n; j++)
                {
                    if (aArray[j] > bArray[j]
                        || (end && aArray[j] < bArray[j]))
                    {
                        can = false;
                        break;
                    }
                    else if (aArray[j] == bArray[j])
                    {
                        if (start)
                        {
                            end = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (start)
                        {
                            int deltaTmp = bArray[j] - aArray[j];
                            if (deltaTmp != delta)
                            {
                                can = false;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            delta = bArray[j] - aArray[j];
                            start = true;
                        }
                    }
                }

                WriteLine(can ? "YES" : "NO");
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
