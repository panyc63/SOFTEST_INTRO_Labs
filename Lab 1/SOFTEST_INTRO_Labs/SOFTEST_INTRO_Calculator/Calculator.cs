namespace SOFTEST_INTRO_Calculator;

public class Calculator
{
    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.", nameof(b));
        }
        return a / b;
    }

    public long Factorial(int n)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Input must be between 0 and 20.");
        }

        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    public double DoOperation(double a, double b, string op)
    {
        return op switch
        {
            "a" => Add(a, b),
            "s" => Subtract(a, b),
            "m" => Multiply(a, b),
            "d" => Divide(a, b),
            "f" => Factorial((int)a),
            _ => throw new ArgumentException("Unknown operation.")
        };
    }

    public double TriangleArea(double height, double width)
    {
        if (double.IsNaN(height) || double.IsInfinity(height) ||
            double.IsNaN(width) || double.IsInfinity(width))
        {
            throw new ArgumentException("Inputs must be finite numbers.");
        }

        if (height < 0) throw new ArgumentOutOfRangeException(nameof(height), "Height cannot be negative.");
        if (width < 0) throw new ArgumentOutOfRangeException(nameof(width), "Width cannot be negative.");

        return 0.5 * height * width;
    }

    public double CircleArea(double radius)
    {
        if (double.IsNaN(radius) || double.IsInfinity(radius))
        {
            throw new ArgumentException("Radius must be a finite number.");
        }

        if (radius < 0) throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be negative.");

        return Math.PI * radius * radius;
    }

    public long UnknownFunctionA(int n, int r)
    {
        ValidateInputs(n, r);
        return Factorial(n) / Factorial(n - r);
    }

    public long UnknownFunctionB(int n, int r)
    {
        ValidateInputs(n, r);
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    private void ValidateInputs(int n, int r)
    {
        if (r < 0 || n < 0 || n > 20 || r > n)
        {
            throw new ArgumentOutOfRangeException($"Inputs must satisfy 0 <= r <= n <= 20. Received n={n}, r={r}.");
        }
    }
}