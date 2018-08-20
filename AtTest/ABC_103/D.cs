using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_103
{
    class D
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
            var request = new int[m][];
            for (int i = 0; i < m; i++)
            {
                string[] inText = Console.ReadLine().Split(' ');
                request[i] = new int[2];
                request[i][0] = int.Parse(inText[0]) - 1;
                request[i][1] = int.Parse(inText[1]) - 1;
            }

            List<int[]> check = new List<int[]>();
            Array.Sort(request, (a, b) => a[0] - b[0]);
            check.Add(request[0]);
            int nowIndex = 0;
            for (int i = 1; i < m; i++)
            {
                if (request[i][1] <= check[nowIndex][1])//内包
                {
                    check[nowIndex][0] = request[i][0];
                    check[nowIndex][1] = request[i][1];
                }
                else
                {
                    if (request[i][0] < check[nowIndex][1])//被り
                    {
                        check[nowIndex][0] = request[i][0];
                    }
                    else//独立
                    {
                        check.Add(request[i]);
                        nowIndex++;
                    }
                }
            }

            Console.WriteLine(check.Count);
        }
    }
}
