using System;

public class Calculator<T>
{
    public Func<T, T, T> Add { get; set; }
    public Func<T, T, T> Subtract { get; set; }
    public Func<T, T, T> Multiply { get; set; }
    public Func<T, T, T> Divide { get; set; }

    public Calculator()
    {
        // Ініціалізуємо делегати для арифметичних операцій.
        Add = (a, b) => (dynamic)a + (dynamic)b;
        Subtract = (a, b) => (dynamic)a - (dynamic)b;
        Multiply = (a, b) => (dynamic)a * (dynamic)b;
        Divide = (a, b) => (dynamic)a / (dynamic)b;
    }

    public T PerformOperation(T a, T b, Func<T, T, T> operation)
    {
        return operation(a, b);
    }
}

class Program
{
    static void Main()
    {
        Calculator<int> intCalculator = new Calculator<int>();
        int resultInt = intCalculator.PerformOperation(5, 3, intCalculator.Add);
        Console.WriteLine($"5 + 3 = {resultInt}");

        Calculator<double> doubleCalculator = new Calculator<double>();
        double resultDouble = doubleCalculator.PerformOperation(5.0, 3.0, doubleCalculator.Divide);
        Console.WriteLine($"5.0 / 3.0 = {resultDouble}");

        Calculator<decimal> decimalCalculator = new Calculator<decimal>();
        decimal resultDecimal = decimalCalculator.PerformOperation(5.0m, 3.0m, decimalCalculator.Multiply);
        Console.WriteLine($"5.0m * 3.0m = {resultDecimal}");
    }
}

