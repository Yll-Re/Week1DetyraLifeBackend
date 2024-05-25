using ConsoleApp2.Classes;
using ConsoleApp2.Intefaces;

namespace Calculator
{
    class Program
    {
        public delegate void CalculatorEventHandler(object sender, EventArgs e);
        public static event CalculatorEventHandler OnOverheat;

        static void Main(string[] args)
        {
            int operationCount = 0;
            OnOverheat += Overheat;

            while (true)
            {
                Console.WriteLine("Choose an option\n1. Simple Math Operations\n2. Equation Solver\n3. Quadratic Equation Solver\n4. Exit");
                Console.Write("Option: ");
                string chosenOption = Console.ReadLine();


                if (chosenOption == "4")
                {
                    break;
                }

                ICalculator calculator;
                try
                {
                    calculator = chosenOption switch
                    {
                        "1" => new SimpleMath(),
                        "2" => new EquationSolver(),
                        "3" => new QuadraticEquationSolver(),
                        _ => throw new ArgumentException("Invalid choice")
                    };
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                    continue;
                }

                // qito 2 try catch garant ma mir bashk
                try
                {
                    operationCount++;
                    if (operationCount > 3) // Nese don ma shume testing e mos me dal overheating veq ndrro 3 te najsen tjeter ose commente
                    {
                        OnOverheat?.Invoke(null, EventArgs.Empty);
                        continue;
                    }
                    calculator.PerformOperation();
                    
                    
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
        static void Overheat(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The calculator is heated more than it should please turn off asap");
            Console.ResetColor();
        }
    }
}