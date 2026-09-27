using SOFTEST_INTRO_Calculator;
using NUnit.Framework;
namespace SOFTEST_INTRO_Calculator.UnitTests;
public class CalculatorTests
{
    private Calculator _calculator = null!;
    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange: the calculator is created in SetUp.
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(
    double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(15, 0)]
    [TestCase(0, 0)]
    [TestCase(-5, 0)]
    public void Divide_ZeroDivisor(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b),
            Throws.TypeOf<ArgumentException>());
    }

    [TestCase(10, 2, 5)]
    [TestCase(0, 15, 0)]
    [TestCase(15, -3, -5)]
    public void Divide_ValidInputs(double a, double b, double expected)
    {
        double result = _calculator.Divide(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(0, 1L)]
    [TestCase(1, 1L)]
    [TestCase(5, 120L)]
    [TestCase(20, 2432902008176640000L)]
    public void Factorial_ValidInputs(int n, long expected)
    {
        long result = _calculator.Factorial(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-1)]
    [TestCase(21)]
    public void Factorial_InvalidInputs(int n)
    {
        Assert.That(() => _calculator.Factorial(n),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(3, 4, 6.0)]
    [TestCase(0, 5, 0.0)]
    [TestCase(5, 0, 0.0)]
    [TestCase(0, 0, 0.0)]
    public void TriangleArea_ValidInputs(double height, double width, double expected)
    {
        double result = _calculator.TriangleArea(height, width);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 5)]
    [TestCase(5, -1)]
    [TestCase(-3, -4)]
    public void TriangleArea_NegativeInputs(double height, double width)
    {
        Assert.That(() => _calculator.TriangleArea(height, width),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(1, Math.PI)]
    [TestCase(0, 0.0)]
    [TestCase(2.5, Math.PI * 6.25)]
    public void CircleArea_ValidRadius(double radius, double expected)
    {
        double result = _calculator.CircleArea(radius);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [Test]
    public void CircleArea_NegativeRadius()
    {
        Assert.That(() => _calculator.CircleArea(-1),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    
    [TestCase(5, 5, 120L)]
    [TestCase(5, 4, 120L)]
    [TestCase(5, 3, 60L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    [TestCase(4, 2, 12L)] 
    public void UnknownFunctionA_ValidInputs(int n, int r, long expected)
    {
        Assert.That(_calculator.UnknownFunctionA(n, r), Is.EqualTo(expected));
    }

    [TestCase(5, 5, 1L)]
    [TestCase(5, 4, 5L)]
    [TestCase(5, 3, 10L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    [TestCase(4, 2, 6L)] 
    public void UnknownFunctionB_ValidInputs(int n, int r, long expected)
    {
        Assert.That(_calculator.UnknownFunctionB(n, r), Is.EqualTo(expected));
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    [TestCase(21, 5)]
    [TestCase(5, -1)]
    public void UnknownFunctions_InvalidInputs(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionA(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
        Assert.That(() => _calculator.UnknownFunctionB(n, r), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

}