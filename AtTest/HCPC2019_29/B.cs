using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_29
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
            while (true)
            {
                int n = ReadInt();
                if (n == 0) break;
                string[] strs = new string[n];
                for(int i = 0; i < n; i++)
                {
                    string s = Read();
                    string tmp = "";
                    tmp += s[0];
                    for (int j = 0; j < s.Length - 1; j++)
                    {
                        if (s[j] == 'a' || s[j] == 'i' || s[j] == 'u'
                            || s[j] == 'e' || s[j] == 'o')
                        {
                            tmp += s[j + 1];
                        }
                    }
                    strs[i] = tmp;
                }
                bool done = false;
                for(int i = 1; i <= 50; i++)
                {
                    var hashSet = new HashSet<string>();
                    bool can = true;
                    for (int j = 0; j < n; j++)
                    {
                        string tmp = "";
                        for(int k = 0; k < Min(i, strs[j].Length); k++)
                        {
                            tmp += strs[j][k];
                        }
                        if (hashSet.Contains(tmp))
                        {
                            can = false;
                            break;
                        }
                        hashSet.Add(tmp);
                    }
                    if (can)
                    {
                        WriteLine(i);
                        done = true;
                        break;
                    }
                }
                if(!done)                WriteLine(-1);
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
