using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.AGC_037
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
            int n = ReadInt();
            int[] aArray = ReadInts();
            int[] bArray = ReadInts();
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                int prev = (i + n - 1) % n;
                int next = (i + 1) % n;
                if (bArray[i] - bArray[prev] -bArray[next] >= aArray[i])
                {
                    queue.Enqueue(i);
                }
            }
            long cnt = 0;
            while (queue.Count > 0)
            {
                int i = queue.Dequeue();
                int prev = (i + n - 1) % n;
                int next = (i + 1) % n;
                int tmpCnt = (bArray[i] - Max(bArray[prev], bArray[next]))
                    / (bArray[prev] + bArray[next]);
                if ((bArray[i] - Max(bArray[prev], bArray[next]))
                    % (bArray[prev] + bArray[next]) > 0) tmpCnt++;
                tmpCnt = Min(tmpCnt, 
                    (bArray[i] - aArray[i]) / (bArray[prev] + bArray[next]));
                bArray[i] -= (bArray[prev] + bArray[next]) * tmpCnt;
                cnt += tmpCnt;

                int prev2 = (prev + n - 1) % n;
                int next2 = (next + 1) % n;
                if (bArray[prev] - bArray[prev2] - bArray[i] >= aArray[prev])
                {
                    queue.Enqueue(prev);
                }
                if (bArray[next] - bArray[i] - bArray[next2] >= aArray[next])
                {
                    queue.Enqueue(next);
                }
            }

            for(int i = 0; i < n; i++)
            {
                if (aArray[i] != bArray[i])
                {
                    WriteLine(-1);
                    return;
                }
            }
            WriteLine(cnt);
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
