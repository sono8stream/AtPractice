using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CodeForces._535
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var list = new List<int>();
            list.AddRange(ReadInts());
            list.Sort();
            list.Reverse();
            int max = list[0];
            list.RemoveAt(0);
            int now = max;
            for (int i = 0; i < list.Count; i++)
            {
                if (now != list[i]
                    && max % list[i] == 0)
                {
                    now = list[i];
                    list.RemoveAt(i);
                    i--;
                }
            }
            Console.WriteLine(max + " " + list[0]);
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static double ReadDouble() { return double.Parse(Read(), System.Globalization.CultureInfo.InvariantCulture); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static double[] ReadDoubles() { return Array.ConvertAll(Read().Split(), i => Convert.ToDouble(i, System.Globalization.CultureInfo.InvariantCulture)); }
    }
}
