using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Keyence
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            int[] array = ReadInts();
            int[] bArray = ReadInts();
            long aSum = 0;
            long bSum = 0;
            for(int i = 0; i < n; i++)
            {
                aSum += array[i];
                bSum += bArray[i];
            }
            if (aSum < bSum)
            {
                Console.WriteLine(-1);
                return;
            }
            var pluses = new List<int>();
            long minusSum = 0;
            int minusCnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] < bArray[i])
                {
                    minusSum += bArray[i] - array[i];
                    minusCnt++;
                }
                if (array[i] > bArray[i]) pluses.Add(array[i] - bArray[i]);
            }
            if (minusCnt == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (minusSum == 0)
            {
                Console.WriteLine(minusCnt);
                return;
            }

            long pSum = 0;
            pluses.Sort();
            pluses.Reverse();
            for (int i = 0; i < pluses.Count; i++)
            {
                pSum += pluses[i];
                if (pSum >= minusSum)
                {
                    Console.WriteLine(minusCnt + i + 1);
                    return;
                }
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
