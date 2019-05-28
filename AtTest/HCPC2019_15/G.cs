using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.HCPC2019_15
{
    class G
    {
        static void ain(string[] args)
        {
            Method(args);
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[][] crs = new int[n][];
            for (int i = 0; i < n; i++) crs[i] = ReadInts();
            int[][] abs = new int[k][];
            for (int i = 0; i < k; i++) abs[i] = ReadInts();
            var baseGraph = new List<int>[n];
            for (int i = 0; i < n; i++) baseGraph[i] = new List<int>();
            for(int i = 0; i < k; i++)
            {
                baseGraph[abs[i][0] - 1].Add(abs[i][1] - 1);
                baseGraph[abs[i][1] - 1].Add(abs[i][0] - 1);
            }
            var allGraph = new List<int>[n, k + 1];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < k; j++)
                {
                    allGraph[i, j] = new List<int>();
                }
            }
            for(int i = 0; i < n; i++)
            {
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(new int[2] { i, 0 });
                //allGraph[i,k].Add()
                while (queue.Count > 0)
                {
                    int[] val = queue.Dequeue();
                    int index = val[0];
                    int cnt = val[1];
                    if (cnt > crs[i][1]) continue;

                    for(int j = 0; j < baseGraph[index].Count;j++)
                    {
                        //queue.Enqueue(new int[2] { baseGraph[index].})
                    }
                }
            }
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
