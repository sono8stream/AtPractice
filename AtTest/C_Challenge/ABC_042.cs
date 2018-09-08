using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_042
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            var ngs = new int[k];
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < k; i++)
            {
                ngs[i] = int.Parse(input[i]);
            }

            int digit = (int)Math.Log10(n) + 1;
            
            int itel = n;
            while (n < 100000)
            {
                int sub = itel;
                bool isNG = false;
                for (int j = 0; sub>0; j++)
                {
                    int val = sub % 10;
                    for(int l = 0; l < k; l++)
                    {
                        if (val == ngs[l])
                        {
                            isNG = true;
                            break;
                        }
                    }
                    if (isNG) break;
                    sub /= 10;
                }
                if (!isNG) break;
                itel++;
            }
            Console.WriteLine(itel);
        }
    }
}
