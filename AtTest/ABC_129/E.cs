using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_129
{
    class E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            long mask = 1000000000 + 7;
            long res = 0;
            long onCnt = 0;
            long remainPats = 1;
            long allPats = 1;
            for(int i = 0; i < s.Length; i++)
            {
                allPats *= 3;
                allPats %= mask;
            }
            
            for(int i = 0; i <s.Length; i++)
            {
                allPats = MultiMod(allPats, ReverseMod(3, mask - 2, mask), mask);
                if (s[i] != '1') continue;

                res+= MultiMod(allPats, remainPats, mask);
                res %= mask;
                onCnt++;
                remainPats *= 2;
                remainPats %= mask;
            }
            res += remainPats;
            res %= mask;

            WriteLine(res);
        }

        static long MultiMod(long a, long b, long mask)
        {
            return ((a % mask) * (b % mask)) % mask;
        }

        static long ReverseMod(long a, long pow, long mask)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = ReverseMod(a, pow / 2, mask);
                long nextMod = MultiMod(halfMod, halfMod, mask);
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return MultiMod(nextMod, a, mask);
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
