﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.Combination_Permutation
{
    class CaseCalculator
    {
        long mask;
        long[] allPermutations;

        public CaseCalculator(long mask, long permutationCnt)
        {
            this.mask = mask;
            allPermutations = AllPermutations(permutationCnt);
        }

        public long Combination(long n, long m)
        {
            if (n < m) return 0;

            if (n - m < m) m = n - m;

            return Multi(allPermutations[n],
                Reverse(
                    Multi(allPermutations[n - m], allPermutations[m]),
                    mask - 2));
        }

        public long Permutation(long n, long m)
        {
            if (n < m) return 0;

            return Multi(allPermutations[n],
                Reverse(allPermutations[n - m], mask - 2));
        }

        long[] AllPermutations(long n)
        {
            var perms = new long[n + 1];
            perms[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                perms[i] = Multi(perms[i - 1], i);
            }
            return perms;
        }

        public long Multi(long a, long b)
        {
            return ((a % mask) * (b % mask)) % mask;
        }

        long Reverse(long a, long pow)
        {
            if (pow == 0) return 1;
            else if (pow == 1) return a % mask;
            else
            {
                long halfMod = Reverse(a, pow / 2);
                long nextMod = Multi(halfMod, halfMod);
                if (pow % 2 == 0)
                {
                    return nextMod;
                }
                else
                {
                    return Multi(nextMod, a);
                }
            }
        }
    }
}