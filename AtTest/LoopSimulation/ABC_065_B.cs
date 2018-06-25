using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.LoopSimulation
{
    class ABC_065_B
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            bool[] gone = new bool[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                gone[i] = false;
            }

            int pushCnt = 0;
            int now = 0;
            while (gone[1] == false)
            {
                now = array[now] - 1;
                if (gone[now] == true)
                {
                    Console.WriteLine(-1);
                    return;
                }
                pushCnt++;
                gone[now] = true;
            }

            Console.WriteLine(pushCnt);
        }
    }
}