namespace ConsoleApp2.Intefaces
{
    public interface ICalculator
    {
        void PerformOperation();
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
        double Square(double a);
        double SquareRoot(double a);
        double Power(double a, double b);
    }
}
