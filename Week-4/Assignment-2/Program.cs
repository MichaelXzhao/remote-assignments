using System;
using Microsoft.Extensions.DependencyInjection;


namespace DependencyInjectionExample
{
    // Create the ICalculator interface
    public interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
    }

    // Implement the ICalculator interface in two different classes
    public class SimpleCalculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

        
    public class AdvancedCalculator : ICalculator
    {
        public int Add(int a, int b)
        {
            while (b != 0)
            {
                int carry = a & b;
                a = a ^ b;
                b = carry << 1;
            }

            return a;
        }

        public int Subtract(int a, int b)
        {
            while (b != 0)
            {
                int borrow = (~a) & b;
                a = a ^ b;
                b = borrow << 1;
            }

            return a;
        }
    }



    // Create the CalculatorController class
    public class CalculatorController
    {
        private readonly ICalculator _calculator;
        private readonly string _calculatorType;

        // Constructor with DI
        public CalculatorController(ICalculator calculator, string calculatorType)
        {
            _calculator = calculator;
            _calculatorType = calculatorType;
        }

        public void Calculate(int a, int b)
        {
            int result;

            // Perform addition or subtraction based on calculator type
            if (_calculatorType == "Simple")
            {
                result = _calculator.Add(a, b);
            }
            else if (_calculatorType == "Advanced")
            {
                result = _calculator.Subtract(a, b);
            }
            else
            {
                Console.WriteLine("Invalid calculator type");
                return;
            }

            Console.WriteLine($"Result: {result}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Use the built-in .NET Core DI container to inject the calculator implementation
            var calculatorType = "Advanced"; // Change this to "Advanced" to use the advanced calculator

            // Create an instance of the CalculatorController class with DI
            using (var serviceProvider = new ServiceCollection()
                .AddTransient<ICalculator, SimpleCalculator>()
                .AddTransient<ICalculator, AdvancedCalculator>()
                .BuildServiceProvider())
            {
                var calculator = serviceProvider.GetRequiredService<ICalculator>();
                var calculatorController = new CalculatorController(calculator, calculatorType);

                // Call the Calculate method with two integers
                calculatorController.Calculate(10, 5);
            }

            Console.ReadLine();
        }
    }
}



// See https://aka.ms/new-console-template for more information

