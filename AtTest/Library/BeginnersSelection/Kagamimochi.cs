using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class Kagamimochi
    {
        public static void Method(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(array);
            int cnt = n;
            for(int i = n-2; i >=0; i--)
            {
                if (array[i] == array[i + 1])
                {
                    n--;
                }
            }
            Console.WriteLine(n);
            Console.ReadLine();
        }
    }
}
