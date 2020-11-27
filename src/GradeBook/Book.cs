using System;
using System.Collections.Generic;
namespace GradeBook
{
 class Book
    {
        private List<double> grades = new List<double>();
        private double highest = double.MinValue;
        private double lowest = double.MaxValue;
        private double result = 0.0;
        private string name = "";
        public Book(string name)
        {
            this.grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade){
            grades.Add(grade);
        }
        public void setStatistics(){
            foreach (var number in this.grades)
            {
                this.highest = Math.Max(number, highest);
                this.lowest = Math.Min(number, lowest);
                this.result += number;
            }
            this.result /= grades.Count;
        }
        public void printStatistics(){
            Console.WriteLine($"The Average grade is {this.result:N1}");
            Console.WriteLine($"The Highest grade is {this.highest}");
            Console.WriteLine($"The Lowest grade is {this.lowest}");
        }
    }

}