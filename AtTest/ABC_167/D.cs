using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_167
{
    class D
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
            long[] nk = ReadLongs();
            long n = nk[0];
            long k = nk[1];
            long[] array = ReadLongs();
            for(int i = 0; i < n; i++)
            {
                array[i]--;
            }

            var visited = new Dictionary<long, long>();
            long now = 0;
            long turn = 0;
            while (!visited.ContainsKey(now))
            {
                visited.Add(now, turn);
                if (turn == k)
                {
                    WriteLine(now + 1);
                    return;
                }

                now = array[now];
                turn++;
            }

            long loopCnt = turn - visited[now];
            k -= turn;
            k %= loopCnt;
            turn = 0;
            while (turn!=k)
            {
                now = array[now];
                turn++;
            }

            WriteLine(now+1);
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
