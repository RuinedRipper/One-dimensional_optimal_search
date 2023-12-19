using org.mariuszgromada.math.mxparser;

namespace Optimal_search
{
    public class GoldenRationMethod : BaseMethod
    {
        private static readonly double t = 0.618034;
        private static void CalculateIteration(double a, double b)
        {
            double A = a;
            double B = b;
            double X1 = A + (1 - t) * (B - A);
            double X2 = A + t * (B - A);
            double F1 = CalculateExpression(X1);
            double F2 = CalculateExpression(X2);

            Console.WriteLine($"{currentIteration}\t{Math.Round(A, 4)}\t{Math.Round(B, 4)}\t{Math.Round(X1, 4)}\t{Math.Round(X2, 4)}\t{Math.Round(F1, 4)}\t{Math.Round(F2, 4)}");

            if (Math.Abs(B - A) <= e)
            {
                Console.WriteLine("Final iteration");
                currentIteration = 0;
            }
            else
            {
                A = F1 < F2 ? A : X1;
                B = F1 > F2 ? B : X2;
                currentIteration++;
                CalculateIteration(A, B);
            }
        }

        public static void CalculateMethod(string enteredExpression, double interval1, double interval2)
        {
            F = new Function($"F(x) = {enteredExpression}");

            var leftAndRightCorner = GetLeftAndRightCorner(interval1, interval2);

            Console.WriteLine("n\ta\tb\tx1\tx2\tf1\tf2");
            CalculateIteration(leftAndRightCorner.a, leftAndRightCorner.b);
        }
    }
}
