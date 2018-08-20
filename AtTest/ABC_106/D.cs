using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dcoder
{
    public class Program
    {
        public static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        public static void Method(string[] args)
        {
            string[] s = Console.ReadLine().Split(' ');
            int n = int.Parse(s[0]);
            int m = int.Parse(s[1]);
            int q = int.Parse(s[2]);
            var ranges = new int[n,n];
            for (int i = 0; i < m; i++)
            {
                s = Console.ReadLine().Split(' ');
                int l = int.Parse(s[0]) - 1;
                int r = int.Parse(s[1]) - 1;
                ranges[l, r]++;
            }
            var rangeSums = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                //string ss = "";
                for(int j = i; j < n; j++)
                {
                    if (j == i)
                    {
                        rangeSums[i, j] = ranges[i, j];
                    }
                    else
                    {
                        rangeSums[i, j] = rangeSums[i, j - 1] + ranges[i, j];
                    }
                    //ss += rangeSums[i, j].ToString() + " ";
                }
                //Console.WriteLine(ss);
            }

            var questions = new int[q, 2];
            for (int i = 0; i < q; i++)
            {
                s = Console.ReadLine().Split(' ');
                questions[i, 0] = int.Parse(s[0]) - 1;
                questions[i, 1] = int.Parse(s[1]) - 1;
            }

            for (int i = 0; i < q; i++)
            {
                int cnt = 0;
                for (int j = questions[i, 0]; j <= questions[i, 1]; j++)
                {
                    cnt += rangeSums[j, questions[i, 1]];
                }
                Console.WriteLine(cnt);
            }

        }
    }
}