using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1462
{
    class D
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
                int sum = array.Sum();
                for(int j = 0; j < n; j++)
                {
                    int cnt = n - j;
                    if (sum % cnt > 0)
                    {
                        continue;
                    }

                    int each = sum / cnt;
                    int now = 0;
                    bool can = true;
                    for(int k = 0; k < n; k++)
                    {
                        if (now + array[k] > each)
                        {
                            can = false;
                            break;
                        }

                        now += array[k];
                        if (now == each)
                        {
                            now = 0;
                        }
                    }
                    if (now > 0)
                    {
                        can = false;
                    }

                    if (can)
                    {
                        WriteLine(j);
                        break;
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
