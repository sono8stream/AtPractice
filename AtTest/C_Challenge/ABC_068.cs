using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_068
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            var stoppings = new Dictionary<int, bool>();
            var abs = new int[m][];
            for (int i = 0; i < m; i++)
            {
                int[] ab= ReadInts();
                abs[i] = new int[2];
                abs[i][0] = ab[0];
                abs[i][1] = ab[1];
            }
            Array.Sort(abs, (a, b) => a[0] - b[0]);

            for(int i = 0; i < m; i++)
            {
                if (abs[i][0] == 1)
                {
                    stoppings.Add(abs[i][1], true);
                }
                else
                {
                    if (abs[i][1] == n&&stoppings.ContainsKey(abs[i][0]))
                    {
                        Console.WriteLine("POSSIBLE");
                        return;
                    }
                }
            }

            Console.WriteLine("IMPOSSIBLE");
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
