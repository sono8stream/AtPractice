using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class COLOCON2018C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] ab = ReadLongs();
            long a = ab[0];
            long b = ab[1];
            long n = b - a + 1;
            bool[,] cans = new bool[n, n];
            for (long i = a; i <= b; i++)
            {
                for (long j = i + 1; j <= b; j++)
                {
                    bool can = GCD(i, j) == 1;
                    cans[i, j] = can;
                    cans[j, i] = can;
                }
            }
            Console.WriteLine(DFS(new List<long>(), cans, a, b));
        }

        static long DFS(List<long> selected,bool[,] cans, 
            long now,long max)
        {
            bool can = true;
            for (int i = 0; i < selected.Count; i++)
            {
                if (!cans[selected[i],now])
                {
                    can = false;
                    //break;
                }
                //Console.Write(selected[i] + " ");
            }
            //Console.WriteLine();
            if (now == max)
            {
                long cnt = 1;
                if (can) cnt++;
                return cnt;
            }
            long val = DFS(selected, cans, now + 1,max);
            if (can)
            {
                selected.Add(now);
                val += DFS(selected, cans, now + 1, max);
                selected.RemoveAt(selected.Count - 1);
            }
            return val;
        }

        static long GCD(long a, long b)
        {
            if (b > a)
            {
                long temp = b;
                b = a;
                a = temp;
            }
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
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
