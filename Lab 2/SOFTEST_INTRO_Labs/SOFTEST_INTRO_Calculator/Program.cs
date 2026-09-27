using System.Globalization;
using SOFTEST_INTRO_Calculator;

var calculator = new Calculator();

Console.WriteLine("Calculator operations:");
Console.WriteLine("  a  = add");
Console.WriteLine("  s  = subtract");
Console.WriteLine("  m  = multiply");
Console.WriteLine("  d  = divide");
Console.WriteLine("  f  = factorial");
Console.WriteLine("  t  = triangle area");
Console.WriteLine("  c  = circle area");
Console.WriteLine("  pa = permutations (Function A: nPr)");
Console.WriteLine("  cb = combinations (Function B: nCr)");
Console.WriteLine("-----------------------------------");

Console.Write("Operation: ");
string op = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

try
{
    double result = 0;

    switch (op)
    {
        // Two-operand standard arithmetic & triangle area
        case "a":
        case "s":
        case "m":
        case "d":
        case "t":
            {
                double a = ReadFiniteDouble("First number (or height): ");
                double b = ReadFiniteDouble("Second number (or width): ");

                result = op switch
                {
                    "a" => calculator.Add(a, b),
                    "s" => calculator.Subtract(a, b),
                    "m" => calculator.Multiply(a, b),
                    "d" => calculator.Divide(a, b),
                    "t" => calculator.TriangleArea(a, b),
                    _ => throw new ArgumentException("Unknown operation.")
                };
                break;
            }

        case "f":
            {
                double val = ReadFiniteDouble("Enter integer (0 to 20): ");
                result = calculator.DoOperation(val, 0, "f");
                break;
            }

        case "c":
            {
                double radius = ReadFiniteDouble("Enter radius: ");
                result = calculator.CircleArea(radius);
                break;
            }

        case "pa":
        case "cb":
            {
                int n = ReadInteger("Enter n (0 to 20): ");
                int r = ReadInteger("Enter r (0 to n): ");

                result = op switch
                {
                    "pa" => calculator.UnknownFunctionA(n, r),
                    "cb" => calculator.UnknownFunctionB(n, r),
                    _ => throw new ArgumentException("Unknown operation.")
                };
                break;
            }

        default:
            Console.WriteLine("Unknown operation selected.");
            return;
    }

    string text = result.ToString(CultureInfo.InvariantCulture);
    Console.WriteLine("Result: " + text);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Range Error: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

static double ReadFiniteDouble(string prompt)
{
    Console.Write(prompt);
    string input = Console.ReadLine() ?? "";
    if (!double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double val) || !double.IsFinite(val))
    {
        throw new ArgumentException("Invalid input. Must be a finite number using '.' for decimals.");
    }
    return val;
}

static int ReadInteger(string prompt)
{
    Console.Write(prompt);
    string input = Console.ReadLine() ?? "";
    if (!int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int val))
    {
        throw new ArgumentException("Invalid input. Must be a whole integer.");
    }
    return val;
}