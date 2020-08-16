using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_047
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
            int n = ReadInt();
            string[] ss = new string[n];
            for(int i = 0; i < n; i++)
            {
                ss[i] = Read();
            }
            Array.Sort(ss,(a,b)=>a.Length-b.Length);

            Trie trie = new Trie();
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                res += trie.Count(ss[i]);
                trie.AddWord(ss[i]);
            }

            WriteLine(res);
        }

        public class Node
        {
            public Dictionary<char, int> edges;
            public int[] cnts;

            public Node()
            {
                edges = new Dictionary<char, int>();
                cnts = new int[26];
            }
        }

        public class Trie
        {
            public List<Node> nodes;

            public Trie()
            {
                nodes = new List<Node>();
                nodes.Add(new Node());
            }

            public void AddWord(string s)
            {
                int now = 0;
                for (int i = s.Length - 1; i > 0; i--)
                {
                    char c = s[i];
                    if (!nodes[now].edges.ContainsKey(c))
                    {
                        nodes[now].edges.Add(c, nodes.Count);
                        nodes.Add(new Node());
                    }
                    now = nodes[now].edges[c];
                }
                nodes[now].cnts[s[0] - 'a']++;
            }

            public int Count(string s)
            {
                int[] cnts = new int[26];
                for(int i = 0; i < s.Length; i++)
                {
                    cnts[s[i] - 'a']++;
                }

                int cnt = 0;
                int now = 0;
                for(int i = 0; i < 26; i++)
                {
                    if (cnts[i] > 0)
                    {
                        cnt += nodes[now].cnts[i];
                    }
                }
                for (int i =  s.Length - 1; i > 0; i--)
                {
                    cnts[s[i] - 'a']--;
                    char c = s[i];
                    if (!nodes[now].edges.ContainsKey(c))
                    {
                        break;
                    }
                    now = nodes[now].edges[c];
                    for(int j = 0; j < 26; j++)
                    {
                        if (cnts[j] > 0)
                        {
                            cnt += nodes[now].cnts[j];
                        }
                    }
                }

                return cnt;
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
