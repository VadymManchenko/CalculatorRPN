using System.Linq.Expressions;

namespace Calculator.Interfaces;

public interface IExpressionParser
{
    bool TryParse(ReadOnlySpan<char> expression, out double result);

    double Parse(ReadOnlySpan<char> expression)
    {
        if (TryParse(expression, out double result))
            return result;

        throw new Exception();
    }

    string ToReversePolishNotation(ReadOnlySpan<char> expression);
}