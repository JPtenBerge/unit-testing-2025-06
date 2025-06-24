using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.MSTest
{
    [TestClass]
    public sealed class Test1
    {
        Calculator _sut = null!;

        //public Test1()
        //{
        //    _sut = new Calculator();
        //}

        [TestInitialize]
        public void Init()
        {
            _sut = new Calculator();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(42, 42);
            //Assert.AreEqual("hoi", "doei");
        }

        [TestMethod]
        public void Add_OnePositiveInteger_CalculatesCorrectly()
        {
            // Arrange - setup
            // SUT => System Under Test
            var number = 42;

            // Act - doen
            _sut.Add(number);

            // Assert - toetsen
            Assert.AreEqual(number, _sut.Result);
        }

        [TestMethod]
        public void Add_TwoPositiveIntegers_CalculatesCorrectly()
        {
            // Arrange - setup
            var number = 42;
            var anotherNumber = 74;

            // Act - doen
            _sut.Add(number);
            _sut.Add(anotherNumber);

            // Assert - toetsen
            Assert.AreEqual(number + anotherNumber, _sut.Result);
        }

        [TestMethod]
        public void Multiply_TwoPositiveIntegers_CalculatesCorrectly()
        {
            // Arrange - setup
            var number = 42;
            var anotherNumber = 74;

            // Act - doen
            _sut.Add(number); // interne state via andere methode instellen: black
            //_sut.Result = number; // interne state instellen: white
            _sut.Multiply(anotherNumber);

            // Assert - toetsen
            Assert.AreEqual(number * anotherNumber, _sut.Result);
        }

        [DataTestMethod]
        [DataRow(2, 4, 6, 12)]
        [DataRow(-2, -4, -6, -12)]
        [DataRow(-2, 4, -6, -4)]
        public void MyTestMethod(int p1, int p2, int p3, int expectedResult)
        {
            _sut.Add(p1);
            _sut.Add(p2);
            _sut.Add(p3);

            Assert.AreEqual(expectedResult, _sut.Result);
        }
    }
}
