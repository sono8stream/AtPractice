using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_122
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nq=ReadInts();
            int n = nq[0];
            int q = nq[1];
            string s = Read();
            int[][] lrs = new int[q][];
            for(int i = 0; i < q; i++)
            {
                lrs[i] = ReadInts();
                lrs[i][0]--;
                lrs[i][1]--;
            }
            int[] cnts = new int[n];
            for(int i = 1; i < n; i++)
            {
                cnts[i] = cnts[i - 1];
                if (s[i - 1] == 'A' && s[i] == 'C')
                {
                    if (i > 1)
                    {
                        cnts[i] = cnts[i - 2] + 1;
                    }
                    else
                    {
                        cnts[i] = 1;
                    }
                }
                //Write(cnts[i] + " ");
            }
            //WriteLine();
            for(int i = 0; i < q; i++)
            {
                int val = cnts[lrs[i][1]];
                    val -= cnts[lrs[i][0]];
                WriteLine(val);
            }
        }

        private static string Read() { return ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
