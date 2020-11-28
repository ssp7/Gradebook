using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod(){
            WriteLogDelegate logDelegate;

            logDelegate = ReturnMessage;

            var result = logDelegate("Hello!");
            Assert.Equal("Hello!", result);
        }

        private string ReturnMessage(string message){
            return message;
        }
        [Fact]
        public void StringsBehaveLikeValueTypes(){
            string name = "Soham";
            var upper = MakeUpperCase(name);

            Assert.Equal("Soham", name);
            Assert.Equal("SOHAM", upper);
        }

        [Fact]
        public void Test1(){
            var x = GetInt();
            setInt(out x);
            Assert.Equal(2, x);
        }
        [Fact]
        public void CSharpPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name){
            return new InMemoryBook(name);
        }

        private void SetName(InMemoryBook book, string newname){
            book.Name = newname;
        }
        private void GetBookSetName(InMemoryBook book, string newname){
            book = new InMemoryBook(newname);
            book.Name = newname;
        }
        private void GetBookSetName(ref InMemoryBook book, string newname){
            book = new InMemoryBook(newname);
        }
        private int GetInt(){
            return 3;
        }

        private void setInt(out Int32 x){
            x = 2;
        }

        private string MakeUpperCase(string parameter){
           return parameter.ToUpper();
        }

    }
}
