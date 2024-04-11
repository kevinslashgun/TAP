using FractionClass;

namespace TestFractionClass
{
    [TestFixture]
    public class Tests
    {
        private Fraction _fraction = null!;

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, 2, 1, 2)]
        [TestCase(2, 1, 2, 1)]
        [TestCase(2, 3, 2, 3)]
        [TestCase(3, 2, 3, 2)]
        [TestCase(5, 7, 5, 7)]
        [TestCase(7, 5, 7, 5)]
        public void TestConstructorWithNormalFormFraction(int numerator, int denominator, int expectedNumerator,
            int expectedDenominator)
        {
            _fraction = new Fraction(numerator, denominator);

            Assert.Multiple((() =>
            {
                Assert.That(_fraction.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(_fraction.Denominator, Is.EqualTo(expectedDenominator));
            }));
        }

        [TestCase(2, 4, 1, 2)]
        [TestCase(4, 8, 1, 2)]
        [TestCase(9, 3, 3, 1)]
        [TestCase(3, 9, 1, 3)]
        [TestCase(1071, 462, 51, 22)]
        public void TestConstructorWithNotNormalFormFraction(int numerator, int denominator, int expectedNumerator,
            int expectedDenominator)
        {
            _fraction = new Fraction(numerator, denominator);

            Assert.Multiple((() =>
            {
                Assert.That(_fraction.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(_fraction.Denominator, Is.EqualTo(expectedDenominator));
            }));
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        public void TestConstructorWithInvalidInput(int numerator, int denominator)
        {
            Assert.That(() => new Fraction(numerator, denominator), Throws.TypeOf<ArgumentException>());
        }
    }
}