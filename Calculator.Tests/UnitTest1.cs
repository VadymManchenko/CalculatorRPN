using System.Linq.Expressions;
using Calculator.Interfaces;
using Calculator.Methods;

namespace Calculator.Tests;

public class UnitTest1
{
    private static readonly IExpressionParser _expressionParser = new ExpressionParser();
    
    [Theory]
    [InlineData("2 + 3", 5)]
    [InlineData("2 + 12 * 3", 38)]
    [InlineData("12 * 3 + 2", 38)]
    [InlineData("( ( 9 - 3 ) ^ 3 - 6 ) / 3 - 1", 69)]
    [InlineData("34 * 10 - 340", 0)]
    [InlineData("5 * 12 / 6", 10)]
    [InlineData("( 9 / 6 + 3 ) * 2", 9)]
    [InlineData("7,3 + 2,7", 10)]
    [InlineData("15,45 + 14,56", 30.01)]
    [InlineData("14,88 + 88,14", 103.02)]
    
    public void CheckInputExpressions(string expression, double expected)
    {
        //Arrange
        //var inputExpression = new ExpressionParser { };

        //Act
        var isSuccess = _expressionParser.TryParse(expression, out double actual);
        
        //Assert
        Assert.True(isSuccess);
        
        Assert.Equal(expected, actual, 4);
        
    }

    [Theory]
    [InlineData("2 + 3", "2|3|+|")]
    [InlineData("7,3 + 2,7", "7,3|2,7|+|")]
    public void CheckRPN_FractionalNumbers_ReturnsValidRPN(string expression, string rpn)
    {
        var actual = _expressionParser.ToReversePolishNotation(expression);
        
        Assert.Equal(actual, rpn);
    }
}