using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_170
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
            int n = ReadInt();
            int[] array = ReadInts();
            List<int>[] dividers = new List<int>[n];
            int[] all = new int[1500000];
            for (int i = 0; i < n; i++)
            {
                dividers[i] = new List<int>();
                for (int j = 1; j * j <= array[i]; j++)
                {
                    if (array[i] % j == 0)
                    {
                        dividers[i].Add(j);
                        if (array[i] / j != j)
                        {
                            dividers[i].Add(array[i] / j);
                        }
                    }
                }
                all[array[i]]++;
            }

            int res = 0;
            for(int i = 0; i < n; i++)
            {
                bool ok = true;
                for(int j = 0; j < dividers[i].Count; j++)
                {
                    if (dividers[i][j] == array[i])
                    {
                        if (all[dividers[i][j]] > 1)
                        {
                            ok = false;
                            break;
                        }
                    }
                    else
                    {
                        if (all[dividers[i][j]] > 0)
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                if (ok)
                {
                    res++;
                }
            }

            WriteLine(res);
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
