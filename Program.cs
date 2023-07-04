using System;
using System.Collections.Generic;

namespace Calculadora
{
    public class Statistics
    {
        public double Average{get; set;}
        public int Median{get; set;}
        public double Common{get; set;}
        public double Deviation{get; set;}
        public double Minimum{get; set;}
        public double Maximum{get; set;}  
    }

    public class StatisticsCalculator
    {
        public Statistics CalculateStatistics(List<double> numbers)
        {
            Statistics statistics = new Statistics();
            
            if(numbers.Count > 0)
            {
                statistics.Average = numbers.Average();
                statistics.Minimum = numbers.Min();
                statistics.Maximum =  numbers.Max();
            }

            return statistics;  
        } 
        
    }

    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public static double GetMedian(List<int> numbers)
        {
            numbers.Sort();

            double median;
            int middleIndex = numbers.Count / 2;

            if(numbers.Count % 2 == 0)
            {
                median = (numbers[middleIndex - 1] + numbers[middleIndex]) / 2.0;  
            }

            else
            {
                median = numbers[middleIndex];
            }

            return median;
        }
    }
}