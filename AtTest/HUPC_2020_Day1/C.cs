using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HUPC_2020_Day1
{
    class C
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
            int[] nm = ReadInts();
            int n = nm[0];
            int m = nm[1];

            /// 上から桁を見て，より少ない方を選択していけば必ず登場していない値があるはず
            /// 1回見るごとに半分以下にできるので，20桁分繰り返すと10^6個までなら特定できる
            /// n>=20ならm<2500000/20=125000なので一意に特定可能

            string[] ss = new string[m];
            var list = new List<int>();
            for (int i = 0; i < m; i++)
            {
                ss[i] = Read();
                list.Add(i);
            }

            bool[] res = new bool[n];
            for (int i = 0; i < Min(n, 20); i++)
            {
                int zeros = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (ss[list[j]][i] == '0')
                    {
                        zeros++;
                    }
                }

                res[i] = zeros > list.Count / 2;

                var next = new List<int>();
                for (int j = 0; j < list.Count; j++)
                {
                    if ((ss[list[j]][i] == '0' && zeros <= list.Count/2)
                        || (ss[list[j]][i] == '1' && zeros > list.Count/2))
                    {
                        next.Add(list[j]);
                    }
                }

                list = next;
            }

            for(int i = 0; i < n; i++)
            {
                if (20 <= i)
                {
                    Write('*');
                }
                else
                {
                    Write(res[i] ? 1 : 0);
                }
            }
            WriteLine();
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
