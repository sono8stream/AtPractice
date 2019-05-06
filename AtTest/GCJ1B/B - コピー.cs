using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ1B
{
    class Bcopy
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] tw = ReadInts();
            int t = tw[0];
            int w = tw[1];
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
        }

        static Action Solve()
        {
            long[] rs = new long[6];
            long[] vals = new long[6];
            for(int i = 0; i < 6; i++)
            {
                WriteLine(i + 1);
                vals[i] = ReadLong();
            }

            for(int i = 0; i <= 100; i++)
            {
                rs[0] = i;
                rs[1] = vals[1] - vals[0] - 2 * rs[0];
                rs[2] = vals[2] - vals[1] - 4 * rs[0];
                rs[3] = vals[3] - vals[2] - 8 * rs[0] - 2 * rs[1];
                rs[4] = vals[4] - vals[3] - 16 * rs[0];
                rs[5] = vals[5] - vals[4] - 32 * rs[0] - 4 * rs[1] - 2 * rs[2];

                if (rs[0] == 0 && rs[1] == 0 && rs[2] == 0
                    && rs[3] == 0 && rs[4] == 0 && rs[5] == 0) continue;

                bool ok = true;
                for(int j = 0; j < 6; j++)
                {
                    long val = 0;
                    for(int k = 0; k < 6; k++)
                    {
                        val += rs[k] * (1 << ((j + 1) / (k + 1)));
                    }
                    if (val != vals[j])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok) break;
            }

            for(int i = 0; i < 6; i++)
            {
                Write(rs[i]);
                if (i < 5) Write(' ');
            }
            WriteLine();

            ReadInt();

            return () => WriteLine("POSSIBLE");
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
