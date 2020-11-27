using System;
using System.Collections.Generic;
namespace GradeBook
{
  public class Book
    {
        private List<double> grades = new List<double>();
        private string name = "";
        public Book(string name)
        {
            this.grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade){
            grades.Add(grade);
        }
        public Statistics getStatistics(){
            var stats = new Statistics();
            stats.Average = 0.0;
            stats.Highest = double.MinValue;
            stats.Lowest = double.MaxValue;
            foreach (var grade in this.grades)
            {
                stats.Highest = Math.Max(grade, stats.Highest);
                stats.Lowest = Math.Min(grade, stats.Lowest);
                stats.Average += grade;
            }
            stats.Average /= grades.Count;
            return stats;
        }
        public void printStatistics(Statistics stats){
            Console.WriteLine($"The Average grade is {stats.Average:N1}");
            Console.WriteLine($"The Highest grade is {stats.Highest}");
            Console.WriteLine($"The Lowest grade is {stats.Lowest}");
        }
    }

}