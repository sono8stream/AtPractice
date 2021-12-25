using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Keyence_2021
{
    class D
    {
        /// <summary>
        /// A A A A B B B B
        /// A A B B A A B B
        /// A A B B B B A A
        /// A B A B A B A B
        /// A B A B B A B A
        /// A B B A A B B A
        /// A B B A B A A B
        /// 
        /// 
        /// A A A A A A A A B B B B B B B B
        /// A A A A B B B B A A A A B B B B
        /// A A A A B B B B B A B B A A A A
        /// A A B B A A B B A A A A B B B B
        /// A A B B A A B B B B B B A A A A
        /// A A B B B B A A A B A A B B B B
        /// A A B B B B A A B B B B A A A A
        /// A B A B A B A B A B A B 
        /// A B A B A B B A B A B A
        /// A B A B B A A B B A B A
        /// A B A B B A B A A B A B
        /// A B B A A B A B A B B A
        /// A B B A A B B A B A A B
        /// A B B A B A A B B A A B
        /// A B B A B A B A A B B A
        /// 
        /// A A A A A A A A B B B B B B B B
        /// A A A A B B B B A A A A B B B B
        /// A A A A B B B B B B B B A A A A
        /// A A B B A A B B A A B B A A B B
        /// A A B B A A B B B B A A B B A A
        /// A A B B B B A A A A A A B B B B
        /// A A B B B B A A B B B B A A A A
        /// A B A B A B A B A B A B 
        /// A B A B A B B A B A B A
        /// A B A B B A A B B A B A
        /// A B A B B A B A A B A B
        /// A B B A A B A B A B B A
        /// A B B A A B B A B A A B
        /// A B B A B A A B B A A B
        /// A B B A B A B A A B B A
        /// </summary>
        /// <param name="args"></param>


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
            int all = 1 << n;
            string[][] pats = new string[n][];
            pats[0] = new string[1] { "AB" };
            for(int i = 1; i < n; i++)
            {
                int sLength = pats[i - 1][0].Length * 2;
                int length = pats[i - 1].Length * 2 + 1;
                pats[i] = new string[length];


                for(int j = 0; j < length-1; j++)
                {
                    pats[i][j] = pats[i - 1][j] + pats[i - 1][j / 2].Reverse();
                }

                for (int j = 0; j < sLength; j++)
                {
                    if (j < sLength / 2)
                    {
                        pats[i][length-1] += 'A';
                    }
                    else
                    {
                        pats[i][length-1] += 'B';
                    }
                }
            }

            WriteLine(all - 1);
            for(int i = 0; i < pats[n - 1].Length; i++)
            {
                WriteLine(pats[n - 1][i]);
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
