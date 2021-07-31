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
        public void AddingUserWithSameUsernameAsAlreadyExistingInTheDatabaseShouldThrowInvalidOperationException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new ExtendedDatabase.Person(1, "username");
            var userTwo = new ExtendedDatabase.Person(2, "username");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(userTwo));
        }

        [Test]
        public void AddingUserWithSameIdAsAlreadyExistingInTheDatabaseShouldThrowInvalidOperationException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new ExtendedDatabase.Person(2, "usernameOne");
            var userTwo = new ExtendedDatabase.Person(2, "usernameTwo");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(userTwo));
        }

        [Test]
        public void RemovingFromEmptyDatabaseShouldThrowInvalidOperationException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void SearchingForUsernameNotExistingInTheDatabaseThrowsInvalidOperationException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new ExtendedDatabase.Person(1, "Existing");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("NotExisting"));
        }

        //[Test]
        //public void AddingUserWtihNullUsernameShouldThrow()
        //{
        //    //Arrange
        //    var database = new ExtendedDatabase.ExtendedDatabase();
        //    var userOne = new ExtendedDatabase.Person(1, null);

        //    //Act - Assert
        //    Assert.Throws<ArgumentNullException>(() => database.Add(userOne));
        //}

        [Test]
        public void SearchingUserWithUsernameInDifferentCasingThrowsInvalidOperationException()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new ExtendedDatabase.Person(1, "UserOne_CASING");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("UserOne_casing"));
        }

        [Test]
        public void FindByIdShouldThrowInvalidOperationExceptionWhenNoSuchIdIsFound()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new ExtendedDatabase.Person(1, "UserOne");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }

        [Test]
        public void FindByIdShouldThrowArgumentOutOfRangeExceptionWhenNegativeIdIsProvided()
        {
            //Arrange
            var database = new ExtendedDatabase.ExtendedDatabase();
            var userOne = new ExtendedDatabase.Person(1, "UserOne");

            //Act
            database.Add(userOne);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
    }
}