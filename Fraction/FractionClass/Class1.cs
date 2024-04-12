using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace FractionClass
{
    internal class Utilities
    {
        internal static int GCD(int a, int b)
        {
            /*
             * The logic of this algorithm is to keep replacing the greatest number
             * with the remainder of the division of itself with the other one
             * until one becomes zero.
             *
             * Example:
             * a: 8;    b:6;    ->  a = a % b = 8 % 6 = 2
             * a: 2;    b:6;    ->  b = b % a = 6 % 2 = 0
             * a: 2;    b:0;    ->  return a | b = 2 | 0 = 2
             *
             * If a and b have GCD = 1, they will keep decreasing until one of them becomes 1 and the other one becomes 0
             */
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a | b; // At this point one of these two is equals 0, so I will return the one that isn't zero using bitwise OR operator
        }
    }

    public class Fraction
    {
        public int Numerator { get; } // Numerator can be any integer
        public int Denominator { get; } // Denominator must be a positive integer

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero");
            }

            var sign = denominator < 0 ? -1 : 1; // If denominator is negative, I will change sign of both numbers
            /*
             * Example:
             *  n: -1;  d: 1;   s = 1   -> n and d don't change
             *  n: 1;   d: -1   s = -1  -> n becomes negative and d becomes positive
             *  n: -1;  d: -1   s = -1  -> n and d becomes positive
             */
            var gcd = Utilities.GCD(Math.Abs(numerator), Math.Abs(denominator));

            this.Numerator = numerator * sign / gcd;
            this.Denominator = denominator * sign / gcd;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            // x1/y1+x2/y2=((x1*y2)+(x2*y1))/(y1*y2)
            return new Fraction((a.Numerator * b.Denominator) + (b.Numerator * a.Denominator),
                (a.Denominator * b.Denominator));
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            // x1/y1-x2/y2=((x1*y2)-(x2*y1))/(y1*y2)
            return new Fraction((a.Numerator * b.Denominator) - (b.Numerator * a.Denominator),
                (a.Denominator * b.Denominator));
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            // (x1/y1)*(x2/y2)=(x1*x2)/(y1*y2)
            return new Fraction((a.Numerator * b.Numerator), (a.Denominator * b.Denominator));
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            // se x2<>0, (x1/y1)/(x2/y2)=(x1*y2)/(y1*x2)
            if (b.Numerator == 0)
            {
                throw new ArgumentException("Second argument cannot be 0");
            }

            return new Fraction((a.Numerator * b.Denominator), (b.Numerator * a.Denominator));
        }

        public override string ToString()
        {
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }

            return Numerator.ToString() + "/" + Denominator.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Fraction other) return false;
            return Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);
        }

        public override int GetHashCode() => (Numerator, Denominator).GetHashCode();

        public static implicit operator Fraction(int numerator)
        {
            return new Fraction(numerator, 1);
        }

        public static explicit operator int(Fraction fraction)
        {
            if (fraction.Denominator != 1)
            {
                throw new ArgumentException("Fraction denominator must be 1");
            }

            return fraction.Numerator;
        }
    }
}