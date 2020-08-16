using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1379
{
    class A
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
            string key = "abacaba";
            for (int i = 0; i < t; i++)
            {
                int n = ReadInt();
                string s = Read();
                bool can = false;
                for (int j = 0; j + key.Length - 1 < n; j++)
                {
                    bool replacable = true;
                    for(int k = 0; k < key.Length; k++)
                    {
                        if (s[j + k] == key[k]
                            || s[j + k] == '?')
                        {
                            continue;
                        }

                        replacable = false;
                        break;
                    }

                    if (!replacable)
                    {
                        continue;
                    }

                    string left = s.Substring(0, j);
                    string right = s.Substring(j + key.Length);
                    left=left.Replace('?', 'z');
                    right=right.Replace('?', 'z');
                    string tmp = left + key + right;
                    int cnt = 0;
                    for(int k = 0; k + key.Length - 1 < n; k++)
                    {
                        if (tmp.Substring(k, key.Length) == key)
                        {
                            cnt++;
                        }
                    }

                    if (cnt == 1)
                    {
                        can = true;
                        WriteLine("Yes");
                        WriteLine(tmp);
                        break;
                    }
                }

                if (!can)
                {
                    WriteLine("No");
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
