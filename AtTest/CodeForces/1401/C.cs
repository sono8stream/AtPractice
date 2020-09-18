using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Codeforces._1401
{
    class C
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
                int min = array.Min();
                bool[] can = new bool[n];
                List<int> vals = new List<int>();
                for(int j = 0; j < n; j++)
                {
                    if (array[j] % min == 0)
                    {
                        can[j] = true;
                        vals.Add(array[j]);
                    }
                }

                vals.Sort();
                bool ok = true;
                int prev = -1;
                for(int j = 0; j < n; j++)
                {
                    if (can[j])
                    {
                        if (prev <= vals[0])
                        {
                            prev = vals[0];
                            vals.RemoveAt(0);
                        }
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                    else
                    {
                        if (prev <= array[j])
                        {
                            prev = array[j];
                        }
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                WriteLine(ok ? "YES" : "NO");
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
