using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Driver
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Patel's gradebook");
            book.GradeAdded += OnGradedAdded;
            EnterGrades(book);
            var stats = book.GetStatistics();
        }

        private static void EnterGrades(IBook book)
        {
            System.Console.WriteLine("Please enter grades and enter q to quit");
            Boolean termination = false;
            while (termination == false)
            {
                var grade = Console.ReadLine();
                if (grade != "q")
                {
                    try
                    {
                        book.AddGrade(Double.Parse(grade));
                        Console.WriteLine("(enter q to quit)");
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    finally
                    {
                        Console.WriteLine("*****");
                    }
                }
                else
                {
                    termination = true;
                }

            }
        }

        static void OnGradedAdded(object sender, EventArgs e){
            Console.WriteLine("A grade was added");
        }
}
}
