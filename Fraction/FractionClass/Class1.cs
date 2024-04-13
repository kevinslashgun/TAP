namespace FractionClass;

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
            if (a > b)
                a %= b;
            else
                b %= a;

        return
            a | b; // At this point one of these two is equals 0, so I will return the one that isn't zero using bitwise OR operator
    }
}

public class Fraction
{
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0) throw new ArgumentException("Denominator cannot be zero");

        var sign = denominator < 0 ? -1 : 1; // If denominator is negative, I will change sign of both numbers
        /*
         * Example:
         *  n: -1;  d: 1;   s = 1   -> n and d don't change
         *  n: 1;   d: -1   s = -1  -> n becomes negative and d becomes positive
         *  n: -1;  d: -1   s = -1  -> n and d becomes positive
         */
        var gcd = Utilities.GCD(Math.Abs(numerator), Math.Abs(denominator));

        Numerator = numerator * sign / gcd;
        Denominator = denominator * sign / gcd;
    }

    public int Numerator { get; } // Numerator can be any integer
    public int Denominator { get; } // Denominator must be a positive integer

    public static Fraction operator +(Fraction left, Fraction right)
    {
        // x1/y1+x2/y2=((x1*y2)+(x2*y1))/(y1*y2)
        return new Fraction(left.Numerator * right.Denominator + right.Numerator * left.Denominator,
            left.Denominator * right.Denominator);
    }

    public static Fraction operator -(Fraction left, Fraction right)
    {
        // x1/y1-x2/y2=((x1*y2)-(x2*y1))/(y1*y2)
        return new Fraction(left.Numerator * right.Denominator - right.Numerator * left.Denominator,
            left.Denominator * right.Denominator);
    }

    public static Fraction operator *(Fraction left, Fraction right)
    {
        // (x1/y1)*(x2/y2)=(x1*x2)/(y1*y2)
        return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
    }

    public static Fraction operator /(Fraction left, Fraction right)
    {
        // se x2<>0, (x1/y1)/(x2/y2)=(x1*y2)/(y1*x2)
        if (right.Numerator == 0) throw new DivideByZeroException("Second argument cannot be 0");

        return new Fraction(left.Numerator * right.Denominator, right.Numerator * left.Denominator);
    }

    public override string ToString()
    {
        return Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true; // If equals is called on the same object
        if (obj is not Fraction other) return false;
        return Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);
    }

#pragma warning disable IDE0070
    public override int GetHashCode()
#pragma warning restore IDE0070
    {
        return (Numerator, Denominator).GetHashCode();
    }

    public static implicit operator Fraction(int numerator)
    {
        return new Fraction(numerator, 1);
    }

    public static explicit operator int(Fraction fraction)
    {
        return fraction.Denominator == 1
            ? fraction.Numerator
            : throw new InvalidOperationException(
                $"Cannot convert to int as denominator is {fraction.Denominator}");
    }
}