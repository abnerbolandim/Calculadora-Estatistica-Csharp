using System;
using System.Collections.Generic;

namespace Calculadora
{
    public class Statistics
    {
        public double Average { get; set; }
        public double Median { get; set; }
        public double Common { get; set; }
        public double Deviation { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
    }

    public class StatisticsCalculator
    {
        public Statistics CalculateStatistics(List<double> numbers)
        {
            Statistics statistics = new Statistics();

            if (numbers.Count > 0)
            {
                statistics.Average = numbers.Average();
                statistics.Minimum = numbers.Min();
                statistics.Maximum = numbers.Max();
                statistics.Median = GetMedian(numbers);
                statistics.Common = GetCommon(numbers);
                statistics.Deviation = GetDeviation(numbers);
            }

            return statistics;
        }

        public double GetMedian(List<double> numbers)
        {
            numbers.Sort();

            double median;
            int middleIndex = numbers.Count / 2;

            if (numbers.Count % 2 == 0)
            {
                median = (numbers[middleIndex - 1] + numbers[middleIndex]) / 2.0;
            }
            else
            {
                median = numbers[middleIndex];
            }

            return median;
        }

        public double GetCommon(List<double> numbers)
        {
            Dictionary<double, int> frequency = new Dictionary<double, int>();

            foreach (double number in numbers)
            {
                if (frequency.ContainsKey(number))
                    frequency[number]++;
                else
                    frequency[number] = 1;
            }

            double mode = 0;
            int maxCount = 0;

            foreach (KeyValuePair<double, int> pair in frequency)
            {
                if (pair.Value > maxCount)
                {
                    maxCount = pair.Value;
                    mode = pair.Key;
                }
            }

            return mode;
        }

        public double GetDeviation(List<double> numbers)
        {
            double average = numbers.Average();
            double sumOfSquares = 0;

            foreach (double number in numbers)
            {
                double difference = number - average;
                sumOfSquares += difference * difference;
            }

            double variance = sumOfSquares / numbers.Count;
            double deviation = Math.Sqrt(variance);

            return deviation;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {

            List<double> numbers = new List<double> { 2.5, 4.7, 4.7, 6.3, 8.1, 9.2 };

            StatisticsCalculator calculator = new StatisticsCalculator();
            Statistics statistics = calculator.CalculateStatistics(numbers);

            Console.WriteLine("Média: " + statistics.Average.ToString("F2"));
            Console.WriteLine("Mediana: " + statistics.Median.ToString("F2"));
            Console.WriteLine("Comum: " + statistics.Common.ToString("F2"));
            Console.WriteLine("Desvio Padrão: " + statistics.Deviation.ToString("F1"));
            Console.WriteLine("Mínimo: " + statistics.Minimum.ToString("F2"));
            Console.WriteLine("Máximo: " + statistics.Maximum.ToString("F2"));

            Console.ReadLine();

        }
    }
}