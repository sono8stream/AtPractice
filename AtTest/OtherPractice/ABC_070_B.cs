using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class ABC_070_B
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);
            int d = int.Parse(input[3]);

            int time = 0;
            if (a < c)
            {
                int max = b < d ? b : d;
                time = max - c;
                if (time < 0)
                {
                    time = 0;
                }
            }
            else
            {
                int max = d < b ? d : b;
                time = max - a;
                if (time < 0)
                {
                    time = 0;
                }
            }
            Console.WriteLine(time);
        }
    }
}
