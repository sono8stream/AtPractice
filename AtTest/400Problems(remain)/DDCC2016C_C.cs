using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class DDCC2016C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] array = ReadInts();
            var divDict = new Dictionary<long, long>();
            int kRoot = (int)Math.Sqrt(k);
            for(int i = 1; i <= kRoot; i++)
            {
                if (k % i == 0)
                {
                    divDict.Add(i, 0);
                    if (i != k / i) divDict.Add(k / i, 0);
                }
            }
            for(int i = 0; i < n; i++)
            {
                long gcd = GCD(k, array[i]);
                divDict[gcd]++;
            }
            long cnt = 0;
            foreach(long key in divDict.Keys)
            {
                foreach(long key2 in divDict.Keys)
                {
                    if ((key * key2) % k == 0)
                    {
                        if (key == key2)
                            cnt += divDict[key] * (divDict[key] - 1);
                        else cnt += divDict[key] * divDict[key2];
                    }
                }
            }
            Console.WriteLine(cnt / 2);
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
