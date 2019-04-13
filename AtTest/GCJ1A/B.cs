using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ1A
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] tnm = ReadInts();
            int t = tnm[0];
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
        }

        static Action Solve()
        {
            int[] primes = new int[7] { 5, 7, 9, 11, 13, 16, 17 };
            int[] reminds = new int[7];
            for(int i =0; i < 7; i++)
            {
                for (int k = 0; k < 18; k++) Write(primes[i] + " ");
                WriteLine();
                int[] inputs = ReadInts();
                for (int k = 0; k < 18; k++) reminds[i] += inputs[k];
                reminds[i] %= primes[i];
            }
            int val = reminds[6];
            while (val < 1000000)
            {
                bool ok = true;
                for(int i = 0; i < 7; i++)
                {
                    if (val % primes[i] != reminds[i]) ok = false;
                }
                if (ok) break;
                else val += primes[6];
            }
            WriteLine(val);
            ReadLine();
            return () => { };
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
