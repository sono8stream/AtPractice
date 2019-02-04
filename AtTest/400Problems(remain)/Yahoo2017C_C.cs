using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest._400Problems_remain_
{
    class Yahoo2017C_C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int[] nk = ReadInts();
            int n = nk[0];
            int k = nk[1];
            int[] array = ReadInts();
            string[] strs = new string[n];
            for(int i = 0; i < n; i++)
            {
                strs[i] = Read();
            }
            if (n == k)
            {
                Console.WriteLine();
                return;
            }

            var inDict = new Dictionary<int, bool>();
            for(int i = 0; i < k; i++)
            {
                inDict.Add(array[i] - 1, true);
            }
            string baseStr = strs[array[0] - 1];
            int commonLength = baseStr.Length;
            int notCommonLength = 0;
            for(int i = 0; i < n; i++)
            {
                int j = 0;
                for (; j < strs[i].Length && j < commonLength; j++)
                {
                    if (baseStr[j] != strs[i][j]) break;
                }
                if (inDict.ContainsKey(i))
                {
                    commonLength = Math.Min(commonLength, j);
                }
                else
                {
                    notCommonLength = Math.Max(notCommonLength, j);
                }
            }
            if (commonLength <= notCommonLength) Console.WriteLine(-1);
            else Console.WriteLine(baseStr.Substring(0, notCommonLength + 1));
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
