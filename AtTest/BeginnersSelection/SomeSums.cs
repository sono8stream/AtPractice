using System;

namespace AtTest
{
    class SomeSums
    {
        public static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int a = int.Parse(input[1]);
            int b = int.Parse(input[2]);
            int sums = 0;

            for(int i = 1; i <= n; i++)
            {
                int sum = 0;
                for(int j=i; j >0; j /= 10)
                {
                    sum += j % 10;
                }

                if (a <= sum && sum <= b)
                {
                    sums += i;
                }
            }

            Console.WriteLine(sums);
            Console.ReadLine();
        }
    }
}
