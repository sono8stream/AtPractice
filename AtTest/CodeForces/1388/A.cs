using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.CodeForces._1388
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
            for(int i=0;i<t;i++)
            {
                int n = ReadInt();
                int one = 6;
                int two = 10;
                int three = 14;
                int sum = one + two + three;
                if (n <= sum)
                {
                    WriteLine("NO");
                }
                else
                {
                    WriteLine("YES");
                    int remain = n - sum;
                    if (remain == one||remain==two||remain==three)
                    {
                        WriteLine(one + " " + two + " " + (three + 1) +" "+ (remain - 1));
                    }
                    else
                    {
                        WriteLine(one + " " + two + " " + three + " " + remain);
                    }
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
