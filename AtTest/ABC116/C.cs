using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC116
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] hs = ReadInts();
            int cnt = 0;
            int remain = n;
            while (remain > 0)
            {
                remain = 0;
                bool removing = false;
                for (int i = 0; i < n; i++)
                {
                    if (hs[i] > 0)
                    {
                        if (!removing)
                        {
                            removing = true;
                            cnt++;
                        }
                        hs[i]--;
                        remain++;
                    }
                    else
                    {
                        removing = false;
                    }
                }
            }
            Console.WriteLine(cnt);
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
