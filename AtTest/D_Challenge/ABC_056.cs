using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_056
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            long[] array = ReadLongs();
            Array.Sort(array);
            int bottom = -1;
            int top = nk[0];

            while (bottom + 1 < top)
            {
                int x = (bottom + top) / 2;
                bool need = false;

                if (array[x] >= nk[1]) need = true;
                else
                {
                    var dp = new bool[nk[1]];
                    dp[0] = true;
                    for (int i = 0; i < nk[0]; i++)
                    {
                        if (x == i) continue;

                        var nextDp = new bool[nk[1]];
                        for (int j = 0; j < nk[1]; j++)
                        {
                            if (!dp[j]) continue;

                            nextDp[j] = true;

                            if (j + array[i] >= nk[1]) continue;

                            if (j + array[i] >= nk[1] - array[x])
                            {
                                need = true;
                            }
                            nextDp[j + array[i]] = true;
                        }
                        dp = nextDp;
                    }
                }
                if (need)
                {
                    top = x;
                }
                else
                {
                    bottom = x;
                }
            }
            Console.WriteLine(bottom + 1);
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
