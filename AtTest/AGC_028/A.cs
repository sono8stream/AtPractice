using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.AGC_028
{
    class A
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long[] nm = ReadLongs();
            string s = Read();
            string t = Read();
            for (long i = 0; i < nm[0]; i++)
            {
                if ((nm[1] * i) % nm[0] == 0)
                {
                    long j = nm[1] * i / nm[0];
                    if (s[(int)i] == t[(int)j])
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                }
            }
            Console.WriteLine(LCM(nm[0], nm[1]));
        }

        static long GCD(long a, long b)
        {
            long c = b;
            do
            {
                c = a % b;
                a = b;
                b = c;
            } while (c > 0);
            return a;
        }

        static long LCM(long a, long b)
        {
            long c = GCD(a, b);
            return a * b / c;
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
