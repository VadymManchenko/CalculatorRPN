using Calculator.Methods;

namespace Calculator;

static class Program
{
    static void Main()
    {
        string infixExpression = "2 + 12 * 3";
        ExpressionParser parser = new ExpressionParser();
        string rpnExpression = parser.ToReversePolishNotation(infixExpression);
        Console.WriteLine($"RPN: {rpnExpression}");
    }
}

