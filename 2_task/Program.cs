using System;

class Program
{
    static void Main()
    {
        // Ймовірності та тривалості
        double[] probabilities = { 0.37, 0.18, 0.06, 0.3 };
        double[] durations = { 5, 14, 8, 3 };

        // Ентропія
        double entropy = -Sum(p => p * Math.Log2(p), probabilities);

        // Продуктивність
        double productivity = entropy / Sum((p, t) => p * t, probabilities, durations);

        // Надмірність
        double redundancy = 1-(entropy / Math.Log2(durations.Length));

        Console.WriteLine("Ентропія: " + entropy);
        Console.WriteLine("Продуктивність: " + productivity);
        Console.WriteLine("Надмірність: " + redundancy);
    }

    // Функція для обчислення суми з використанням лямбда-виразу
    static double Sum(Func<double, double> func, params double[] values)
    {
        double result = 0;
        foreach (var value in values)
        {
            result += func(value);
        }
        return result;
    }

    // Функція для обчислення суми з використанням лямбда-виразу з двома параметрами
    static double Sum(Func<double, double, double> func, double[] values1, double[] values2)
    {
        double result = 0;
        for (int i = 0; i < values1.Length; i++)
        {
            result += func(values1[i], values2[i]);
        }
        return result;
    }
}
