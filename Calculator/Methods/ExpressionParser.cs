using System.Text;
using Calculator.Constants;
using Calculator.Interfaces;

namespace Calculator.Methods;

public class ExpressionParser : IExpressionParser
{
    private static readonly Dictionary<char, int> OperatorPriorities = new()
    {
        { '+', Operators.Add },
        { '-', Operators.Subtruct },
        { '*', Operators.Multiply },
        { '/', Operators.Divide },
        { '^', Operators.Power },
    };

    public string ToReversePolishNotation(ReadOnlySpan<char> expression)
    {
        StringBuilder resultExpression = new StringBuilder();
        Stack<char> symbols = new Stack<char>();
        string[] tokens = expression.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double res))
            {
                resultExpression.Append(res).Append('|');
            }

            foreach (var symbol in token.Where(symbol => !char.IsDigit(symbol)))
            {
                if (IsOperator(symbol))
                {
                    ProcessOperator(symbol, symbols, resultExpression);
                }
                else if (symbol is '(')
                {
                    symbols.Push(symbol);
                }
                else if (symbol is ')')
                {
                    ProcessClothingParenthesis(symbols, resultExpression);
                }
            }
        }
        
        while (symbols.Count > 0)
        {
            resultExpression.Append(symbols.Pop()).Append('|');
        }

        return resultExpression.ToString();
    }

    private static bool IsOperator(char symbol)
    {
        return symbol is '+'
            or '-'
            or '*'
            or '/'
            or '^';
    }

    private static int GetOperatorPriority(char op)
    {
        return OperatorPriorities.GetValueOrDefault(op, 0);
    }

    private static void ProcessOperator(char symbol, Stack<char> symbols, StringBuilder sb)
    {
        while (symbols.Count > 0 && GetOperatorPriority(symbols.Peek()) >= GetOperatorPriority(symbol))
        {
            sb.Append(symbols.Pop());
        }

        symbols.Push(symbol);
    }

    private static void ProcessClothingParenthesis(Stack<char> symbols, StringBuilder sb)
    {
        while (symbols.Count > 0 && symbols.Peek() != '(')
        {
            sb.Append(symbols.Pop());
        }
        
        symbols.Pop();
    }

    public bool TryParse(ReadOnlySpan<char> expression, out double result)
    {
        string rpn = ToReversePolishNotation(expression);
        result = CalculateEx.CalculateExpression(rpn);
        return true;
    }

    public double Parse(ReadOnlySpan<char> expression)
    {
        throw new Exception();
    }
}