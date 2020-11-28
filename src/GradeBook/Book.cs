using System;
using System.Collections.Generic;
using System.IO;

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

        public abstract event GradeAddedDeligate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
     public interface IBook {
            void AddGrade(double grade);
            Statistics GetStatistics();
            string Name { get; }
            event GradeAddedDeligate GradeAdded;
        }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDeligate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer =  File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt")){
              var line = reader.ReadLine();
                while(line != null){
                    var number = double.Parse(line);
                    stats.Add(number);
                    line = reader.ReadLine();
                }
            };
            
            return stats;
        }
    }
    public class InMemoryBook : Book, IBook
    {
        public List<double> grades;
        public const string CATEGORY = "Science";
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
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
            for (var index = 0; index < this.grades.Count; index++)
            {
                stats.Add(grades[index]);
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