using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest
{
    class ABC_096_C_GridSearch
    {
        static int whiteNo = 0;
        static int blackNo = -1;

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
                        array[i, j] = whiteNo;
                    }
                    else
                    {
                        array[i, j] = blackNo;
                    }
                }
            }

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    if (array[y, x] != blackNo) continue;
                    if (!CanWrite(x, y, w, h, array))
                    {
                        Console.WriteLine("No");
                        return;
                    }
                }
            }
            Console.WriteLine("Yes");
        }
        //十字探索
        static bool CanWrite(int x, int y, int w, int h, int[,] array)
        {
            for (int nY = y - 1; nY <= y + 1; nY += 2)
            {
                if (nY < 0 || h <= nY) continue;
                if (array[nY, x] == blackNo) return true;

            }
            for (int nX = x - 1; nX <= x + 1; nX += 2)
            {
                if (nX < 0 || w <= nX) continue;
                if (array[y, nX] == blackNo) return true;
            }
            return false;
        }
    }
}