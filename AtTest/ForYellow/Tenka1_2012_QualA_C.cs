using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class Tenka1_2012_QualA_C
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];

            List<int>[] graph = new List<int>[n];
            for(int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            for(int i = 0; i < m; i++)
            {
                int[] ab = ReadInts();
                int a = ab[0] - 1;
                int b = ab[1] - 1;
                graph[b].Add(a);
            }
            string s = Read();
            int first = 0;
            List<bool> attackOrNot = new List<bool>();
            bool after = false;
            for(int i = 0; i < s.Length; i++)
            {
                if (after)
                {
                    if (i + 1 < s.Length && s[i + 1] == 'w')
                    {
                        attackOrNot.Add(true);
                        i += 2;
                    }
                    else
                    {
                        attackOrNot.Add(false);
                    }
                }
                else
                {
                    if ('0' <= s[i] && s[i] <= '9')
                    {
                        first = first * 10 + s[i] - '0';
                    }
                    else if (first > 0)
                    {
                        after = true;
                        if (s[i] == 'w')
                        {
                            attackOrNot.Add(true);
                        }
                        else
                        {
                            attackOrNot.Add(false);
                            i--;
                        }
                    }
                }
            }
            first--;
            if (attackOrNot.Count == 0)
            {
                attackOrNot.Add(false);
            }

            bool[] use = new bool[n];
            use[first] = true;
            for(int i = 0; i < attackOrNot.Count; i++)
            {
                int[] refCnts = new int[n];
                int okCnt = 0;
                for(int j = 0; j < n; j++)
                {
                    if (!use[j])
                    {
                        continue;
                    }
                    okCnt++;

                    for(int k = 0; k < graph[j].Count; k++)
                    {
                        refCnts[graph[j][k]]++;
                    }
                }

                for(int j = 0; j < n; j++)
                {
                    if (attackOrNot[i])
                    {
                        use[j] = refCnts[j] > 0;
                    }
                    else
                    {
                        use[j] = refCnts[j] < okCnt;
                    }
                }
            }

            WriteLine(use.Count(a => a == true));
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
