using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.NothingToLearn
{
    class ABC054_B
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];
            string[] aStrs = new string[n];
            string[] bStrs = new string[m];
            for (int i = 0; i < n; i++)
            {
                aStrs[i] = Read();
            }
            for (int i = 0; i < m; i++)
            {
                bStrs[i] = Read();
            }

            for (int i = 0; i < n - m + 1; i++)
            {
                for (int j = 0; j < n - m + 1; j++)
                {
                    bool ok = true;
                    for(int k = 0; k < m; k++)
                    {
                        for(int l = 0; l < m; l++)
                        {
                            if (aStrs[i + k][j + l] != bStrs[k][l])
                            {
                                ok = false;
                            }
                        }
                    }
                    if (ok)
                    {
                        WriteLine("Yes");
                        return;
                    }
                }
            }
            WriteLine("No");
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
