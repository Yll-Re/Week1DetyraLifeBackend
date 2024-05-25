namespace ConsoleApp2.Classes
{
    internal class QuadraticEquationSolver : BaseCalculations
    {
        public override void PerformOperation()
        {
            Console.WriteLine("Enter  a, b and c of quadratic equation (ax^2 + bx + c = 0):");
            Console.Write("Enter value for a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Enter value for b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter value for c: ");
            double c = double.Parse(Console.ReadLine());

            double realRoot = b * b - 4 * a * c;
            if (realRoot < 0)
            {
                Console.WriteLine("No real roots exist.");
                return;
            }

            double sqrtRoot = Math.Sqrt(realRoot);
            double root1 = (-b + sqrtRoot) / (2 * a);
            double root2 = (-b - sqrtRoot) / (2 * a);


            Console.WriteLine($"Roots: {root1} and {root2}");
        }
    }
}
