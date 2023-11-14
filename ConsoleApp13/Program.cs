using System;

class Program
{
    static void Main()
    {
        // Ймовірності
        double[][] p_y_given_x = {
            new double[] {0.53, 0.34, 0.13},  // p(y1/x1), p(y2/x1), p(y3/x1)
            new double[] {0.33, 0.14, 0.53}   // p(y1/x2), p(y2/x2), p(y3/x2)
        };
        double[] p_y = { 0.368, 0.178, 0.454 };  // p(y1), p(y2), p(y3)

        // Алфавіти
        int M = p_y_given_x.Length;
        int N = p_y.Length;

        // Ентропія системи
        double entropy_system = -Sum(p_x => Sum(p_y => p_y * Math.Log2(p_y), p_y_given_x[p_x]), M);

        // Повна взаємна інформація
        double mutual_information = Sum(p_x => Sum(p_y => p_y_given_x[p_x][p_y] * Math.Log2(p_y_given_x[p_x][p_y] / (p_y * p_y_given_x[p_x].Sum())), N), M);

        // Надмірність
        double redundancy = entropy_system / mutual_information;

        Console.WriteLine("Ентропія системи (H(X, Y)): " + entropy_system);
        Console.WriteLine("Повна взаємна інформація (I(X, Y)): " + mutual_information);
        Console.WriteLine("Надмірність (R(X|Y)): " + redundancy);
    }

    private static double Sum(Func<int, double> value, double[] doubles)
    {
        throw new NotImplementedException();
    }

    // Функція для обчислення суми з використанням лямбда-виразу
    static double Sum(Func<int, double> func, int max)
    {
        double result = 0;
        for (int i = 0; i < max; i++)
        {
            result += func(i);
        }
        return result;
    }
}
