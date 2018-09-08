using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_108
{
    class B
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int x1 = int.Parse(input[0]);
            int y1 = int.Parse(input[1]);
            int x2 = int.Parse(input[2]);
            int y2 = int.Parse(input[3]);

            int x3, y3, x4, y4;

            /*if (x1 == x2)
            {
                int length = Math.Abs(y2 - y1);
                if (y1 < y2)
                {
                    x3 = x1 - length;
                }
                else
                {
                    x3 = x1 + length;
                }
                x4 = x3;
                y3 = y2;
                y4 = y1;
            }
            else
            {
                int length = Math.Abs(x2 - x1);
                if (x1 < x2)
                {
                    y3 = y1 + length;
                }
                else
                {
                    y3 = y1 - length;
                }
                y4 = y3;
                x3 = x2;
                x4 = x1;
            }*/

            x3 = x2 - (y2 - y1);
            y3 = y2 + (x2 - x1);
            x4 = x3 - (x2 - x1);
            y4 = y3 - (y2 - y1);

            Console.WriteLine(x3+" "+y3+" "+ x4 + " " + y4);
        }
    }
}
