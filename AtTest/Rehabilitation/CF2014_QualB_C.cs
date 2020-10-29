using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Rehabilitation
{
    class CF2014_QualB_C
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
            string s1 = Read();
            string s2 = Read();
            string s3 = Read();

            int[] cnts1 = new int[26];
            int[] cnts2 = new int[26];
            int[] cnts3 = new int[26];
            for(int i = 0; i < s1.Length; i++)
            {
                cnts1[s1[i] - 'A']++;
                cnts2[s2[i] - 'A']++;
                cnts3[s3[i] - 'A']++;
            }

            int min = 0;
            int max = 0;
            for(int i = 0; i < 26; i++)
            {
                if (cnts1[i] + cnts2[i] < cnts3[i])
                {
                    WriteLine("NO");
                    return;
                }

                min += Max(cnts3[i] - cnts2[i], 0);
                max += Min(cnts1[i], cnts3[i]);
            }

            int half = s1.Length / 2;
            if (min <= half && half <= max)
            {
                WriteLine("YES");
            }
            else
            {
                WriteLine("NO");
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
