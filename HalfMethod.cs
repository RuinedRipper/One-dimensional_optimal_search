using org.mariuszgromada.math.mxparser;

namespace PR5
{
    public static class HalfMethod
    {
        static HalfMethod()
        {
            License.iConfirmNonCommercialUse("rosti");
        }

        private static double e = 0.001;
        private static int currentIteration = 0;

        private static Function F;
        private static Expression expression;

        private static double CalculateExpression(double x)
        {
            expression = new Expression($"F({x.ToString(System.Globalization.CultureInfo.InvariantCulture)})", F);
            return expression.calculate();
        }

        private static List<double[]> GetIntervalValuesArray(double interval1, double interval2)
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

        private static (double a, double b) GetLeftAndRightCorner(double interval1, double interval2)
        {
            var intervalValuesArray = GetIntervalValuesArray(interval1, interval2);
            double a = 0, b = 0;
            for (int i = 0; i <= intervalValuesArray.Count; i++)
            {
                try
                {
                    if ((intervalValuesArray[i][1] < intervalValuesArray[i - 1][1] && intervalValuesArray[i][1] < intervalValuesArray[i + 1][1]) || (intervalValuesArray[i][1] > intervalValuesArray[i - 1][1] && intervalValuesArray[i][1] > intervalValuesArray[i + 1][1]))
                    {
                        a = intervalValuesArray[i - 1][0];
                        b = intervalValuesArray[i + 1][0];
                        break;
                    }
                }
                catch { }
            }

            return (a, b);
        }

        private static void CalculateIteration(double a, double b)
        {
            double A = a;
            double B = b;
            double L = B - A;
            double Xavg = (A + B) / 2;
            double X1 = A + L / 4;
            double X2 = B - L / 4;
            double Favg = CalculateExpression(Xavg);
            double F1 = CalculateExpression(X1);
            double F2 = CalculateExpression(X2);

            Console.WriteLine($"{currentIteration}\t{Math.Round(A, 4)}\t{Math.Round(B, 4)}\t{Math.Round(L, 4)}\t{Math.Round(Xavg, 4)}\t{Math.Round(X1, 4)}\t{Math.Round(X2, 4)}\t{Math.Round(Favg, 4)}\t{Math.Round(F1, 4)}\t{Math.Round(F2, 4)}");

            if (Math.Abs(L) <= e)
            {
                Console.WriteLine("Final iteration");
                currentIteration = 0;
            }
            else
            {
                A = F1 < Favg ? A : F2 >= Favg ? X1 : Xavg;
                B = F1 < Favg ? Xavg : F2 >= Favg ? X2 : B;
                currentIteration++;
                CalculateIteration(A, B);
            }
        }

        public static void CalculateMethod(string enteredExpression, double interval1, double interval2)
        {
            F = new Function($"F(x) = {enteredExpression}");

            var leftAndRightCorner = GetLeftAndRightCorner(interval1, interval2);

            Console.WriteLine("n\ta\tb\tL\txAvg\tx1\tx2\tfAvg\tf1\tf2");
            CalculateIteration(leftAndRightCorner.a, leftAndRightCorner.b);
        }
    }
}
