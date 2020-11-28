using System;
using System.Collections.Generic;
namespace GradeBook
{
        public delegate void GradeAddedDeligate(object sender, EventArgs args);
    
    public class NamedObject    
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public  string Name 
        {
            set;
            get;
        }
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDeligate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
     public interface IBook {
            void AddGrade(double grade);
            Statistics GetStatistics();
            string Name { get; }
            event GradeAddedDeligate GradeAdded;
        }
      public class InMemoryBook : Book, IBook
    {
        public List<double> grades = new List<double>();
        public const string CATEGORY = "Science";
        public InMemoryBook(string name) : base(name)
        {
            this.grades = new List<double>();
            Name = name;
        }

        public override void AddGrade(double grade){

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

        public override event GradeAddedDeligate GradeAdded;
        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            stats.Average = 0.0;
            stats.Highest = double.MinValue;
            stats.Lowest = double.MaxValue;

            for (var index = 0; index < this.grades.Count; index++)
            {
                stats.Highest = Math.Max(grades[index], stats.Highest);
                stats.Lowest = Math.Min(grades[index], stats.Lowest);
                stats.Average += grades[index];
            }

            stats.Average /= grades.Count;
            switch (stats.Average)
            {
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
            Console.WriteLine($"{InMemoryBook.CATEGORY}");
            Console.WriteLine($"For the book with name {this.Name}");
            Console.WriteLine($"The Average grade is {stats.Average:N1}");
            Console.WriteLine($"The Highest grade is {stats.Highest}");
            Console.WriteLine($"The Lowest grade is {stats.Lowest}");
            Console.WriteLine($"The Letter grade is {stats.Letter}");
            return stats;
        }
        public void printGrades()
        {
            Console.Write("Current Grades: [");
            for (int index = 0; index < grades.Count; index++)
            {
                Console.Write($" {grades[index]}, ");
            }
            Console.Write("].");
            Console.WriteLine(" ");
        }
    }

}