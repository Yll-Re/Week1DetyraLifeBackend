using ConsoleApp2.Intefaces;

namespace ConsoleApp2.Classes
{
    public abstract class BaseCalculations : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new ArgumentException("Cannot divide by zero.");
            }
            return a / b;
        }

        public double Square(double a)
        {
            return a * a;
        }

        public double SquareRoot(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Cannot calculate root of a negative number.");
            }
            return Math.Sqrt(a);
        }

        public double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public abstract void PerformOperation();
    }
}
