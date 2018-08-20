using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_103
{
    class A
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] array = new int[3];
            for (int i = 0; i < 3; i++)
            {
                array[i] = int.Parse(input[i]);
            }

            int cost = 0;
            Array.Sort(array);
            cost += array[1] - array[0];
            cost += array[2] - array[1];

            Console.WriteLine(cost);
        }
    }
}
