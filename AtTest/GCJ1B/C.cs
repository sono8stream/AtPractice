using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ1C
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int t = ReadInt();
            Action[] res = new Action[t];
            for (int i = 0; i < t; i++)
            {
                res[i] = Solve();
            }
            for (int i = 0; i < t; i++)
            {
                Write("Case #" + (i + 1) + ": ");
                res[i]();
            }
        }

        static Action Solve()
        {
            int n = ReadInt();
            string[] ss = new string[n];
            var dict = new Dictionary<string, int>();
            for(int i = 0; i < n; i++)
            {
                ss[i] = Read();
                string s = "";
                for(int j = ss[i].Length-1; j >=0; j--)
                {
                    s += ss[i][j];
                    if (!dict.ContainsKey(s)) dict.Add(s, 0);
                    dict[s]++;
                }
            }
            int res = 0;
            for (int i = 50; i >= 1; i--)
            {
                var next = new Dictionary<string, int>();
                foreach (string key in dict.Keys) next.Add(key, dict[key]);
                foreach (string key in dict.Keys)
                {
                    if (key.Length < i) continue;

                    if (dict[key] >= 2)
                    {
                        next[key] = 0;
                        foreach (string key2 in dict.Keys)
                        {
                            if (key2.Length > key.Length) continue;
                            bool ok = true;
                            for (int j = 0; j < key2.Length; j++)
                            {
                                if (key[j] != key2[j]) ok = false;
                            }
                            if (!ok) continue;
                            next[key2] -= 2;
                        }
                        res += 2;
                    }
                }
                var nextR = new Dictionary<string, int>();
                foreach (string key in next.Keys)
                {
                    if (next[key] >=2) nextR.Add(key, next[key]);
                }
                dict = nextR;
            }

            return () => WriteLine(res);
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
