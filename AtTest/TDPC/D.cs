using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nd = ReadLongs();
            long n = nd[0];
            long d = nd[1];
            
            int[] primes = new int[3] { 2, 3, 5 };
            int[] primeCnts = new int[3];
            long dd = d;
            for(int i = 0; i < primes.Length; i++)
            {
                while (dd % primes[i] == 0)
                {
                    dd /= primes[i];
                    primeCnts[i]++;
                }
            }
            if (dd > 1)
            {
                Console.WriteLine(0);
                return;
            }
            var dp = new double[64, 64, 64];
            int[][] deltas = new int[3][];
            deltas[0] = new int[6] { 0, 1, 0, 2, 0, 1 };
            deltas[1] = new int[6] { 0, 0, 1, 0, 0, 1 };
            deltas[2] = new int[6] { 0, 0, 0, 0, 1, 0 };
            for(int i = 0; i < 6; i++)
            {
                dp[deltas[0][i], deltas[1][i], deltas[2][i]] = 1.0 / 6;
            }
            for (int i = 1; i < n; i++)
            {
                var next = new double[64, 64, 64];
                for (int j = 0; j < 64; j++)
                {
                    for (int k = 0; k < 64; k++)
                    {
                        for (int l = 0; l < 64; l++)
                        {
                            double val = dp[j, k, l] / 6;
                            for(int m = 0; m < 6; m++)
                            {
                                int x = j + deltas[0][m];
                                if (x > primeCnts[0]) x = primeCnts[0];
                                int y = k + deltas[1][m];
                                if (y > primeCnts[1]) y = primeCnts[1];
                                int z = l + deltas[2][m];
                                if (z > primeCnts[2]) z = primeCnts[2];
                                next[x, y, z] += val;
                            }
                        }
                    }
                }
                dp = next;
            }
            Console.WriteLine(dp[primeCnts[0], primeCnts[1], primeCnts[2]]);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
