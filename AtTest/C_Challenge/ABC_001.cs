using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.C_Challenge
{
    class ABC_001
    {
        static void ain(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int deg = (int.Parse(input[0]) * 10 + 1125) % 36000;
            int dis = int.Parse(input[1]) * 100;//100倍して考える

            int degGrid = 2250;
            int windGrade = deg / degGrid;

            int windPow = dis / 60;
            if (windPow % 10 >= 5)//四捨五入
            {
                windPow += 10;
            }
            windPow /= 10;
            windPow *= 10;

            string[] windNames = new string[16] {"N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE",
            "S","SSW","SW","WSW","W","WNW","NW","NNW"};
            int[] masks = new int[12] { 20, 150, 330, 540, 790, 1070, 1380, 1710, 2070, 2440, 2840, 3260 };

            int windLevel = 0;
            for(int i = 0; i <= masks.Length; i++)
            {
                if (i == masks.Length||windPow <= masks[i])
                {
                    windLevel = i;
                    break;
                }
            }

            string degName = windNames[windGrade];
            if (windLevel == 0)
            {
                degName = "C";
            }

            Console.WriteLine(degName + " " + windLevel.ToString());
        }
    }
}
