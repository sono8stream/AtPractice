using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static System.Math;

namespace AtTest.Library.BigInteger
{

    struct BigInteger : IComparable<BigInteger>
    {
        int[] value;
        public int Length { get { return value.Length; } }

        public BigInteger(int maxDigit)
        {
            value = new int[maxDigit];
        }

        public BigInteger(int maxDigit, decimal initValue)
        {
            value = new int[maxDigit];
            bool minus = initValue < 0;
            initValue = Abs(initValue);
            for (int i = 0; i < maxDigit; i++)
            {
                value[i] = (int)(initValue % 10);
                if (minus) value[i] *= -1;
                initValue /= 10;
            }
        }

        public BigInteger(int maxDigit, string str)
        {
            value = new int[maxDigit];
            bool minus = str[0] == '-';
            int valueLength = Min(maxDigit,
                minus ? str.Length - 1 : str.Length);
            for (int i = 0; i < valueLength; i++)
            {
                value[i] = str[str.Length - 1 - i] - '0';
                if (minus) value[i] *= -1;
            }
        }

        public int this[int i]
        {
            set { this.value[i] = value; }
            get { return value[i]; }
        }

        public static BigInteger operator +(BigInteger x, BigInteger y)
        {
            int maxDigit = Max(x.Length, y.Length);
            BigInteger result = new BigInteger(maxDigit);
            int remain = 0;
            for (int i = 0; i < maxDigit; i++)
            {
                result[i] = remain;
                if (i < x.Length) result[i] += x[i];
                if (i < y.Length) result[i] += y[i];
                remain = result[i] / 10;
                result[i] %= 10;
            }
            for (int i = maxDigit - 1; i > 0; i--)
            {
                if (result[i] * result[i - 1] >= 0) continue;

                if (result[i] > 0)
                {

                }
                else
                {

                }
            }
            return result;
        }

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

        public int CompareTo(BigInteger another)
        {
            if (Length > another.Length)
            {
                for (int i = Length - 1; i >= another.Length; i--)
                {
                    if (value[i] != 0)
                    {
                        if (value[i] < 0) return -1;
                        if (value[i] > 0) return 1;
                    }
                }
            }
            if (another.Length > Length)
            {
                for (int i = another.Length - 1; i >= Length; i--)
                {
                    if (another[i] > 0)
                    {
                        if (another[i] < 0) return 1;
                        if (another[i] > 0) return -1;
                    }
                }
            }
            for (int i = Min(Length, another.Length) - 1; i >= 0; i--)
            {
                if (value[i] > another[i]) return 1;
                if (value[i] < another[i]) return -1;
            }
            return 0;
        }

        public override string ToString()
        {
            List<char> result = new List<char>();
            for (int i = Length - 1; i >= 0; i--)
            {
                if (i > 0 && value[i] == 0 && result.Count == 0)
                {
                    continue;
                }
                if (value[i] < 0 && result.Count == 0) result.Add('-');

                result.Add((char)(Abs(value[i]) + '0'));
            }
            return new string(result.ToArray());
        }
    }
}
