using FractionClass;

namespace TestFractionClass;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    private Fraction _fraction = null!;
    private Fraction _fraction2 = null!;

    [TestCase(1, 2, 1, 2)]
    [TestCase(2, 1, 2, 1)]
    [TestCase(2, 3, 2, 3)]
    [TestCase(3, 2, 3, 2)]
    [TestCase(5, 7, 5, 7)]
    [TestCase(7, 5, 7, 5)]
    [TestCase(-1, 2, -1, 2)]
    [TestCase(-2, 1, -2, 1)]
    [TestCase(0, 1, 0, 1)]
    [TestCase(1, -2, -1, 2)]
    [TestCase(1, -1, -1, 1)]
    public void TestConstructorWithNormalFormFraction(int numerator, int denominator, int expectedNumerator,
        int expectedDenominator)
    {
        _fraction = new Fraction(numerator, denominator);

        Assert.Multiple(() =>
        {
            Assert.That(_fraction.Numerator, Is.EqualTo(expectedNumerator));
            Assert.That(_fraction.Denominator, Is.EqualTo(expectedDenominator));
        });
    }

    [TestCase(2, 4, 1, 2)]
    [TestCase(4, 8, 1, 2)]
    [TestCase(9, 3, 3, 1)]
    [TestCase(3, 9, 1, 3)]
    [TestCase(1071, 462, 51, 22)]
    [TestCase(-1071, 462, -51, 22)]
    [TestCase(0, 10, 0, 1)]
    [TestCase(1071, -462, -51, 22)]
    public void TestConstructorWithNotNormalFormFraction(int numerator, int denominator, int expectedNumerator,
        int expectedDenominator)
    {
        _fraction = new Fraction(numerator, denominator);

        Assert.Multiple(() =>
        {
            Assert.That(_fraction.Numerator, Is.EqualTo(expectedNumerator));
            Assert.That(_fraction.Denominator, Is.EqualTo(expectedDenominator));
        });
    }

    [Test]
    public void TestConstructorWithInvalidDenominator()
    {
        Assert.That(() => new Fraction(1, 0), Throws.TypeOf<ArgumentException>());
    }

    [TestCase(1, 1, 1, 1, 2, 1)]
    [TestCase(1, 2, 1, 2, 1, 1)]
    [TestCase(-1, 1, -1, 1, -2, 1)]
    [TestCase(-4, 14, -21, 16, -179, 112)]
    [TestCase(1, 3, 1, 4, 7, 12)]
    [TestCase(-1, 2, -1, 3, -5, 6)]
    [TestCase(3, 5, 2, 5, 1, 1)]
    [TestCase(0, 1, 1, 2, 1, 2)]
    [TestCase(1, 1, 2, 1, 3, 1)]
    [TestCase(1, 3, -1, 3, 0, 1)]
    [TestCase(1, 2, 2, 5, 9, 10)]
    public void TestPlusOperator(int n1, int d1, int n2, int d2, int expectedN, int expectedD)
    {
        _fraction = new Fraction(n1, d1);
        _fraction2 = new Fraction(n2, d2);
        var retFraction = _fraction + _fraction2;

        Assert.Multiple(() =>
        {
            Assert.That(retFraction.Numerator, Is.EqualTo(expectedN));
            Assert.That(retFraction.Denominator, Is.EqualTo(expectedD));
        });
    }

    [TestCase(3, 4, 1, 4, 1, 2)]
    [TestCase(5, 6, 1, 3, 1, 2)]
    [TestCase(-1, 2, -1, 3, -1, 6)]
    [TestCase(5, 4, 1, 4, 1, 1)]
    [TestCase(1, 4, 5, 4, -1, 1)]
    [TestCase(0, 1, 1, 2, -1, 2)]
    [TestCase(0, 1, -2, 3, 2, 3)]
    [TestCase(1, 3, 1, 3, 0, 1)]
    [TestCase(4, 1, 33, 7, -5, 7)]
    public void TestMinusOperator(int n1, int d1, int n2, int d2, int expectedN, int expectedD)
    {
        _fraction = new Fraction(n1, d1);
        _fraction2 = new Fraction(n2, d2);
        var retFraction = _fraction - _fraction2;

        Assert.Multiple(() =>
        {
            Assert.That(retFraction.Numerator, Is.EqualTo(expectedN));
            Assert.That(retFraction.Denominator, Is.EqualTo(expectedD));
        });
    }

    [TestCase(3, 4, 1, 4, 3, 16)]
    [TestCase(5, 6, 1, 3, 5, 18)]
    [TestCase(-1, 2, -1, 3, 1, 6)]
    [TestCase(5, 4, 1, 4, 5, 16)]
    [TestCase(1, 4, 5, 4, 5, 16)]
    [TestCase(0, 1, 1, 2, 0, 1)]
    [TestCase(0, 1, -2, 3, 0, 1)]
    [TestCase(1, 3, 1, 3, 1, 9)]
    [TestCase(1, 11, 11, 1, 1, 1)]
    [TestCase(42, 1, 0, 1, 0, 1)]
    public void TestMultiplicationOperator(int n1, int d1, int n2, int d2, int expectedN, int expectedD)
    {
        _fraction = new Fraction(n1, d1);
        _fraction2 = new Fraction(n2, d2);
        var retFraction = _fraction * _fraction2;

        Assert.Multiple(() =>
        {
            Assert.That(retFraction.Numerator, Is.EqualTo(expectedN));
            Assert.That(retFraction.Denominator, Is.EqualTo(expectedD));
        });
    }

    [Test]
    public void TestDivisionOperatorWithInvalidInput()
    {
        Assert.That(() => new Fraction(1, 1) / new Fraction(0, 1), Throws.TypeOf<DivideByZeroException>());
    }

    [TestCase(3, 4, 1, 4, 3, 1)]
    [TestCase(5, 6, 1, 3, 5, 2)]
    [TestCase(-1, 2, -1, 3, 3, 2)]
    [TestCase(5, 4, 1, 4, 5, 1)]
    [TestCase(1, 4, 5, 4, 1, 5)]
    [TestCase(0, 1, 1, 2, 0, 1)]
    [TestCase(0, 1, -2, 3, 0, 1)]
    [TestCase(1, 3, 1, 3, 1, 1)]
    [TestCase(33, 42, 111, 8, 44, 777)]
    public void TestDivisionOperator(int n1, int d1, int n2, int d2, int expectedN, int expectedD)
    {
        _fraction = new Fraction(n1, d1);
        _fraction2 = new Fraction(n2, d2);
        var retFraction = _fraction / _fraction2;

        Assert.Multiple(() =>
        {
            Assert.That(retFraction.Numerator, Is.EqualTo(expectedN));
            Assert.That(retFraction.Denominator, Is.EqualTo(expectedD));
        });
    }

    [TestCase(1, 5, "1/5")]
    [TestCase(5, 1, "5")]
    [TestCase(-1, 3, "-1/3")]
    [TestCase(-7, 1, "-7")]
    [TestCase(0, 1, "0")]
    [TestCase(0, 10, "0")]
    [TestCase(11, 5, "11/5")]
    [TestCase(22, 11, "2")]
    [TestCase(22, -11, "-2")]
    public void TestToString(int numerator, int denominator, string expectedString)
    {
        Assert.That(() => new Fraction(numerator, denominator).ToString(), Is.EqualTo(expectedString));
    }

    [TestCase(1, 2, 2, 4, true)]
    [TestCase(1, 2, 1, 3, false)]
    [TestCase(-2, 1, -8, 4, true)]
    [TestCase(-1, 7, -2, 5, false)]
    [TestCase(0, 1, 0, 1, true)]
    [TestCase(0, 1, 0, 22, true)]
    [TestCase(1, 2, 2, 4, true)]
    public void TestEqualsNotNull(int n1, int d1, int n2, int d2, bool expectedBool)
    {
        Assert.That(() => new Fraction(n1, d1).Equals(new Fraction(n2, d2)), Is.EqualTo(expectedBool));
    }

    [Test]
    public void TestEqualsWithNullFraction()
    {
        Assert.That(() => new Fraction(1, 1).Equals(null), Is.EqualTo(false));
    }

    [Test]
    public void TestEqualsWithSameObj()
    {
        Assert.That(() =>
        {
            var fraction = new Fraction(1, 1);
            // ReSharper disable once EqualExpressionComparison
            return fraction.Equals(fraction); // Dumb test
        }, Is.EqualTo(true));
    }

    [TestCase(2, 3)]
    [TestCase(3, 2)]
    [TestCase(-2, 5)]
    [TestCase(-5, 2)]
    [TestCase(0, 1)]
    [TestCase(-11, 1)]
    [TestCase(13, 1)]
    public void TestGetHashCode(int numerator, int denominator)
    {
        Assert.That(() => new Fraction(numerator, denominator).GetHashCode(),
            Is.EqualTo((numerator, denominator).GetHashCode()));
    }

    [TestCase(5)]
    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(42)]
    public void TestImplicitCastFromIntToFraction(int toCast)
    {
        Assert.That(() =>
        {
            Fraction fraction = toCast;
            return fraction;
        }, Is.InstanceOf<Fraction>());
    }

    [TestCase(5, 1, 5)]
    [TestCase(1, 1, 1)]
    [TestCase(-7, 1, -7)]
    [TestCase(0, 1, 0)]
    [TestCase(42, 1, 42)]
    public void TestValidExplicitCastFromFractionToInt(int numerator, int denominator, int expectedInt)
    {
        Assert.That(() => (int)new Fraction(numerator, denominator), Is.EqualTo(expectedInt));
    }

    [Test]
    public void TestInvalidExplicitCastFromFractionToInt()
    {
        Assert.That(() => (int)new Fraction(1, 2), Throws.TypeOf<InvalidOperationException>());
    }
}