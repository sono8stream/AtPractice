using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class AGC045_A
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
                string s = Read();

                List<long> bases = new List<long>();
                bool can = true;
                for(int j = n - 1; j >= 0; j--)
                {
                    long val = array[j];
                    bases.Sort();
                    bases.Reverse();
                    for(int k = 0; k < bases.Count; k++)
                    {
                        val = Min(val, val ^ bases[k]);
                    }

                    if (s[j] == '0')
                    {
                        if (val > 0)
                        {
                            bases.Add(val);
                        }
                    }
                    else
                    {
                        if (val > 0)
                        {
                            can = false;
                            break;
                        }
                    }
                }

                WriteLine(can ? 0 : 1);
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
