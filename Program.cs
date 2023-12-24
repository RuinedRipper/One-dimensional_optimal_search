namespace Optimal_search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double interval1 = 0, interval2 = 0;
            string expression;

            while (true)
            {
                Console.Write("Enter expression: ");
                expression = Console.ReadLine()!;

                try
                {
                    Console.Write("Enter first interval: ");
                    interval1 = double.Parse(Console.ReadLine()!);
                    Console.Write("Enter second interval: ");
                    interval2 = double.Parse(Console.ReadLine()!);
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                
                GoldenRationMethod.CalculateMethod(expression, interval1, interval2);
                //HalfMethod.CalculateMethod(expression, interval1, interval2);
                Console.WriteLine();
            }
        }
    }
}
