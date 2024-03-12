namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;

    public class TextBookTests
    {
        private TextBook textBook;
        private string title = "1984";
        private string authour = "George Orwell";
        private string category = "Disthopy";

        private UniversityLibrary lib;

        [SetUp]
        public void Setup()
        {
            textBook = new TextBook(title, authour, category);
            lib = new UniversityLibrary();
        }

        [Test]
        public void TestTextbookConstructor_SetsValuesCorrectly()
        {
            Assert.That(category, Is.EqualTo(textBook.Category));
            Assert.That(authour, Is.EqualTo(textBook.Author));
            Assert.That(title, Is.EqualTo(textBook.Title));
        }

        [Test]
        public void AddTextBookWorksCorrectly()
        {
            string result = lib.AddTextBookToLibrary(textBook);
            Assert.That(textBook.InventoryNumber, Is.EqualTo(1));
            Assert.That(lib.Catalogue.Count, Is.EqualTo(1));
            Assert.That(title, Is.EqualTo(lib.Catalogue[0].Title));

            Assert.That($"Book: 1984 - 1{Environment.NewLine}Category: Disthopy{Environment.NewLine}Author: George Orwell".TrimEnd(), Is.EqualTo(result));
        }

        [Test]
        public void LoanTextbookTests()
        {
            lib.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook.Holder, null);

            string result = lib.LoanTextBook(1, "Pesho");

            Assert.That(textBook.Holder, Is.EqualTo("Pesho"));
            Assert.That($"{title} loaned to Pesho.", Is.EqualTo(result));

            result = lib.LoanTextBook(1, "Pesho");
            Assert.That($"Pesho still hasn't returned {textBook.Title}!", Is.EqualTo(result));

        }

        [Test]
        public void ReturnTextbookTests()
        {
            lib.AddTextBookToLibrary(textBook);
            string result = lib.LoanTextBook(1, "Pesho");

            result = lib.ReturnTextBook(1);

            Assert.That(textBook.Holder, Is.EqualTo(""));
            Assert.That(result, Is.EqualTo($"{textBook.Title} is returned to the library."));
        }
    }
}