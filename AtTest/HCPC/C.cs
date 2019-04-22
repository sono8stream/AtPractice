using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            for(int i = 1; i <= n; i++)
            {
                bool ok = true;
                for(int j = 0; j < n; j++)
                {
                    int now = array[j];
                    for(int k = j; k < n; k += i)
                    {
                        if (now == 0) now = array[k];
                        if (array[k] == 0
                            || array[k] == now) continue;

                        ok = false;
                        break;
                    }
                    if (!ok) break;
                }
                if (ok)
                {
                    WriteLine(i);
                    return;
                }
            }
        }

        private static string Read() { return ReadLine(); }
        private static char[] ReadChars() { return Array.ConvertAll(Read().Split(), a => a[0]); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
