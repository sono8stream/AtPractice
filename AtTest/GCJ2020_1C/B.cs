using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.GCJ2020_1C
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
            int u = ReadInt();
            int len = 10000;
            string[] qs = new string[len];
            long[] qVals = new long[len];
            string[] rs = new string[len];
            for (int i = 0; i < len; i++)
            {
                string[] str = Read().Split();
                qs[i] = str[0];
                qVals[i] = long.Parse(qs[i]);
                rs[i] = str[1];
            }

            HashSet<char>[] states = new HashSet<char>[10];
            for(int i = 0; i < 10; i++)
            {
                states[i] = new HashSet<char>();
            }
            //Check existing
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < rs[i].Length; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        states[k].Add(rs[i][j]);
                    }
                }
            }

            //0 bind and max check 
            for (int i = 0; i < len; i++)
            {
                if (states[0].Contains(rs[i][0]))
                {
                    states[0].Remove(rs[i][0]);
                }

                if (qs[i] == "-1" || qs[i].Length > rs[i].Length)
                {
                    continue;
                }

                for (int j = qs[i][0] - '0' + 1; j < 10; j++)
                {
                    if (states[j].Contains(rs[i][0]))
                    {
                        states[j].Remove(rs[i][0]);
                    }
                }
            }

            var dict = new Dictionary<char, byte>();
            foreach(char c0 in states[0])
            {
                dict.Add(c0, 0);
                foreach (char c1 in states[1])
                {
                    if (dict.ContainsKey(c1))
                    {
                        continue;
                    }
                    dict.Add(c1, 1);
                    foreach (char c2 in states[2])
                    {
                        if (dict.ContainsKey(c2))
                        {
                            continue;
                        }
                        dict.Add(c2, 2);
                        foreach (char c3 in states[3])
                        {
                            if (dict.ContainsKey(c3))
                            {
                                continue;
                            }
                            dict.Add(c3, 3);
                            foreach (char c4 in states[4])
                            {
                                if (dict.ContainsKey(c4))
                                {
                                    continue;
                                }
                                dict.Add(c4, 4);
                                foreach (char c5 in states[5])
                                {
                                    if (dict.ContainsKey(c5))
                                    {
                                        continue;
                                    }
                                    dict.Add(c5, 5);
                                    foreach (char c6 in states[6])
                                    {
                                        if (dict.ContainsKey(c6))
                                        {
                                            continue;
                                        }
                                        dict.Add(c6, 6);
                                        foreach (char c7 in states[7])
                                        {
                                            if (dict.ContainsKey(c7))
                                            {
                                                continue;
                                            }
                                            dict.Add(c7, 7);
                                            foreach (char c8 in states[8])
                                            {
                                                if (dict.ContainsKey(c8))
                                                {
                                                    continue;
                                                }
                                                dict.Add(c8, 8);
                                                foreach (char c9 in states[9])
                                                {
                                                    if (dict.ContainsKey(c9))
                                                    {
                                                        continue;
                                                    }
                                                    dict.Add(c9, 9);
                                                    bool ok = true;
                                                    for (int i = 0; i < len; i++)
                                                    {
                                                        if (qs[i] == "-1")
                                                        {
                                                            continue;
                                                        }

                                                        long val = 0;
                                                        for(int j = 0; j < rs[i].Length; j++)
                                                        {
                                                            val = val * 10 + dict[rs[i][j]];
                                                        }
                                                        if (val > qVals[i])
                                                        {
                                                            ok = false;
                                                            break;
                                                        }
                                                    }
                                                    if (ok)
                                                    {
                                                        string res = "";
                                                        res += c0;
                                                        res += c1;
                                                        res += c2;
                                                        res += c3;
                                                        res += c4;
                                                        res += c5;
                                                        res += c6;
                                                        res += c7;
                                                        res += c8;
                                                        res += c9;
                                                        return () => { WriteLine(res); };
                                                    }
                                                    dict.Remove(c9);
                                                }
                                                dict.Remove(c8);
                                            }
                                            dict.Remove(c7);
                                        }
                                        dict.Remove(c6);
                                    }
                                    dict.Remove(c5);
                                }
                                dict.Remove(c4);
                            }
                            dict.Remove(c3);
                        }
                        dict.Remove(c2);
                    }
                    dict.Remove(c1);
                }
                dict.Remove(c0);
            }

            return () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Write(states[i].First());
                }
                WriteLine();
            };
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
