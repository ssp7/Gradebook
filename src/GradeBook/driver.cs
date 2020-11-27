using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Driver
    {
        static void Main(string[] args)
        {
            var book = new Book("Patel's gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            var stats = book.getStatistics();
            book.printStatistics(stats);
        }
    }
}
