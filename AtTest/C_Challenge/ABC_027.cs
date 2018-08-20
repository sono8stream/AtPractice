using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_027
    {
        static void Main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {

            }
            Console.WriteLine("text");
        }

        //確実に勝てるか返す
        static bool DFS(long n, long x)
        {
            if (x == n / 2 + 1) return false;

            return !DFS(n, x * 2) || !DFS(n, x * 2 + 1);
        }
    }
}