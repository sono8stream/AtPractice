using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class CardTwo
    {
        public static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            int[] raw = new int[n];
            for(int i = 0; i < n; i++)
            {
                raw[i] = int.Parse(input[i]);
            }
            Array.Sort(raw);
            int margin = 0;

            for (int i = n - 1; i >= 0; i-=2)
            {
                margin += raw[i];
                if (i == 0) break;
                margin -= raw[i - 1];
            }

            Console.WriteLine(margin);
            Console.ReadLine();
        }
    }
}
