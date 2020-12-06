using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1397
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
            for (int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[] cnts = new int[26];
                for (int j = 0; j < n; j++)
                {
                    string s = Read();
                    for (int k = 0; k < s.Length; k++)
                    {
                        cnts[s[k] - 'a']++;
                    }
                }

                bool ok = true;
                for(int j = 0; j < 26; j++)
                {
                    if (cnts[j] % n == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ok = false;
                        break;
                    }
                }

                WriteLine(ok ? "YES" : "NO");
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
