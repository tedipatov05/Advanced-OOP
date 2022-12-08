namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Book book = null;

        [SetUp]
        public void SetUp()
        {
           
             book = new Book("Star Wars", "Teodor Patov");
        }

        [Test]
        public void ConstructorShouldInitializeDataCorrectly()
        {
            string bookName = "Star Wars";
            string author = "Teodor Patov";
            Book book = new Book(bookName, author);

            Assert.IsNotNull(book);
            Assert.AreEqual(bookName, book.BookName);
            Assert.AreEqual(author, book.Author);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestBookNameSetterValidation(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "Teodor");
            }, $"Invalid {nameof(Book.BookName)}!");

        }

        [TestCase(null)]
        [TestCase("")]
        public void TestAuthorSetterValidation(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("'Star Wars", author);

            }, $"Invalid {nameof(Book.Author)}!");

        }
        [Test]
        public void AddFoooterShouldThrowAnExceptionWihtDuplicateFooter()
        {
            book.AddFootnote(19, "Teodor");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(19, "Alive");

            }, "Footnote already exists!");
        }

        [Test]
        public void AddFooterShouldIncreaseCountOfFooters()
        {
            book.AddFootnote(12, "test");
            book.AddFootnote(13, "alive");

            int actualCount = book.FootnoteCount;
            int expectedCount = 2;
            
            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void FindFootNoterShouldThrowAnExceptionWithUnexitingFootNoter()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(4);
            }, "Footnote doesn't exists!");
        }

        [Test]
        public void FindFootNoterShouldReturnInformationAboutFoundFootNoter()
        {
            book.AddFootnote(19, "Teodor");

            string actualOutput = book.FindFootnote(19);
            string expectedOutput = $"Footnote #{19}: Teodor";

            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [Test]
        public void AlterFootNoterShouldThrowAnExceptionWithNonExistingFootNoter()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(12, "newtext");
            }, "Footnote does not exists!");
        }

        [Test]
        public void AlterFootNoterShouldChangeTheTextOfExistingFootNoter()
        {
            book.AddFootnote(19, "TeodorPatov19");
            book.AlterFootnote(19, "newtext");

            string actualOutput = book.FindFootnote(19);
            string expextedOutput = $"Footnote #{19}: newtext";

            Assert.AreEqual(expextedOutput, actualOutput);
        }
    }
}