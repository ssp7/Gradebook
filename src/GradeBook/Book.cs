using System;
using System.Collections.Generic;
namespace GradeBook
{
  public class Book
    {
        public delegate void GradeAddedDeligate(object sender, EventArgs args);

        public List<double> grades = new List<double>();
        
        public string Name {
            get; set;
        }
        public const string CATEGORY = "Science";
        public Book(string name)
        {
            this.grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade){

            if(grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                } 
            }
            else{
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void AddGrade(char LetterGrade){
            switch(LetterGrade){
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public event GradeAddedDeligate GradeAdded;
        public Statistics getStatistics(){
            var stats = new Statistics();
            stats.Average = 0.0;
            stats.Highest = double.MinValue;
            stats.Lowest = double.MaxValue;
    
            for ( var index = 0;index < this.grades.Count;index++)
            {
                stats.Highest = Math.Max(grades[index], stats.Highest);
                stats.Lowest = Math.Min(grades[index], stats.Lowest);
                stats.Average += grades[index];
            }

            stats.Average /= grades.Count;
            switch(stats.Average) {
                case var d when d >= 90.0:
                     stats.Letter = 'A';
                break;
                case var d when d >= 80.0:
                     stats.Letter = 'B';
                break;
                case var d when d >= 70.0:
                     stats.Letter = 'C';
                break;
                case var d when d >= 60.0:
                     stats.Letter = 'D';
                break;
                default:
                    stats.Letter = 'F';
                    break;
            }
            return stats;
        }
        public void printStatistics(Statistics stats){
            Console.WriteLine($"{Book.CATEGORY}");
            Console.WriteLine($"For the book with name {this.Name}");
            Console.WriteLine($"The Average grade is {stats.Average:N1}");
            Console.WriteLine($"The Highest grade is {stats.Highest}");
            Console.WriteLine($"The Lowest grade is {stats.Lowest}");
            Console.WriteLine($"The Letter grade is {stats.Letter}");
        }

        public void printGrades(){
            Console.Write("Current Grades: [");
            for (int index = 0; index < grades.Count; index++){
                Console.Write($" {grades[index]}, ");
            }
            Console.Write("].");
            Console.WriteLine(" ");
        }
    }

}