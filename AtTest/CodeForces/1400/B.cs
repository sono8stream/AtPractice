using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1400
{
    class B
    {
        static void ain(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            for(int i = 0; i < t; i++)
            {
                long[] pf = ReadLongs();
                long p = pf[0];
                long f = pf[1];
                long[] cnts = ReadLongs();
                long cntS = cnts[0];
                long cntW = cnts[1];
                long[] sw = ReadLongs();
                long s = sw[0];
                long w = sw[1];

                long res = 0;
                for(long j = 0; j <= cntS; j++)
                {
                    long pRemain = p-j * s;
                    if (pRemain < 0)
                    {
                        continue;
                    }

                    long tmp = j;

                    long pAxe = Min(pRemain / w, cntW);
                    tmp += pAxe;

                    long swordRemain = cntS - j;
                    long axeRemain = cntW - pAxe;
                    if (s < w)
                    {
                        long fSword = Min(f / s, swordRemain);
                        long fRemain = f - fSword * s;
                        long fAxe = Min(fRemain / w, axeRemain);
                        tmp += fSword + fAxe;
                    }
                    else
                    {
                        long fAxe = Min(f / w, axeRemain);
                        long fRemain = f - fAxe * w;
                        long fSword = Min(fRemain / s, swordRemain);
                        tmp += fSword + fAxe;
                    }

                    res = Max(res, tmp);
                }
                WriteLine(res);
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
