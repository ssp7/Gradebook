using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var stats = book.getStatistics();

            // assert
            Assert.Equal(85.6, stats.Average, 1);
            Assert.Equal(90.5, stats.Highest, 1);
            Assert.Equal(77.3, stats.Lowest, 1);
            Assert.Equal('B', stats.Letter);
        }

        // [Fact]
        // public void BookWillNotAddValueGreaterThankHundredOrLessThannZero(){
        //     var book = new Book("Test Book");
        //     book.AddGrade(105);
        //     Assert.Equal( 0,book.grades.Count);
        // }
    }
}