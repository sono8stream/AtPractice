using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_003
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int r = int.Parse(input[0]);
            int c = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            input = Console.ReadLine().Split(' ');
            int d = int.Parse(input[0]);
            int l = int.Parse(input[1]);
            int roomPat = (r - x + 1) * (c - y + 1);
            long mask = 1000000007;
            int combinationCnt = d < l ? d : l;
            int objectCnt = d + l;
            long allPat = 1;
            for(int i = 0; i < combinationCnt; i++)
            {
                allPat = MultiMod(allPat, objectCnt - i, mask);
                allPat = MultiMod(allPat,
                    ReverseMod(combinationCnt - i, mask - 2, mask), mask);
            }
            Console.WriteLine((allPat * roomPat) % mask);
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
    }
}