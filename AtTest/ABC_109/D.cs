using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.ABC_109
{
    class D
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            var coins = new int[h, w];
            long allCoins = 0;
            for (int i = 0; i < h; i++)
            {
                input = Console.ReadLine().Split(' ');
                for (int j = 0; j < w; j++)
                {
                    coins[i, j] = int.Parse(input[j]);
                    allCoins += coins[i, j];
                }
            }
            var handleList = new List<string>();
            bool isOdd = allCoins % 2 == 1;
            for (int i = 0; i < h; i++)//左から右へ
            {
                for (int j = 0; j < w; j++)//上から下へ
                {
                    if (coins[i, j] % 2 == 0) continue;

                    if (isOdd)
                    {
                        isOdd = false;
                        continue;
                    }

                    //move
                    if (i < h - 1 && coins[i + 1, j] % 2 == 1)
                    {
                        handleList.Add(string.Format("{0} {1} {2} {3}",
                            i+1, j+1, i + 2, j+1));
                        coins[i, j]--;
                        coins[i + 1, j]++;
                    }
                    else if (j < w - 1 && coins[i, j + 1] % 2 == 1)
                    {
                        handleList.Add(string.Format("{0} {1} {2} {3}",
                            i + 1, j + 1, i + 1, j + 2));
                        coins[i, j]--;
                        coins[i, j + 1]++;
                    }
                    else
                    {
                        if (i < h - 1)
                        {
                            handleList.Add(string.Format("{0} {1} {2} {3}",
                                i + 1, j + 1, i + 2, j + 1));
                            coins[i, j]--;
                            coins[i + 1, j]++;
                        }
                        else
                        {
                            handleList.Add(string.Format("{0} {1} {2} {3}",
                                i + 1, j + 1, i + 1, j + 2));
                            coins[i, j]--;
                            coins[i, j + 1]++;
                        }
                    }
                }
            }
            Console.WriteLine(handleList.Count);
            for(int i = 0; i < handleList.Count; i++)
            {
                Console.WriteLine(handleList[i]);
            }
        }
    }
}
