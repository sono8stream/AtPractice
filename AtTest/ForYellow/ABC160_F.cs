using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class ABC160_F
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
            int n = ReadInt();
            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            for(int i = 0; i < n - 1; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            int[] childs = new int[n];
            DFS1(0, -1, graph, childs);

            long mask = 1000000000 + 7;
            CaseCalculator calculator = new CaseCalculator(mask, n);

            long[] pats = new long[n];
            DFS2(0, -1, graph, calculator, pats, childs, mask);

            long[] res = new long[n];
            DFS3(0, -1, graph, res, childs, pats, calculator, mask);
            for(int i = 0; i < n; i++)
            {
                WriteLine(res[i]);
            }
        }

        static void DFS1(int now, int parent, List<int>[] graph, int[] childs)
        {
            int child = 0;
            for(int i = 0; i < graph[now].Count; i++)
            {
                int to = graph[now][i];
                if (to == parent)
                {
                    continue;
                }

                DFS1(to, now, graph, childs);
                child += childs[to] + 1;
            }

            childs[now] = child;
        }

        static void DFS2(int now,int parent, List<int>[] graph, CaseCalculator calculator,
            long[] pats,int[] childs,long mask)
        {
            long val = 1;
            int childCnt = childs[now];
            for (int i = 0; i < graph[now].Count; i++)
            {
                int to = graph[now][i];
                if (to == parent)
                {
                    continue;
                }

                long tmp = calculator.Combination(childCnt, childs[to] + 1);
                DFS2(to, now, graph, calculator, pats, childs, mask);
                tmp = (tmp * pats[to]) % mask;
                childCnt -= childs[to] + 1;
                val *= tmp;
                val %= mask;
            }

            pats[now] = val;
        }

        static void DFS3(int now, int parent,
            List<int>[] graph, long[] res,            int[] childs, 
            long[] pats, CaseCalculator calculator, long mask)
        {
            long pat = 1;
            if (parent == -1)
            {
                pat = pats[now];
            }
            else
            {
                long parentVal = (res[parent] * calculator.Inverse(
                    calculator.Permutation(childs.Length - 1, childs[now] + 1))) % mask;
                parentVal = (parentVal * calculator.Permutation(
                    childs[now] + 1, childs[now] + 1)) % mask;
                parentVal = (parentVal * calculator.Inverse(pats[now])) % mask;
                parentVal = (parentVal * calculator.Combination(
                    childs.Length - 1, childs[now])) % mask;
                pat = (parentVal * pats[now]) % mask;
            }
            res[now] = pat;

            for(int i = 0; i < graph[now].Count; i++)
            {
                int to = graph[now][i];
                if (to == parent)
                {
                    continue;
                }

                DFS3(to, now, graph, res, childs, pats, calculator, mask);
            }
             }

        class CaseCalculator
        {
            long mask;
            long[] allPermutations;
            long[] allInverses;

            public CaseCalculator(long mask, long permutationCnt)
            {
                this.mask = mask;
                allPermutations = AllPermutations(permutationCnt);
                allInverses = AllInverses(permutationCnt);
            }

            public long Combination(long n, long m)
            {
                if (n < m) return 0;

                if (n - m < m) m = n - m;

                return Multi(allPermutations[n], allInverses[n - m], allInverses[m]);
            }

            public long Permutation(long n, long m)
            {
                if (n < m) return 0;

                return Multi(allPermutations[n], allInverses[n - m]);
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

            long[] AllInverses(long n)
            {
                var inverses = new long[n + 1];
                inverses[1] = 1;
                var permInverses = new long[n + 1];
                permInverses[0] = 1;
                permInverses[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    inverses[i] = mask - inverses[mask % i] * (mask / i) % mask;
                    permInverses[i] = Multi(permInverses[i - 1], inverses[i]);
                }
                return permInverses;
            }

            public long Multi(params long[] vals)
            {
                if (vals.Length == 0)
                {
                    return 0;
                }

                long val = vals[0] % mask;
                for (int i = 1; i < vals.Length; i++)
                {
                    val *= (vals[i] % mask);
                    val %= mask;
                }
                return val;
            }

            public long Inverse(long val)
            {
                long a = mask;
                long b = val % mask;
                long x = 1;
                long x1 = 0;
                long y = 0;
                long y1 = 1;
                while (b > 0)
                {
                    long q = a / b;
                    long r = a % b;
                    long x2 = (mask + x - (q * x1) % mask) % mask;
                    long y2 = (mask + y - (q * y1) % mask) % mask;
                    a = b;
                    b = r;
                    x = x1;
                    x1 = x2;
                    y = y1;
                    y1 = y2;
                }
                return y;
            }

            long DeprecatedInverse(long val)
            {
                return Pow(val, mask - 2);
            }

            long Pow(long a, long exp)
            {
                if (exp == 0) return 1;
                else if (exp == 1) return a % mask;
                else
                {
                    long halfMod = Pow(a, exp / 2);
                    long nextMod = Multi(halfMod, halfMod);
                    if (exp % 2 == 0)
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
