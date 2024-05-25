namespace ConsoleApp2.Classes
{
    internal class EquationSolver : BaseCalculations
    {

        public override void PerformOperation()
        {
            Console.Write("Enter the equation format\n1.(a+b)^2\n2.(a-b)^2\nEnter the number 1 or 2:  ");
            string format = Console.ReadLine();
            Console.Write("Enter value for a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter value for b: ");
            double b = double.Parse(Console.ReadLine());

            double result = format switch
            {
                "1" => EquationFunction(a, b, true),
                "2" => EquationFunction(a, b, false),
                _ => throw new ArgumentException("Invalid option chosen. Please input 1 or 2 next time.")
            };

            Console.WriteLine($"Result: {result}");
        }

        private double EquationFunction(double a, double b, bool isAddition)
        {
            string operation = isAddition ? "+" : "-";
            double part1 = isAddition ? (a + b) : (a - b);

            Console.WriteLine($"Step 1: ({a} {operation} {b}) = {part1}");
            double result = part1 * part1;
            Console.WriteLine($"Step 2: {part1}^2 = {result}");

            return result;
        }

    }
}
