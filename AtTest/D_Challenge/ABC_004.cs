using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.D_Challenge
{
    class ABC_004
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int r = int.Parse(input[0]);
            int g = int.Parse(input[1]);
            int b = int.Parse(input[2]);
            int rRight = (r - 1) / 2 - 100;
            int rLeft = -r / 2 - 100;
            int bLeft = -(b - 1) / 2 + 100;
            int bRight = b / 2 + 100;
            for (int i = -g + 1; i <= g - 1; i++)
            {
                //r
                if (i <= rRight)
                {
                    rLeft += rRight - i - 1;
                    rRight = i - 1;
                }

                //b
                if (bLeft <= i + g - 1)
                {
                    rLeft += rRight - i - 1;
                    rRight = i - 1;
                }
            }

            Console.WriteLine("text");
        }
    }
}
