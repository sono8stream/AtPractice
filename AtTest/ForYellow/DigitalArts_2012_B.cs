using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ForYellow
{
    class DigitalArts_2012_B
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
            string s = Read();
            int val = 0;
            for(int i = 0; i < s.Length; i++)
            {
                val += s[i] - 'a';
                val++;
            }

            if (val == 1 || val == 26 * 20)
            {
                WriteLine("NO");
            }
            else
            {
                List<char> res = new List<char>();
                while (val > 0)
                {
                    if (val >= 26)
                    {
                        res.Add('z');
                        val -= 26;
                    }
                    else
                    {
                        res.Add((char)('a' + val - 1));
                        val = 0;
                    }
                }
                if (new string(res.ToArray()) == s)
                {
                    if (res.Count == 1)
                    {
                        res[0]--;
                        res.Add('a');
                    }
                    else
                    {
                        res[res.Count - 1]++;
                        res[res.Count - 2]--;
                    }
                }
                WriteLine(new string(res.ToArray()));
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
