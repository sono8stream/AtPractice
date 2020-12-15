using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1369
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
                string s = Read();

                List<char> res = new List<char>();
                int remainZeros = 0;
                for(int j = n - 1; j >= 0; j--)
                {
                    if (s[j] == '1')
                    {
                        if (remainZeros > 0)
                        {
                            remainZeros = 1;
                        }
                        else
                        {
                            res.Add('1');
                        }
                    }
                    else
                    {
                        remainZeros++;
                    }
                }
                for(int j = 0; j < remainZeros; j++)
                {
                    res.Add('0');
                }

                res.Reverse();
                WriteLine(res.ToArray());
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
