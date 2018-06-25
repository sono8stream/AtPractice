using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class FirstContest
    {
        public static void MethodA(string[] args)
        {
            string input = Console.ReadLine();
            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+')
                {
                    number++;
                }
                else
                {
                    number--;
                }
            }

            Console.WriteLine(number);
            Console.ReadLine();
        }

        public static void MethodB(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sn = 0;
            int subN = n;
            while (subN > 9)
            {
                sn += subN % 10;
                subN /= 10;
            }
            sn += subN;
            if (n % sn == 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.ReadLine();
        }

        public static void MethodC(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            string[] arrayInput = Console.ReadLine().Split(' ');
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(arrayInput[i]);
            }

            Array.Sort(array);
            int changeCount = 0;
            int index = 0;
            int firstVal = array[0];
            while (index < n)
            {
                if (array[index] == firstVal)
                {
                    index++;
                    //continue;
                }
                else
                {
                    index += k - 1;
                    changeCount++;
                }
            }

            Console.WriteLine(changeCount);
            Console.ReadLine();
        }

        public static void MethodD(string[] args)
        {
            int k = int.Parse(Console.ReadLine());

            long max = 1000000000000000;
            long now = 19;
            long delta = 10;
            for (int i = 1; i <= k && now <= max; i++)
            {
                if (i < 10)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    for (; now < max; now += delta)
                    {
                        if (Snk(now) <= Snk(now + delta))
                        {
                            Console.WriteLine(now);
                            now += delta;
                            break;
                        }
                        else
                        {
                            now -= delta;
                            delta *= 10;
                        }
                    }
                }
            }
        }
        
        public static double Snk(long val)
        {
            long sk = 0;
            long subN = val;
            while (subN > 9)
            {
                sk += subN % 10;
                subN /= 10;
            }
            sk += subN;
            return (double)val/sk;
        }
    }
}
