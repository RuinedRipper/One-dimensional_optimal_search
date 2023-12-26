using org.mariuszgromada.math.mxparser;

namespace Optimal_search
{
    public class FibonacciMethod : BaseMethod
    {
        private static List<int> fibonacciSequence = new List<int> { 1, 1 };
        private static double extremumA;
        private static double extremumB;

        private static void CalculatePreIteration(double a, double b)
        {
            Console.WriteLine($"{fibonacciSequence[0]}\n{fibonacciSequence[1]}");
            extremumA = a;
            extremumB = b;
            CalculateIteration(a, b);
        }

        private static void CalculateIteration(double a, double b)
        {
            fibonacciSequence.Add(fibonacciSequence[^1] + fibonacciSequence[^2]);

            bool conditionResult = (extremumB - extremumA) / e <= fibonacciSequence.Last();

            Console.Write($"{fibonacciSequence.Last()}\t{conditionResult}\t\t");

            if (conditionResult)
            {
                double A = a;
                double B = b;
                double X1 = A + (double)fibonacciSequence[^3] / (double)fibonacciSequence[^1] * (B - A);
                double X2 = A + (double)fibonacciSequence[^2] / (double)fibonacciSequence[^1] * (B - A);
                double F1 = CalculateExpression(X1);
                double F2 = CalculateExpression(X2);

                Console.WriteLine($"{currentIteration}\t{Math.Round(A, 4)}\t{Math.Round(B, 4)}\t{Math.Round(X1, 4)}\t{Math.Round(X2, 4)}\t{Math.Round(F1, 4)}\t{Math.Round(F2, 4)}");
                if (Math.Abs(A - B) <= e)
                {
                    Console.WriteLine("\t\t\tFinal iteration\n");
                    currentIteration = 0;
                    return;
                }
                else
                {
                    A = F1 < F2 ? A : X1;
                    B = F1 < F2 ? X2 : B;
                    currentIteration++;
                    CalculateIteration(A, B);
                }
            }
            else
            {
                if ((extremumB - extremumA) / e <= (fibonacciSequence[^1] + fibonacciSequence[^2]))
                {
                    Console.Write("n\ta\tb\tx1\tx2\tf1\tf2");
                }

                Console.WriteLine();
                CalculateIteration(a, b);
            }


        }

        public static void CalculateMethod(string enteredExpression, double interval1, double interval2)
        {
            F = new Function($"F(x) = {enteredExpression}");

            var leftAndRightCorner = GetAndShowExtremums(interval1, interval2);

            Console.WriteLine("FI\tT/F\t\t");
            CalculatePreIteration(leftAndRightCorner.a, leftAndRightCorner.b);

            fibonacciSequence = new List<int> { 1, 1 };
        }
    }
}
