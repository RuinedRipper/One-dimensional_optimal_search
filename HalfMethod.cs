using org.mariuszgromada.math.mxparser;

namespace Optimal_search
{
    public class HalfMethod : BaseMethod
    {
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

            var leftAndRightCorner = GetAndShowExtremums(interval1, interval2);

            Console.WriteLine("n\ta\tb\tL\txAvg\tx1\tx2\tfAvg\tf1\tf2");
            CalculateIteration(leftAndRightCorner.a, leftAndRightCorner.b);
        }
    }
}
