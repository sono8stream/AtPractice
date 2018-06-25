using System;
using System.Collections.Generic;
using System.Text;

namespace AtTest.BitAll
{
    class AtTemplate
    {
        static void main(string[] args)
        {
            Method(args);
            Console.ReadLine();
        }

        static void Method(string[] args)
        {
            string input = Console.ReadLine();
            int a = input[0] - '0';
            int b = input[1] - '0';
            int c = input[2] - '0';
            int d = input[3] - '0';

            int result;
            string [] opr = new string[3];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    for (int k = 0; k < 2; k++)
                    {
                        result = 0;
                        if (i == 0)
                        {
                            result = a + b;
                            opr[0] = "+";
                        }
                        else
                        {
                            result = a - b;
                            opr[0] = "-";
                        }
                        if (j == 0)
                        {
                            result += c;
                            opr[1] = "+";
                        }
                        else
                        {
                            result -= c;
                            opr[1] = "-";
                        }
                        if (k == 0)
                        {
                            result += d;
                            opr[2] = "+";
                        }
                        else
                        {
                            result -= d;
                            opr[2] = "-";
                        }
                        if (result == 7)
                        {
                            string resultStr = input.Insert(1, opr[0]);
                            resultStr = resultStr.Insert(3, opr[1]);
                            resultStr = resultStr.Insert(5, opr[2]);
                            resultStr += "=7";
                            Console.WriteLine(resultStr);
                            return;
                        }
                    }
                }
            }
        }
    }
}
