using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Disco2019Final
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
            int n = ReadInt();
            string s = Read();
            var iceList = new List<int>();
            int iceCnt = 0;
            for(int i = 0; i < n; i++)
            {
                if (s[i] == '>') iceCnt++;
                else if (iceCnt > 0)
                {
                    iceList.Add(iceCnt);
                    iceCnt = 0;
                }
            }
            if (iceList.Count == 0) iceList.Add(0);
            iceList.Sort();
            iceList.Reverse();
            iceList[0]++;
            int remain = n;
            double res = 0;
            for(int i = 0; i < iceList.Count; i++)
            {
                for(int j = 0; j < iceList[i]; j++)
                {
                    res += 1.0 / (j + 2);
                }
                remain -= iceList[i];
            }
            res += remain;
            Console.WriteLine(res);
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
