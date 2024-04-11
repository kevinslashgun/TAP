    using System.Runtime.InteropServices;

    namespace FractionClass
    {
        public class Fraction
        {
            public int Numerator { get; } // Numerator can be any integer
            public int Denominator { get; } // Denominator must be a positive integer

            public Fraction(int numerator, int denominator)
            {
                if (denominator <= 0)
                {
                    throw new ArgumentException("Denominator must be positive");

                }

                var gcd = CalculateGcd(numerator, denominator);
                while (gcd != 1)
                {
                    numerator /= gcd;
                    denominator /= gcd;
                    gcd = CalculateGcd(numerator, denominator);
                }

                this.Numerator = numerator;
                this.Denominator = denominator;
            }

            private static int CalculateGcd(int numerator, int denominator)
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
                    int quotient = a / b; // Instead of looping until I find the correct quotient, I can just divide and keep the integer
                    remainder = a - (quotient * b);
                    a = b; // To keep looking for the GCD on the next numbers which are b and the remainder
                    b = remainder!;
                }

                return a;
            }
        }
    }
