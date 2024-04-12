    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic.CompilerServices;

    namespace FractionClass
    {
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

                var sign = 1;

                if (numerator == 0) // Any fraction with numerator = 0, will have denominator = 1.
                {
                    denominator = 1;
                }
                else
                {
                    sign = (numerator * denominator) > 0 ? 1 : -1; // Keep track of the sign
                    // convert numerator and denominator to positive
                    numerator = Math.Abs(numerator);
                    denominator = Math.Abs(denominator);
                    Normalize(ref numerator, ref denominator);
                }

                this.Numerator = numerator * sign;
                this.Denominator = denominator;
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

        private static void Normalize(ref int numerator, ref int denominator)
            {
                var gcd = CalculateGcd(numerator, denominator);
                while (gcd != 1)
                {
                    numerator /= gcd;
                    denominator /= gcd;
                    gcd = CalculateGcd(numerator, denominator);
                }
            }

            private static int CalculateGcd(int numerator, int denominator) // I know for sure that both arguments are positive
            {
                /*
                 * Euclidean algorithm
                 * a = Max(numerator, denominator)
                 * b = what's left
                 * find quotient and remainder so that:
                 *  a = quotient * b + remainder
                 * if remainder = 0 then b is the GCD
                 */

                var a = Math.Max(numerator, denominator);
                var b = Math.Min(numerator, denominator);
                var remainder = -1;

                while (remainder != 0)
                {
                    var quotient = a / b; // Instead of looping until I find the correct quotient, I can just divide and keep the integer
                    remainder = a - (quotient * b);
                    // If remainder != 0 then I have to repeat with the next pair of number (b, remainder)
                    a = b;
                    b = remainder!;
                }

                return a;
            }

        }
    }
