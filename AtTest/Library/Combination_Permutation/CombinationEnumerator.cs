using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class CombinationEnumerator
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nm = ReadInts();
            List<int[]> allPat= EnumerateCombination(nm[0], nm[1]);
            for(int i = 0; i < allPat.Count; i++)
            {
                for(int j = 0; j < nm[1]; j++)
                {
                    Console.Write(allPat[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static List<int[]> EnumerateCombination(int n,int m)
        {
            var all = new List<List<int>>[n];
            for (int i = 0; i <= n - m; i++)
            {
                var list = new List<int>();
                list.Add(i);
                all[i] = new List<List<int>>();
                all[i].Add(list);
            }

            for(int i = 1; i < m; i++)
            {
                var next = new List<List<int>>[n];
                for(int j = i; j <= n-m+i; j++)
                {
                    next[j] = new List<List<int>>();
                    for (int k = i - 1; k < j; k++)
                    {
                        for(int l = 0;  
                            all[k]!=null&& l < all[k].Count; l++)
                        {
                            var list = new List<int>();
                            list.AddRange(all[k][l]);
                            list.Add(j);
                            next[j].Add(list);
                        }
                    }
                }
                all = next;
            }

            var res = new List<int[]>();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; all[i]!=null&&j < all[i].Count; j++)
                {
                    res.Add(all[i][j].ToArray());
                }
            }
            return res;
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
