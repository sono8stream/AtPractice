using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.SoundHound2018
{
    class SH_2018_C
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int d = int.Parse(input[2]);

            int pats =0;
            if (d == 0)
            {
                pats = n;
            }
            else
            {
                pats = 2 * (n - d);
            }
            double val = (double)pats * (m - 1) / n / n;
            Console.WriteLine(val);

            /*long lim = (long)Math.Pow(n, m);
            long num1 = 0, num2 = 0;
            int allKirei = 0;
            for (long i = 0; i < lim; i++)
            {
                long num = i;
                string s = "";
                int kirei = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        num1 = num % n + 1;
                    }
                    else
                    {
                        num2 = num % n + 1;
                        if (Math.Abs(num1 - num2) == d)
                        {
                            kirei++;
                        }
                        num1 = num2;
                    }
                    s += num1.ToString();
                    num /= n;
                }
                s += " " + kirei.ToString();
                Console.WriteLine(s);
                allKirei += kirei;
            }
            Console.WriteLine(allKirei);
            */
        }
    }
}
