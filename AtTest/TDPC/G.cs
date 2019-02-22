using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.TDPC
{
    class G
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string s = Read();
            long k = ReadLong();
            long[,] dp = new long[s.Length, 26];
            dp[s.Length - 1, s[s.Length - 1] - 'a'] = 1;
            long prevAll = 1;
            long limit = long.MaxValue / 2;
            for (int i = s.Length - 2; i >= 0; i--)
            {
                long nowAll = 0;
                for(int j = 0; j < 26; j++)
                {
                    if (s[i] - 'a' == j)
                    {
                        dp[i, j] = prevAll + 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i + 1, j];
                    }
                    nowAll = Math.Min(nowAll + dp[i, j], limit);
                }
                prevAll = nowAll;
            }
            if (prevAll < k)
            {
                Console.WriteLine("Eel");
                return;
            }
            for(int i = 0; i < s.Length && 0 < k; i++)
            {
                int c = 0;
                for(int j = 0; j < 26; j++)
                {
                    if (k - dp[i, j] > 0)
                    {
                        k -= dp[i, j];
                    }
                    else
                    {
                        k--;
                        c = j;
                        break;
                    }
                }
                while (s[i] - 'a' != c) i++;
                Console.Write(s[i]);
            }
            Console.WriteLine();//これ大事！
        }

        private static string Read() { return Console.ReadLine(); }
        private static int ReadInt() { return int.Parse(Read()); }
        private static long ReadLong() { return long.Parse(Read()); }
        private static long ReadDouble() { return long.Parse(Read()); }
        private static int[] ReadInts() { return Array.ConvertAll(Read().Split(), int.Parse); }
        private static long[] ReadLongs() { return Array.ConvertAll(Read().Split(), long.Parse); }
        private static long[] ReadDoubles() { return Array.ConvertAll(Read().Split(), long.Parse); }
    }
}
