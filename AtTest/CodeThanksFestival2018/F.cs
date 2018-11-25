using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeThanksFestival2018
{
    class F
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nmk = ReadInts();
            int[] ps = ReadInts();
            var turns = new int[nmk[0]][];
            var nestCnts = new int[nmk[0]];
            for (int i = 0; i < nmk[0]; i++)
            {
                int turn = 1;
                int now = i;
                while (ps[now] != 0)
                {
                    now = ps[now] - 1;
                    turn++;
                }
                turns[i] = new int[2] { i, turn };
                nestCnts[turn - 1]++;
                Console.WriteLine(turn);
            }
            Array.Sort(turns, (a, b) => a[1] - b[1]);
            int min = 0;
            int max = 0;
            for(int i = 0; i < nmk[1]; i++)
            {
                min += turns[i][1];
                max += turns[nmk[1] - i - 1][1];
            }
            if (nmk[2] < min || nmk[2] > max || nmk[0] == nmk[1])
            {
                Console.WriteLine(-1);
                return;
            }



            var dp = new string[nmk[1], nmk[2]];//i個まで選んでjになるときの辞書順最小
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), double.Parse); }
    }
}
