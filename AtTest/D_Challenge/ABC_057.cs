using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_057
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nab = ReadInts();
            long[] vs = ReadLongs();
            Array.Sort(vs);
            Array.Reverse(vs);
            var sameCnt = new List<long[]>();
            for(int i = 0; i < nab[0]; i++)
            {
                if (sameCnt.Count == 0 
                    || sameCnt[sameCnt.Count - 1][0] != vs[i])
                {
                    sameCnt.Add(new long[2] { vs[i], 1 });
                }
                else
                {
                    sameCnt[sameCnt.Count - 1][1]++;
                }
            }
            var aves = new double[nab[0]];
            var cnts = new long[nab[0]];
            for (int i = nab[1] - 1; i < nab[2]; i++)
            {
                int remain = i + 1;
                long sum = 0;
                int itr = 0;
                long comb = 1;
                while (itr < sameCnt.Count && remain >= (int)sameCnt[itr][1])
                {
                    sum += sameCnt[itr][0] * sameCnt[itr][1];
                    remain -= (int)sameCnt[itr][1];
                    itr++;
                }
                if (itr < sameCnt.Count)
                {
                    sum += sameCnt[itr][0] * remain;
                    comb = Combination(sameCnt[itr][1], remain);
                }
                aves[i] = sum * 1.0 / (i+1);
                cnts[i] = comb;
                Console.Error.WriteLine(cnts[i]);
            }
            long cnt = 0;
            double maxAve = double.MinValue;
            for(int i = nab[1] - 1; i < nab[2]; i++)
            {
                if (maxAve < aves[i])
                {
                    maxAve = aves[i];
                    cnt = cnts[i];
                }
                else if (maxAve == aves[i])
                {
                    cnt += cnts[i];
                }
            }
            Console.WriteLine(maxAve);
            Console.WriteLine(cnt);
        }

        static long Combination(long m,long n)
        {
            if (m - n < n) n = m - n;
            long res = 1;
            var dividers = new List<long>();
            for(long i = 2; i <= n; i++)
            {
                dividers.Add(i);
            }
            for (long i = m - n + 1; i <= m; i++)
            {
                res *= i;
                for(int j = 0; j < dividers.Count; j++)
                {
                    if (res % dividers[j] == 0)
                    {
                        res /= dividers[j];
                        dividers.RemoveAt(j);
                        j--;
                    }
                }
            }
            return res;
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
