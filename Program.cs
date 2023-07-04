using System;
using System.Collections.Generic;

namespace Calculadora
{
    public class Statistics
    {
        public double Average{get; set;}
        public double Median{get; set;}
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
                statistics.Median = numbers.Min();
                statistics.Common= numbers.Max();
            }

            return statistics;
        } 
    }
}