using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.BigInteger
{
    /// <summary>
    /// 100 digits integer
    /// </summary>
    struct Int100 : IComparable<Int100>
    {
        const int length = 100;

        bool minus;
        int[] value;

        public Int100(decimal initValue = 0)
        {
            value = new int[length];
            minus = initValue < 0;
            initValue = Abs(initValue);
            for (int i = 0; i < length && initValue > 0; i++)
            {
                value[i] = (int)(initValue % 10);
                initValue /= 10;
            }
        }

        public Int100(int maxDigit, string str)
        {
            value = new int[maxDigit];
            minus = str[0] == '-';
            int valueLength = Min(maxDigit,
                minus ? str.Length - 1 : str.Length);
            for (int i = 0; i < valueLength; i++)
            {
                value[i] = str[str.Length - 1 - i] - '0';
            }
        }

        public int this[int i]
        {
            set { this.value[i] = value; }
            get { return value[i]; }
        }

        public static Int100 operator +(Int100 x, Int100 y)
        {
            Int100 result = new Int100();
            if (x.AbsCompareTo(y) == 1)
            {

            }
            else
            {

            }
            for (int i = 0; i < length; i++)
            {
                int xNow = x.minus ? -x[i] : x[i];
                int yNow = y.minus ? -y[i] : y[i];
                result[i] = xNow + yNow;
                if(i+1<length)result[i+1] = result[i] / 10;
                result[i] %= 10;
            }
            return result;
        }
        /*
        public static BigInteger operator -(BigInteger x, BigInteger y)
        {
            for (int i = 0; i < y.Length; i++)
            {
                y[i] *= -1;
            }
            BigInteger result = x + y;
            for (int i = 0; i < y.Length; i++)
            {
                y[i] *= -1;
            }
            return result;
        }

        public static BigInteger operator *(BigInteger x, BigInteger y)
        {
            int maxDigit = Max(x.Length, y.Length);
            BigInteger result = new BigInteger(maxDigit);
            for (int i = 0; i < x.Length; i++)
            {
                int remain = 0;
                for (int j = 0; j < y.Length; j++)
                {
                    if (i + j >= maxDigit) break;

                    result[i + j] += remain + x[i] * y[j];
                    remain = result[i + j] / 10;
                    result[i + j] %= 10;
                }
                for (int j = i + y.Length; j < maxDigit; j++)
                {
                    result[j] += remain;
                    remain = result[j] / 10;
                    result[j] %= 10;
                }
            }
            return result;
        }

        public static BigInteger operator /(BigInteger x, BigInteger y)
        {
            if (y.CompareTo(new BigInteger(1)) == 0) return x;
            if (x.CompareTo(y) == -1) return new BigInteger(x.Length, 0);

            int xDigit = 0;
            bool xMinus = false;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 0) continue;

                xMinus = x[i] < 0;
                xDigit = i;
                x[i] = Abs(x[i]);
            }
            int yDigit = 0;
            bool yMinus = false;
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] == 0) continue;

                yMinus = y[i] < 0;
                yDigit = i;
                y[i] = Abs(y[i]);
            }
            bool minus = xMinus ^ yMinus;
            BigInteger yy = new BigInteger(x.Length);
            int shiftCount = xDigit - yDigit;
            for (int i = 0; i <= yDigit; i++)
            {
                yy[i + shiftCount] = y[i];
            }
            BigInteger result = new BigInteger(x.Length);
            while (x.CompareTo(y) >= 0)
            {
                while (x.CompareTo(yy) >= 0)
                {
                    x -= yy;
                    result[shiftCount]++;
                }
                if (minus) result[shiftCount] *= -1;
                shiftCount--;
                for (int i = 1; i < yy.Length; i++) yy[i - 1] = yy[i];
            }
            return result;
        }
        */
        public int CompareTo(Int100 another)
        {
            for (int i = length - 1; i >= 0; i--)
            {
                int a = minus ? -value[i] : value[i];
                int b = another.minus ? -another.value[i] : another.value[i];
                if (value[i] < another[i]) return -1;
                if (value[i] > another[i]) return 1;
            }
            return 0;
        }

        public override string ToString()
        {
            List<char> result = new List<char>();
            for (int i = length - 1; i >= 0; i--)
            {
                if (i > 0 && value[i] == 0 && result.Count == 0)
                {
                    continue;
                }
                result.Add((char)(Abs(value[i]) + '0'));
            }
            if (minus) result.Insert(0, '-');
            return new string(result.ToArray());
        }

        int AbsCompareTo(Int100 another)
        {
            for(int i = length - 1; i >= 0; i--)
            {
                if (value[i] < another.value[i]) return -1;
                if (value[i] > another.value[i]) return 1;
            }
            return 0;
        }
    }
}
