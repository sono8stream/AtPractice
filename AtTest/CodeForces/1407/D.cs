using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1407
{
    class D
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
            int[] hs = ReadInts();
            List<int>[] upperIndecies = GetUppers(hs);
            List<int>[] lowerIndecies = GetLowers(hs);

            int[] dp = new int[n];
            for(int i = 0; i < n; i++)
            {
                dp[i] = int.MaxValue / 2;
            }
            dp[0] = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int next = dp[i] + 1;
                for (int j = 0; j < upperIndecies[i].Count; j++)
                {
                    dp[upperIndecies[i][j]] = Min(dp[upperIndecies[i][j]], next);
                }
                for (int j = 0; j < lowerIndecies[i].Count; j++)
                {
                    dp[lowerIndecies[i][j]] = Min(dp[lowerIndecies[i][j]], next);
                }
                dp[i + 1] = Min(dp[i + 1], next);
            }

            WriteLine(dp[n - 1]);
        }

        static List<int>[] GetUppers(int[] hs)
        {
            List<int>[] indecies = new List<int>[hs.Length];
            indecies[hs.Length - 1] = new List<int>();
            Stack<int[]> stk = new Stack<int[]>();
            stk.Push(new int[2] { hs[hs.Length - 1], hs.Length - 1 });
            for (int i = hs.Length - 2; i >= 0; i--)
            {
                int next = hs[i + 1];
                indecies[i] = new List<int>();
                if (hs[i] >= next)
                {
                    stk.Push(new int[2] { hs[i], i });
                    continue;
                }

                while (stk.Count > 0 && stk.Peek()[0] > hs[i])
                {
                    if (stk.Peek()[0] < next)
                    {
                        indecies[i].Add(stk.Peek()[1]);
                        next = stk.Peek()[0];
                    }
                    stk.Pop();
                }
                if (stk.Count > 0)
                {
                    indecies[i].Add(stk.Peek()[1]);
                }

                stk.Push(new int[2] { hs[i], i });
            }
            return indecies;
        }

        static List<int>[] GetLowers(int[] hs)
        {
            List<int>[] indecies = new List<int>[hs.Length];
            indecies[hs.Length - 1] = new List<int>();
            Stack<int[]> stk = new Stack<int[]>();
            stk.Push(new int[2] { hs[hs.Length - 1], hs.Length - 1 });
            for (int i = hs.Length - 2; i >= 0; i--)
            {
                int next = hs[i + 1];
                indecies[i] = new List<int>();
                if (hs[i] <= next)
                {
                    stk.Push(new int[2] { hs[i], i });
                    continue;
                }

                while (stk.Count > 0 && stk.Peek()[0] < hs[i])
                {
                    if (stk.Peek()[0] > next)
                    {
                        indecies[i].Add(stk.Peek()[1]);
                        next = stk.Peek()[0];
                    }
                    stk.Pop();
                }
                if (stk.Count > 0)
                {
                    indecies[i].Add(stk.Peek()[1]);
                }

                stk.Push(new int[2] { hs[i], i });
            }
            return indecies;
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
