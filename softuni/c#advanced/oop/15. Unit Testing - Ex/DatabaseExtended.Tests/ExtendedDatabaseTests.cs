namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database _database;

        [SetUp]
        public void Setup()
        {
            _database = new Database();
        }
        [TearDown]
        public void TearDown()
        {
            _database = null;
        }

        [Test]
        public void AddFetchMethodTest()
        {
            _database.Add(new Person(1, "Pesho"));
            Person result = _database.FindById(1);

            Assert.AreEqual(1, _database.Count);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Pesho", result.UserName);
        }
        [Test]
        public void ShouldThrowIfMoreThanMaxLength()
        {
            Person[] people = CreateFullArray();
            _database = new Database(people);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _database.Add(new Person(17, "Pesho")));
            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void AddShouldThrowIfNotUniqueUsername()
        {
            _database.Add(new Person(1, "Pesho"));
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _database.Add(new Person(17, "Pesho")));
            Assert.That(exception.Message, Is.EqualTo("There is already user with this username!"));
        }
        [Test]
        public void AddShouldThrowIfNotUniqueId()
        {
            _database.Add(new Person(1, "Gosho"));
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _database.Add(new Person(1, "Pesho")));
            Assert.That(exception.Message, Is.EqualTo("There is already user with this Id!"));
        }
        private Person[] CreateFullArray()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, i.ToString());
            }
            return people;
        }
        [Test]
        public void CreateDatabaseWith2Elements()
        {
            _database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person first = _database.FindById(1);
            Person second = _database.FindById(2);

            Assert.AreEqual(2, _database.Count);
            Assert.AreEqual("Pesho", first.UserName);
            Assert.AreEqual("Gosho", second.UserName);
        }
        [Test]
        public void RemoveFromEmptyDbShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => _database.Remove());
        }
        [Test]
        public void RemoveLastFromDb()
        {
            _database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            _database.Remove();
            Person first = _database.FindById(1);

            Assert.AreEqual(1, _database.Count);
            Assert.AreEqual("Pesho", first.UserName);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _database.FindByUsername("Gosho"));
            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));

        }
        [Test]
        public void FindByUsernameShoudThrowIfUsernameNullOrEmpty()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => _database.FindByUsername(null));
            Assert.That(exception.ParamName, Is.EqualTo("Username parameter is null!"));

            ArgumentNullException emptyEx = Assert.Throws<ArgumentNullException>(() => _database.FindByUsername(string.Empty));
            Assert.That(emptyEx.ParamName, Is.EqualTo("Username parameter is null!"));
        }
        [Test]
        public void FindByUsernameShoudThrowIfUsernameDoesNotExist()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _database.FindByUsername("Gosho"));
            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));
        }
        [Test]
        public void FindByUserReturnsCorrectUser()
        {
            _database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = _database.FindByUsername("Gosho");
            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }
        [Test]
        public void FindByIdShoudThrowIfIdIsLessThanZero()
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => _database.FindById(-2));
            Assert.That(exception.ParamName, Is.EqualTo("Id should be a positive number!"));
        }
        [Test]
        public void FindByIdShoudThrowIfIdDoesNotExist()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => _database.FindById(8));
            Assert.That(exception.Message, Is.EqualTo("No user is present by this ID!"));
        }
        [Test]
        public void FindByIdReturnsCorrectId()
        {
            _database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = _database.FindById(2);
            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }
    }   
}