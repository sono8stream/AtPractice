using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1166
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] mn = ReadInts();
            int m = mn[0];
            int n = mn[1];

            var set = new HashSet<int>[m];
            for(int i = 0; i < m; i++)
            {
                set[i] = new HashSet<int>();
                int[] ss = ReadInts();
                for(int j = 1; j <= ss[0]; j++)
                {
                    set[i].Add(ss[j]);
                }

                int cnt = 0;
                for(int j = 0; j < i; j++)
                {
                    foreach(int val in set[i])
                    {
                        if (set[j].Contains(val))
                        {
                            cnt++;
                            break;
                        }
                    }
                }

                if (cnt < i)
                {
                    WriteLine("impossible");
                    return;
                }
            }
            WriteLine("possible" );
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
