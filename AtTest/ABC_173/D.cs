using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.ABC_173
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
            int n = ReadInt();
            long[] array = ReadLongs();
            Array.Sort(array);
            Array.Reverse(array);

            long res = array[0];
            var que1 = new Queue<long>();
            var que2 = new Queue<long>();
            que1.Enqueue(array[1]);
            for (int i = 2; i < n; i++)
            {
                if (que2.Count == 0 || que1.Peek() > que2.Peek())
                {
                    que2.Enqueue(que1.Peek());
                    res += que1.Dequeue();
                }
                else
                {
                    res += que2.Dequeue();
                }
                que1.Enqueue(array[i]);
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
