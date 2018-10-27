using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_083
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            var sequenceList = new List<int>();
            bool isZero = s[0] == '0';
            int nowCnt = 1;
            for (int i = 1; i < s.Length; i++)
            {
                if ((isZero && s[i] == '0')
                    || (!isZero && s[i] == '1'))
                {
                    nowCnt++;
                }
                else
                {
                    sequenceList.Add(nowCnt);
                    isZero = s[i] == '0';
                    nowCnt = 1;
                }
            }
            sequenceList.Add(nowCnt);
            int first = 0;
            int last = sequenceList.Count - 1;
            int head = sequenceList[first];
            int tail = sequenceList[last];
            int min = int.MaxValue;
            while (head + tail < s.Length)
            {
                if (head < tail)
                {
                    min = Math.Min(min, s.Length - head);
                    first++;
                    head += sequenceList[first];
                }
                else
                {
                    min = Math.Min(min, s.Length - tail);
                    last--;
                    tail += sequenceList[last];
                }
            }
            Console.WriteLine(Math.Max(head, tail));
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
