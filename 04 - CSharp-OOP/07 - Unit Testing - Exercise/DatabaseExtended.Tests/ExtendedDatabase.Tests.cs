using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddingUserWithExistingUsername_ShouldThrowException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "username");
            var userTwo = new Person(2, "username");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(userTwo));
        }

        [Test]
        public void AddingUserWithExistingIdInTheDatabase_ShouldThrowException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(2, "usernameOne");
            var userTwo = new Person(2, "usernameTwo");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(userTwo));
        }

        [Test]
        public void RemovingFromEmptyDatabase_ShouldThrowException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Removing_WhenDataIsValid_ShouldReturnCorrectResult()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var user = new Person(1, "user");

            //Act
            database.Add(user);
            database.Remove();

            //Assert
            Assert.AreEqual(database.Count, 0);
        }

        [Test]
        public void SearchingForUsernameNotExistingInTheDatabase_ShouldThrowException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "Existing");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("NotExisting"));
        }

        [Test]
        public void SearchingForNullUsernameInTheDatabase_ShouldThrowException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "user");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void SearchingForValidUsernameInTheDatabase_ShouldReturnCorrectResult()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "user");

            //Act
            database.Add(userOne);
            Person person = database.FindByUsername("user");

            //Assert
            Assert.NotNull(person);
        }

        [Test]
        public void SearchingUserWithUsernameInDifferentCasing_ShouldThrowException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "UserOne_CASING");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("UserOne_casing"));
        }

        [Test]
        public void FindById_ShouldThrowException_WhenNoSuchIdIsFound()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "UserOne");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }

        [Test]
        public void FindById_ShouldThrowException_WhenNegativeIdIsProvided()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "UserOne");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void FindById_ShouldReturnCorrectAnswer_WhenIdIsValid()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "UserOne");

            //Act
            database.Add(userOne);
            Person result = database.FindById(1);

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void CountShouldReturnCorrectValue()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new Person(1, "UserOne");

            //Act
            database.Add(userOne);

            //Assert
            Assert.AreEqual(database.Count, 1);
        }

        [Test]
        public void AddingUser_WhenNotEnoughSpace_ShouldThrowException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var testUser = new Person(99, "test");

            //Act
            for (int person = 0; person < 16; person++)
            {
                var user = new Person(person, $"username-{person}");
                database.Add(user);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(testUser));
        }

        [Test]
        public void AddingRangeOfUsers_WhenNotEnoughSpace_ShouldThrowException()
        {
            //Arrange
            int size = 17;
            Person[] people = new Person[size];

            //Act
            for (int person = 0; person < size; person++)
            {
                var user = new Person(person, $"username-{person}");
                people[person] = user;
            }

            //Assert
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void AddingRangeOfUsers_WhenEnoughSpace_ShouldWorkAsExpected()
        {
            //Arrange
            int size = 5;
            Person[] people = new Person[size];

            //Act
            for (int person = 0; person < size; person++)
            {
                var user = new Person(person, $"username-{person}");
                people[person] = user;
            }

            var database = new ExtendedDatabase.ExtendedDatabase(people);

            //Assert
            Assert.AreEqual(database.Count, size);
        }
    }
}