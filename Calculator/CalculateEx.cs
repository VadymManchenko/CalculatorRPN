using System.Text;
using Calculator.Methods;

namespace Calculator;

public static class CalculateEx
{
    public static double CalculateExpression(string ex)
    {
        Stack<double> stack = new Stack<double>();
        StringBuilder number = new StringBuilder();
        foreach (char symbol in ex)
        {
            if (symbol == '|')
            {
                if (number.Length > 0)
                {
                    stack.Push(double.Parse(number.ToString()));
                    number.Clear();
                }
                continue;
            }

            if (char.IsDigit(symbol) || symbol == ',')
            {
                number.Append(symbol);
                continue;
            }
            
            double operand2 = stack.Pop();
            double operand1 = stack.Pop();
            double res = PerformOperation(operand1, operand2, symbol);
            stack.Push(res);
        }

        return stack.Pop();
    }
    
    private static readonly Dictionary<char, Func<double, double, double>> Operations = new()
    {
        { '+', (x, y) => x + y },
        { '-', (x, y) => x - y },
        { '*', (x, y) => x * y },
        { '/', (x, y) => x / y },
        { '^', Math.Pow }
    };
    
    private static double PerformOperation(double operand1, double operand2, char op)
    {
        if (Operations.TryGetValue(op, out var operation))
        {
            return operation(operand1, operand2);
        }

        throw new ArgumentException("Невідомий оператор");
    }
}