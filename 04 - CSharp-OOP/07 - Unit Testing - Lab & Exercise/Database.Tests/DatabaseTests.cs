using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DatabaseCapacityShouldBeExactly16IntegersWhenGivenExactly16Elements()
        {
            //Arrange
            var array = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var database = new Database.Database(array);

            //Act
            var expectedCapacity = 16;
            var actualCapacity = database.Count;

            //Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionWhenInvokedWithMoreThan16Elements()
        {
            //Arrange
            var array = new int[17] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => new Database.Database(array));
        }

        [Test]
        public void DatabaseCapacityShouldBe15IntegersWhenGiven15Elements()
        {
            //Arrange
            var array = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var database = new Database.Database(array);

            var expectedCapacity = 15;
            var actualCapacity = database.Count;

            //Act - Assert
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void AddingElementWhenCellIsFreeShouldAppendItToTheRight()
        {
            //Arrange
            var array = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var database = new Database.Database(array);

            //Act
            database.Add(16);

            var expectedElement = 16;
            var actualElement = database.Fetch()[15];

            //Assert
            Assert.AreEqual(expectedElement, actualElement);
        }

        [Test]
        public void AddingElementWhenCellIsNotFreeShouldThrowException()
        {
            //Arrange
            var array = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var database = new Database.Database(array);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void RemovingElementLeavesUsWithElementBeingTheFarthestRightOne()
        {
            //Arrange
            var array = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var database = new Database.Database(array);

            //Act
            database.Remove();
            var expectedElement = 15;
            var actualElement = database.Fetch()[14];

            //Assert
            Assert.AreEqual(expectedElement, actualElement);
        }

        [Test]
        public void RemovingElementWhenDatabaseIsEmptyShouldThrowException()
        {
            //Arrange
            var array = new int[0] {};
            var database = new Database.Database(array);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnElementsAsAnArray()
        {
            //Arrange
            var array = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var database = new Database.Database(array);

            //Act
            var expectedResultType = array.GetType();
            var actualResultType = database.Fetch().GetType();

            //Assert
            Assert.AreEqual(expectedResultType, actualResultType);
        }

        //[Test]
        //public void AddingStringArrayShouldThrowException()
        //{
        //    //Arrange
        //    var array = new int[1] { 6 };
        //    var database = new Database.Database(5.000);

        //    //Act - Assert
        //    Assert.Throws<InvalidOperationException>(() => database.Remove());
        //}
    }
}