using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.NothingToLearn
{
    class ABC02_B
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
            int n = ReadInt();
            int[] array = ReadInts();
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                sum += array[i];
            }
            if (sum % n > 0)
            {
                WriteLine(-1);
                return;
            }

            int target = sum / n;
            int res = 0;
            int seq = 0;
            int tmp = 0;
            for(int i = 0; i < n; i++)
            {
                tmp += array[i];
                seq++;
                if (tmp == target * seq)
                {
                    tmp = 0;
                    seq = 0;
                }
                else
                {
                    res++;
                }
            }
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
