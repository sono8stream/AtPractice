using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1430
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
                string s = Read();

                List<int> blocks = new List<int>();
                int left = -1;
                for(int j = 0; j < n; j++)
                {
                    if (left == -1)
                    {
                        left = j;
                    }
                    else
                    {
                        if (s[left] == s[j])
                        {
                            continue;
                        }
                        else
                        {
                            blocks.Add(j - left);
                            left = j;
                        }
                    }
                }
                if (left != -1)
                {
                    blocks.Add(n - left);
                }

                int res = 0;
                int firstI = 0;
                for(int j = 0; j < blocks.Count; j++)
                {
                    while (firstI < blocks.Count && blocks[firstI] == 1)
                    {
                        firstI++;
                    }

                    if (firstI < blocks.Count)
                    {
                        blocks[firstI]--;
                    }
                    else
                    {
                        j++;
                    }
                    res++;
                    if (firstI <= j)
                    {
                        firstI = j + 1;
                    }
                }
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
