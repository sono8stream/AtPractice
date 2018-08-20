using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class ABC_075_B_GridSearch
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            int[,] array = new int[h, w];

            for (int i = 0; i < h; i++)
            {
                string input2 = Console.ReadLine();
                for (int j = 0; j < w; j++)
                {
                    if (input2[j] == '.')
                    {
                        array[i, j] = 0;
                    }
                    else
                    {
                        array[i, j] = -1;
                    }
                }
            }

            for (int y = 0; y < h; y++)
            {
                string s = "";
                for (int x = 0; x < w; x++)
                {
                    if (array[y, x] == 0)
                    {
                        array[y, x] = CheckBomb(x, y, w, h, array);
                    }
                    if (array[y, x] == -1)
                    {
                        s += "#";
                    }
                    else
                    {
                        s += array[y, x].ToString();
                    }
                }
                Console.WriteLine(s);
            }
        }

        static int CheckBomb(int x, int y, int w, int h, int[,] array)
        {
            int cnt = 0;
            for (int nY = y - 1; nY <= y + 1; nY++)
            {
                for (int nX = x - 1; nX <= x + 1; nX++)
                {
                    if (nY < 0 || h <= nY
                        || nX < 0 || w <= nX
                        || (nX == x && nY == y)) continue;
                    if (array[nY, nX] == -1) cnt++;
                }
            }
            return cnt;
        }
    }
}