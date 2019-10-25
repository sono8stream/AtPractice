using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_143
{
    class F
    {
        static void Main(string[] args)
        {
            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            Method(args);

            Out.Flush();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            Array.Sort(array);
            List<int> cnts = new List<int>();
            cnts.Add(1);
            for(int i = 1; i < n; i++)
            {
                if (array[i] == array[i - 1])
                {
                    cnts[cnts.Count-1]++;
                }
                else
                {
                    cnts.Add(1);
                }
            }
            cnts.Sort();
            int[] cans = new int[n+1];
            cans[0] = n;
            int now = 0;
            int sum = 0;
            for(int i = 1; i <=n; i++)
            {
                while (now < cnts.Count && cnts[now] == i-1)
                {
                    now++;
                }
                if (now < cnts.Count)
                {
                    sum += cnts.Count - now;
                }
                cans[i] = sum / i;
            }
            now = n;
            for(int i = 1; i <= n; i++)
            {
                while (cans[now] < i) now--;
                WriteLine(now);
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
