using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.Tenka2018
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
            var array = new long[n];
            for(int j = 0; j < n; j++)
            {
                array[j] = ReadLong();
            }
            Array.Sort(array);
            long score = 0;
            long left = array[0];
            long right = array[0];
            int cnt = n / 2;
            if (n % 2 == 0) cnt--;
            int itr = n - 2;
            int evenI = n-2;
            int oddI = 1;

            int i = 0;
            for(; i<cnt;i++)
            {
                if (i % 2 == 0)
                {
                    itr = evenI;
                    evenI -= 2;
                }
                else
                {
                    itr = oddI;
                    oddI += 2;
                }
                //Console.WriteLine(itr);

                score += Math.Abs(array[itr] + array[itr + 1] - left - right);
                left = array[itr];
                right = array[itr + 1];
                /*itr += d;
                d *= -1;
                d += dd;
                dd *= -1;*/

            }
            if (n % 2 == 0)
            {
                itr = oddI;
                //Console.WriteLine(itr);
                score += Math.Max(
                    Math.Abs(array[itr] - left), Math.Abs(array[itr] - right));
            }
            long score2 = 0;
            Array.Reverse(array);
            evenI = n - 2;
            oddI = 1;
            left = array[0];
            right = array[0];

            i = 0;
            for (; i < cnt; i++)
            {
                if (i % 2 == 0)
                {
                    itr = evenI;
                    evenI -= 2;
                }
                else
                {
                    itr = oddI;
                    oddI += 2;
                }
                //Console.WriteLine(itr);

                score2 += Math.Abs(array[itr] + array[itr + 1] - left - right);
                left = array[itr];
                right = array[itr + 1];
                /*itr += d;
                d *= -1;
                d += dd;
                dd *= -1;*/

            }
            if (n % 2 == 0)
            {
                itr = oddI;
                //Console.WriteLine(itr);
                score2 += Math.Max(
                    Math.Abs(array[itr] - left), Math.Abs(array[itr] - right));
            }

            Console.WriteLine(Math.Max(score, score2));
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
