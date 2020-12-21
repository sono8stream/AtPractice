using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._1370
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
            for (int i = 0; i < t; i++)
            {
                int n = ReadInt();
                int[] array = ReadInts();
                // 奇数を偶数個に                
                List<int> odds = new List<int>();
                List<int> evens = new List<int>();
                for (int j = 0; j < 2 * n; j++)
                {
                    if (array[j] % 2 == 0)
                    {
                        evens.Add(j + 1);
                    }
                    else
                    {
                        odds.Add(j + 1);
                    }
                }

                int used = 0;
                int oddUse = odds.Count / 2 * 2;
                if (oddUse == 2 * n)
                {
                    oddUse -= 2;
                }
                for (int j = 0; j < oddUse; j += 2)
                {
                    WriteLine(odds[j] + " " + odds[j + 1]);
                    used++;
                }

                int evenUse = (n - 1) * 2 - oddUse;
                for (int j = 0; j < evenUse; j += 2)
                {
                    WriteLine(evens[j] + " " + evens[j + 1]);
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
