using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_30
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
            while (true)
            {
                int n = ReadInt();
                if (n == 0) break;
                string[] strs = new string[n];
                for(int i = 0; i < n; i++)
                {
                    strs[i] = Read();
                }
                var graph = new Dictionary<char, HashSet<char>>();
                var rev = new Dictionary<char, HashSet<char>>();
                bool can = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (strs[i].Equals(strs[i + 1])) continue;

                    int same = 0;
                    for (int j = 0; j < Min(strs[i].Length, strs[i + 1].Length); j++)
                    {
                        if (strs[i][j] == strs[i + 1][j]) same++;
                        else break;
                    }
                    if (strs[i].Length > strs[i + 1].Length
                        && same >= strs[i + 1].Length)
                    {
                        WriteLine("no");
                        can = false;
                        break;
                    }
                    if (same < Min(strs[i].Length, strs[i + 1].Length))
                    {
                        if (!graph.ContainsKey(strs[i][same]))
                        {
                            graph.Add(strs[i][same], new HashSet<char>());
                            rev.Add(strs[i][same], new HashSet<char>());
                        }
                        if (!graph.ContainsKey(strs[i + 1][same]))
                        {
                            graph.Add(strs[i + 1][same], new HashSet<char>());
                            rev.Add(strs[i + 1][same], new HashSet<char>());
                        }
                        graph[strs[i][same]].Add(strs[i + 1][same]);
                        rev[strs[i + 1][same]].Add(strs[i][same]);
                    }
                }
                if (!can) continue;

                Queue<char> queue = new Queue<char>();
                foreach(char key in rev.Keys)
                {
                    if (rev[key].Count == 0) queue.Enqueue(key);
                }
                var used = new HashSet<char>();
                while (queue.Count > 0)
                {
                    char c = queue.Dequeue();
                    if (used.Contains(c)) continue;
                    used.Add(c);
                    foreach(char to in graph[c])
                    {
                        if (!rev[to].Contains(c)) continue;
                        if (used.Contains(to)) continue;

                        rev[to].Remove(c);
                        queue.Enqueue(to);
                    }
                }

                foreach(char key in rev.Keys)
                {
                    if (rev[key].Count > 0)
                    {
                        WriteLine("no");
                        can = false;
                        break;
                    }
                }
                if (!can) continue;
                WriteLine("yes");
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
