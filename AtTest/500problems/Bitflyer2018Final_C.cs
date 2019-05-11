using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._500problems
{
    class Bitflyer2018Final_C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            string s = Read();
            int n = s.Length;
            long[] cnts = new long[n];
            Stack<int> posStack = new Stack<int>();

            for(int i = 0; i < n; i++)
            {
                if (s[i] == '(') posStack.Push(i);
                else if(posStack.Count>0)
                {
                    int start = posStack.Pop();
                    cnts[i] = 1;
                    if (start > 0) cnts[i] += cnts[start - 1];
                }
            }

            long res = 0;
            for (int i = 0; i < n; i++) res += cnts[i];

            WriteLine(res);
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
