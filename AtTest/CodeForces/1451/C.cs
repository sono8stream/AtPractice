using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1451
{
    class C
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
            for(int i = 0; i < t; i++)
            {
                int[] nk = ReadInts();
                int n = nk[0];
                int k = nk[1];
                string a = Read();
                string b = Read();
                int[] cntsA = new int[26];
                int[] cntsB = new int[26];

                for(int j = 0; j < n; j++)
                {
                    cntsA[a[j] - 'a']++;
                    cntsB[b[j] - 'a']++;
                }

                bool ok = true;
                int joker = 0;
                for(int j = 0; j < 26; j++)
                {
                    cntsA[j] += joker;
                    joker = 0;
                    if (cntsA[j] < cntsB[j])
                    {
                        ok = false;
                        break;
                    }
                    if (cntsA[j] > cntsB[j])
                    {
                        int delta = cntsA[j] - cntsB[j];
                        if (delta % k == 0)
                        {
                            joker = delta;
                        }
                        else
                        {
                            ok = false;
                            break;
                        }
                    }
                }
                WriteLine(ok ? "Yes" : "No");
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
