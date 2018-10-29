using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Tenka2018
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            var valids = new List<int>();
            int val = 1;
            int d = 2;
            valids.Add(1);
            while (val <= n)
            {
                val += d;
                valids.Add(val);
                d++;
                //Console.WriteLine(valids[valids.Count - 1]);
            }
            int index = valids.BinarySearch(n);
            if (index < 0)
            {
                Console.WriteLine("No");
                return;
            }
            Console.WriteLine("Yes");
            if (index == 0)
            {
                Console.WriteLine(2);
                Console.WriteLine("1 1");
                Console.WriteLine("1 1");
            }
            else
            {
                Console.WriteLine(2 + index);
                List<List<int>> vals = new List<List<int>>();
                vals.Add(new List<int>());
                vals[0].Add(1);
                vals[0].Add(2);
                vals.Add(new List<int>());
                vals[1].Add(1);
                vals[1].Add(3);
                vals.Add(new List<int>());
                vals[2].Add(2);
                vals[2].Add(3);
                for(int i = 2; i <= index; i++)
                {
                    vals.Add(new List<int>());
                    //Console.WriteLine(vals.Count);
                    for(int j = valids[i - 1] + 1; j <= valids[i]; j++)
                    {
                        vals[j - valids[i - 1] -1].Add(j);
                        vals[vals.Count - 1].Add(j);
                    }
                }
                for(int i = 0; i < vals.Count; i++)
                {
                    Console.Write(vals[i].Count + " ");
                    for(int j = 0; j < vals[i].Count; j++)
                    {
                        Console.Write(vals[i][j] + " ");
                    }
                    Console.WriteLine();
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
