using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.JSC2019_Fnal
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
            int n = ReadInt();
            bool[][] ys = new bool[n][];
            for (int i = 0; i < n; i++) ys[i] = new bool[n];
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                for(int j = 0; j < n; j++)
                {
                    ys[j][i] = s[j] == '1';
                }
            }
            bool[][] zs = new bool[n][];
            for (int i = 0; i < n; i++) zs[i] = new bool[n];
            for(int i = 0; i < n; i++)
            {
                string s = Read();
                for(int j = 0; j < n; j++)
                {
                    zs[j][i] = s[j] == '1';
                }
            }
            bool[][] now = new bool[n][];
            bool[,] res = new bool[n,n];
            for (int i = 0; i < n; i++) now[i] = new bool[n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    bool ok = true;
                    for(int k = 0; k < n; k++)
                    {
                        if (ys[i][k] && (!zs[j][k]))
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        res[i, j] = true;
                        for(int k = 0; k < n; k++)
                        {
                            now[j][k] |= ys[i][k];
                        }
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (now[i][j] != zs[i][j])
                    {
                        WriteLine(-1);
                        return;
                    }
                }
            }

            for(int i = 0; i < n; i++)
            {
                for(int j=0; j < n; j++)
                {
                    Write(res[i, j] ? '1' : '0');
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
