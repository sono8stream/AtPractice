using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.JOI2019_2
{
    class E
    {
        static Dictionary<char, int> dict;
        static long mask = 1000000000 + 7;

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
            string s = Read();
            char res = Read()[0];
            long[] cnts = DFS(s);
            dict = new Dictionary<char, int>();
            dict.Add('R', 0);
            dict.Add('S', 1);
            dict.Add('P', 2);
            WriteLine(cnts[dict[res]]);
        }

        static long[] DFS(string str)
        {

            long[] ret = new long[3];
            if (str.Length == 1)
            {
                if (str[0] == '?')
                {
                    ret[0] = 1;
                    ret[1] = 1;
                    ret[2] = 1;
                }
                else
                {
                    ret[dict[str[0]]]++;
                }
                return ret;
            }

            int nest = 0;
            char opr = '0';
            string child = "";
            for(int i = 0; i < str.Length; i++)
            {
                //if()
            }

            return ret;
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
