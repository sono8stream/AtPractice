using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_051
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int sx = int.Parse(input[0]);
            int sy = int.Parse(input[1]);
            int tx = int.Parse(input[2]);
            int ty = int.Parse(input[3]);
            string[] ss = new string[4] { "","","","" };
            for (int i = sx; i < tx; i++)
            {
                ss[0] += 'R';
                ss[2] += 'L';
            }
            for(int j = sy; j < ty; j++)
            {
                ss[1] += 'U';
                ss[3] += 'D';
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 1)
                    {
                        switch (j)
                        {
                            case 0:
                                Console.Write("D");
                                break;
                            case 1:
                                Console.Write("RU");
                                break;
                            case 2:
                                Console.Write("LU");
                                break;
                            case 3:
                                Console.Write("LD");
                                break;
                        }
                    }
                    Console.Write(ss[j]);
                }
            }
            Console.WriteLine("R");
        }
    }
}
