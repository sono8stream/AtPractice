using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.BinarySearch
{
    class JOY_07_C
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
            List<int> targets = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int val = int.Parse(Console.ReadLine());
                if (val == m)
                {
                    Console.WriteLine(m);
                    return;
                }
                else if (val < m)
                {
                    targets.Add(val);
                }
            }
            targets.Sort();

            Console.WriteLine("text");
        }
    }
}