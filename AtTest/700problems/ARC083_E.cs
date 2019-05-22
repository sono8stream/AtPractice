using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest._700problems
{
    class ARC083_E
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int n = ReadInt();
            if (n == 1)
            {
                Read();
                Read();
                WriteLine("POSSIBLE");
                return;
            }

            int[] ps = ReadInts();
            int[] xs = ReadInts();

            int[] childCnt = new int[n];
            for(int i = 0; i < ps.Length; i++)
            {
                childCnt[ps[i] - 1]++;
            }
            
            var pairList = new List<KeyValuePair<int, int>>[n];
            for (int i = 0; i < n; i++)
            {
                pairList[i] = new List<KeyValuePair<int, int>>();
            }

            var queue = new Queue<int>();
            for(int i = 0; i < n; i++)
            {
                if (childCnt[i] == 0)
                {
                    queue.Enqueue(i);
                    pairList[i].Add(new KeyValuePair<int, int>(0, 0));
                }
            }

            while (queue.Count > 0)
            {
                int index = queue.Dequeue();
                var dp = new HashSet<int>();
                dp.Add(0);
                int sum = 0;
                for(int i = 0; i < pairList[index].Count; i++)
                {
                    var pair = pairList[index][i];

                    var next = new HashSet<int>();
                    foreach(int val2 in dp)
                    {
                        int val1 = sum - val2;
                        if (val1 + pair.Key <= xs[index])
                        {
                            next.Add(val2 + pair.Value);
                        }
                        if (val1 + pair.Value <= xs[index])
                        {
                            next.Add(val2 + pair.Key);
                        }
                    }

                    dp = next;
                    sum += pair.Key + pair.Value;
                }

                int min = int.MaxValue;
                foreach(int val in dp)
                {
                    min = Min(min, val);
                }

                if (min == int.MaxValue)
                {
                    WriteLine("IMPOSSIBLE");
                    return;
                }

                if (index == 0) continue;

                int parent = ps[index - 1] - 1;
                pairList[parent].Add(
                    new KeyValuePair<int, int>(xs[index], min));
                childCnt[parent]--;
                if (childCnt[parent] == 0)
                {
                    queue.Enqueue(parent);
                }
            }

            WriteLine("POSSIBLE");
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
