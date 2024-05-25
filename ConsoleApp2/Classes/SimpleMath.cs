namespace ConsoleApp2.Classes
{
    internal class SimpleMath : BaseCalculations
    {
        public override void PerformOperation()
        {
            Console.Write("Enter x: ");
            double number1 = double.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            double number2 = double.Parse(Console.ReadLine());
            Console.Write("Enter an operation (+, -, *, /, x^2, x^y, sqrt): ");
            string operation = Console.ReadLine();

            double result = operation switch
            {
                "+" => Add(number1, number2),
                "-" => Subtract(number1, number2),
                "*" => Multiply(number1, number2),
                "/" => Divide(number1, number2),
                "x^2" => Square(number1),
                "x^y" => Power(number1, number2),
                "sqrt" => SquareRoot(number1),
            };

            Console.WriteLine($"Result: {result}");
        }

    }
}
