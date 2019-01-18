using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class APC001_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var aArray = ReadInts();
            var bArray = ReadInts();
            long cnt = 0;
            for(int i = 0; i < n; i++)
            {
                if (aArray[i] > bArray[i]) cnt += aArray[i] - bArray[i];
            }
            if (cnt == 0)
            {
                Console.WriteLine("Yes");
                return;
            }
            for(int i = 0; i < n; i++)
            {
                if (aArray[i] >= bArray[i]) continue;

                int addCnt = (bArray[i] - aArray[i]) / 2;
                cnt -= addCnt;
                if (cnt <= 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
            }
            Console.WriteLine("No");
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
