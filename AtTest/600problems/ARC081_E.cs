using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._600problems
{
    class ARC081_E
    {
        static void Main(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string a = Read();

            int c = 26;
            List<char>[] valids = new List<char>[c];
            for(int i = 0; i < c; i++)
            {
                valids[i] = new List<char>();
                valids[i].Add((char)('a' + i));
            }

            for(int i = a.Length - 1; i >= 0; i--)
            {
                int index = 0;
                for(int j = 0; j < c; j++)
                {
                    if (valids[index].Count <= valids[j].Count) continue;

                    index = j;
                }

                List<char> next = new List<char>();
                next.Add(a[i]);
                next.AddRange(valids[index]);
                valids[a[i] - 'a'] = next;
            }

            int resIndex = 0;
            for(int i = 0; i < c; i++)
            {
                if (valids[resIndex].Count <= valids[i].Count) continue;

                resIndex = i;
            }
            WriteLine(valids[resIndex].ToArray());
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
