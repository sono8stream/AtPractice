using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1364
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
            for(int i = 0; i < t; i++)
            {
                int n = ReadInt();
                long[] array = ReadLongs();
                List<long> res = new List<long>();
                bool inc = array[1] > array[0];
                res.Add(array[0]);
                res.Add(array[1]);
                for(int j = 2; j < n; j++)
                {
                    if (inc)
                    {
                        if (array[j - 1] < array[j])
                        {
                            res[res.Count - 1] = array[j];
                        }
                        else
                        {
                            inc = false;
                            res.Add(array[j]);
                        }
                    }
                    else
                    {
                        if (array[j - 1] < array[j])
                        {
                            inc = true;
                            res.Add(array[j]);
                        }
                        else
                        {
                            res[res.Count - 1] = array[j];
                        }
                    }
                }

                WriteLine(res.Count);
                for(int j = 0; j < res.Count; j++)
                {
                    Write(res[j]);
                    if (j + 1 < res.Count)
                    {
                        Write(" ");
                    }
                }
                WriteLine();
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
