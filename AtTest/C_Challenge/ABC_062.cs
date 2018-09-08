using System;
using System.Linq;

namespace AtTest.C_Challenge
{
    class ABC_062
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            long h = long.Parse(input[0]);
            long w = long.Parse(input[1]);
            if (h % 3 == 0 || w % 3 == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                var margin = new long[4];
                //タテ3分割
                margin[0] = w;
                //ヨコ3分割
                margin[1] = h;

                //タテ1ヨコ2
                long h1 = h / 2;
                long h2 = (h + 1) / 2;
                for (int i = 1; i < w; i++)
                {
                    var tempArea = new long[3];
                    tempArea[0] = h * i;
                    tempArea[1] = h1 * (w - i);
                    tempArea[2] = h2 * (w - i);
                    long newMargin = tempArea.Max() - tempArea.Min();
                    if (margin[2] == 0 || newMargin < margin[2])
                    {
                        margin[2] = newMargin;
                    }
                }

                //タテ2ヨコ1
                long w1 = w / 2;
                long w2 = (w + 1) / 2;
                for (int i = 1; i < h; i++)
                {
                    var tempArea = new long[3];
                    tempArea[0] = w * i;
                    tempArea[1] = w1 * (h - i);
                    tempArea[2] = w2 * (h - i);
                    long newMargin = tempArea.Max() - tempArea.Min();
                    if (margin[3] == 0 || newMargin < margin[3])
                    {
                        margin[3] = newMargin;
                    }
                }
                Console.WriteLine(margin.Min());
            }
        }
    }
}
