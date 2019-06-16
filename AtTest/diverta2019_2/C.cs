using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.diverta2019_2
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = ReadLongs();
            /*long[] sorted = array.OrderBy(a => a).ToArray();
            long m = 0;
            for(int i = 0; i < n; i++)
            {
                if (i < n - 1 && sorted[i] < 0) m += -sorted[i];
                else m += sorted[i];
            }*/
            int maxIndex = 0;
            int minIndex = 0;
            for(int i = 0; i < n; i++)
            {
                if (array[maxIndex] < array[i]) maxIndex = i;
                if (array[minIndex] >= array[i]) minIndex = i;
            }
            long m = 0;
            for(int i = 0; i < n; i++)
            {
                if (i == minIndex || i == maxIndex) continue;
                m += Abs(array[i]);
            }
            m += array[maxIndex];
            m -= array[minIndex];

            var sw = new System.IO.StreamWriter(OpenStandardOutput()) { AutoFlush = false };
            SetOut(sw);

            WriteLine(m);
            for(int i = 0; i < n; i++)
            {
                if (i == minIndex || i == maxIndex) continue;

                if (array[i] < 0)
                {
                    WriteLine(array[maxIndex] + " " + array[i]);
                    array[maxIndex] -= array[i];
                }
                else
                {
                    WriteLine(array[minIndex] + " " + array[i]);
                    array[minIndex] -= array[i];
                }
            }
            WriteLine(array[maxIndex] + " " + array[minIndex]);

            Out.Flush();
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
