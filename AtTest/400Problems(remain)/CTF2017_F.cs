using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class CTF2017_F
    {
        static void ain(string[] args)
        {
            Method(args);
            //Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int qCnt = n / 5;
            if (n % 5 > 0) qCnt++;
            bool[] isOriginal = new bool[n];
            for(int i = 0; i < qCnt; i++)
            {
                string qString = "? ";
                for (int j = 0; j < n; j++)
                {
                    if (j < i * 5 || j >= i * 5 + 5)
                        qString += "0 ";
                    else if (j < i * 5 + 5)
                        qString += Math.Pow(10, j - i * 5).ToString() + " ";
                }
                Console.WriteLine(qString);
                int val = ReadInt();
                for(int j = 0; j < 5; j++)
                {
                    isOriginal[i * 5 + j] = val % 10 == 9 || val % 10 == 1;
                    if (val % 10 <= 2) val -= 10;
                    val /= 10;
                    if (val == 0) break;
                }
            }
            Console.Write("! ");
            for(int i = 0; i < n; i++)
            {
                Console.Write(isOriginal[i] ? "1 " : "0 ");
            }
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
