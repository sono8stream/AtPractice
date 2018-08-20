using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_104
{
    class C
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int d = int.Parse(input[0]);
            long g = int.Parse(input[1]);
            var scores = new List<long[]>();
            for (int i = 0; i < d; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                scores.Add(new long[int.Parse(inputs[0])]);
                for (int j = 0; j < scores[i].Length; j++)
                {
                    scores[i][j] = 100 * (i + 1) * (j + 1);
                }
                scores[i][scores[i].Length - 1] += long.Parse(inputs[1]);
            }

            long allPat = 1 << d;
            int resultCnt = 1000000000;
            for (long i = 0; i < allPat; i++)
            {
                long score = 0;
                int restIndex = 0;//中途半端に解き、配点最大のもの
                int cnt = 0;
                for (int j = 0; j < d; j++)
                {
                    if (((i >> j) & 1) == 1)
                    {
                        score += scores[j][scores[j].Length - 1];
                        cnt += scores[j].Length;
                    }
                    else
                    {
                        restIndex = j;
                    }
                }

                if (score < g)
                {
                    if (score + scores[restIndex][scores[restIndex].Length - 1] < g) continue;

                    for(int k = 0; k < scores[restIndex].Length; k++)
                    {
                        if (score + scores[restIndex][k] >= g)
                        {
                            cnt += k + 1;
                            break;
                        }
                    }
                }

                if(cnt< resultCnt)
                {
                    resultCnt = cnt;
                }
            }

            Console.WriteLine(resultCnt);
        }
    }
}