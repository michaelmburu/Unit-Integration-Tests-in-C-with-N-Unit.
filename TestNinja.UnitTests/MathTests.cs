﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math math;

        //Setup
        [SetUp]
        public void Setup()
        {
            math = new Math();
        }

        //TearDown

        [Test]
        //[Ignore("Ignored for now")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            //Arrange
            //var math = new Math();

            //Act
            var result = math.Add(1, 2);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenFirstArgumentIsGreater_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            //Arrange
            var max = new Math();
            //Act
            var result = max.Max(a, b);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //[Test]
        //public void Max_WhenSecondArgumentIsGreater_ReturnSecondArgument()
        //{
        //    //Arrange
        //    //var math = new Math();
        //    //Act
        //    var result = math.Max(1, 2);
        //    //Assert
        //    Assert.That(result, Is.EqualTo(2));
        //}

        //[Test]
        //public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        //{
        //    //Arrange
        //    //var math = new Math();
        //    //Act
        //    var result = math.Max(1, 1);
        //    //Assert
        //    Assert.That(result, Is.EqualTo(1));
        //}

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            //Act
            var result = math.GetOddNumbers(5);
            //Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);

        }
    }
}
