using org.mariuszgromada.math.mxparser;

namespace Optimal_search
{
    public class BaseMethod
    {
        static BaseMethod()
        {
            License.iConfirmNonCommercialUse("rosti");
        }

        private protected static readonly double e = 0.001;
        private protected static int currentIteration = 0;

        private protected static Function F;
        private protected static Expression expression;

        private protected static double CalculateExpression(double x)
        {
            expression = new Expression($"F({x.ToString(System.Globalization.CultureInfo.InvariantCulture)})", F);
            return expression.calculate();
        }

        private protected static List<double[]> GetIntervalValuesArray(double interval1, double interval2)
        {
            List<double[]> intervalValuesArray = new List<double[]>();
            Console.WriteLine("X\tY");
            for (double x = interval1; x <= interval2; x = Math.Round(x + 0.1, 3))
            {
                intervalValuesArray.Add(
                [
                    x,
                    CalculateExpression(x)
                ]);
                Console.WriteLine($"{intervalValuesArray.Last()[0]}\t{Math.Round(intervalValuesArray.Last()[1], 4)}");
            }
            Console.WriteLine();

            return intervalValuesArray;
        }

        private protected static (double a, double b) GetAndShowExtremums(double interval1, double interval2)
        {
            var intervalValuesArray = GetIntervalValuesArray(interval1, interval2);
            double a = 0, b = 0;

            Console.WriteLine("Extremums");
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i <= intervalValuesArray.Count; i++)
            {
                try
                {
                    if (intervalValuesArray[i][1] < intervalValuesArray[i - 1][1] && intervalValuesArray[i][1] < intervalValuesArray[i + 1][1])
                    {
                        if (a == 0 && b == 0)
                        {
                            a = intervalValuesArray[i - 1][0];
                            b = intervalValuesArray[i + 1][0];
                        }
                        Console.WriteLine($"({intervalValuesArray[i - 1][0]} ; {intervalValuesArray[i + 1][0]}) - minimum\n");
                        Console.ResetColor();
                    }
                    else if (intervalValuesArray[i][1] > intervalValuesArray[i - 1][1] && intervalValuesArray[i][1] > intervalValuesArray[i + 1][1])
                    {
                        if (a == 0 && b == 0)
                        {
                            a = intervalValuesArray[i - 1][0];
                            b = intervalValuesArray[i + 1][0];
                        }
                        Console.WriteLine($"({intervalValuesArray[i - 1][0]} ; {intervalValuesArray[i + 1][0]}) - maximum\n");
                        Console.ResetColor();
                    }
                }
                catch { }
            }

            return (a, b);
        }
    }
}
