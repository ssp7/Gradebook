using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Driver
    {
        static void Main(string[] args)
        {
            var book = new Book("Patel's gradebook");
            System.Console.WriteLine("Please enter grades and enter q to quit");
            Boolean termination = false;
            while(termination == false){
                var grade = Console.ReadLine();
                if (grade != "q")
                {
                    try
                    {
                        book.AddGrade(Double.Parse(grade));
                        book.printGrades();
                        Console.WriteLine("(enter q to quit)");
                    }
                    catch(ArgumentException exception){
                        Console.WriteLine(exception.Message);
                    }
                    catch(FormatException exception){
                        Console.WriteLine(exception.Message);
                    }
                    finally{
                        Console.WriteLine("*****");
                    }
                }
                else{
                    termination = true;  
                }

            }
            var stats = book.getStatistics();
            book.printStatistics(stats);
        }
    }
}
