using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_081
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            long[] array = ReadLongs();
            int absMaxIndex = 0;
            for(int i = 1; i < n; i++)
            {
                if (Math.Abs(array[absMaxIndex]) < Math.Abs(array[i]))
                {
                    absMaxIndex = i;
                }
            }
            var handles = new List<int[]>();
            for(int i = 0; i < n; i++)
            {
                if (array[i] * array[absMaxIndex] < 0)
                {
                    handles.Add(new int[2] { absMaxIndex + 1, i + 1 });
                    array[i] += array[absMaxIndex];
                }
            }
            if (array[absMaxIndex] > 0)
            {
                for (int i = 1; i < n; i++)
                {
                    if (array[i] - array[i - 1] < 0)
                    {
                        handles.Add(new int[2] { i, i + 1 });
                        array[i] += array[i - 1];
                    }
                }
            }
            else if (array[absMaxIndex] < 0)
            {
                for (int i = n - 2; i >= 0; i--)
                {
                    if (array[i + 1] - array[i] < 0)
                    {
                        handles.Add(new int[2] { i + 2, i + 1 });
                        array[i] += array[i + 1];
                    }
                }
            }

            Console.WriteLine(handles.Count);
            for(int i = 0; i < handles.Count; i++)
            {
                Console.WriteLine(handles[i][0] + " " + handles[i][1]);
            }
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
