using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.CumulativeSum
{
    class ABC_098_C
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int[] weArray = new int[n];
            int eCnt = 0;
            for (int i = 0; i < n; i++)
            {
                if (input[i] == 'W')
                {
                    weArray[i] = -1;
                }
                else
                {
                    weArray[i] = 1;
                    eCnt++;
                }
            }

            int min = 3 * 100000;
            int changeCnt = eCnt;
            for(int i = 0; i < n; i++)//leader
            {
                if (weArray[i] == 1)
                {
                    changeCnt--;//自分のぞく
                }

                if (i > 0 && weArray[i - 1] == -1)
                {
                    changeCnt++;
                }

                if (changeCnt < min)
                {
                    min = changeCnt;
                }
            }

            Console.WriteLine(min);
        }
    }
}
