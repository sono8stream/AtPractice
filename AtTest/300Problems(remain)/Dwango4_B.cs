using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._300Problems_remain_
{
    class Dwango4_B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            char[] cs = s.ToCharArray();
            bool now2 = false;
            int index2 = 0;
            int remain = s.Length;
            int res = 0;
            while (remain > 0)
            {
                int cnt = 0;
                remain = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (cs[i] == '2')
                    {
                        if (!now2)
                        {
                            index2 = i;
                            now2 = true;
                        }
                        remain++;
                    }
                    if (cs[i] == '5')
                    {
                        if (now2)
                        {
                            cs[index2] = '0';
                            cs[i] = '0';
                            now2 = false;
                            cnt++;
                            remain -= 2;
                        }
                        remain++;
                    }
                }
                if (cnt == 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                res++;
            }
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
