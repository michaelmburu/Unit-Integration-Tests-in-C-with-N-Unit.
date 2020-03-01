using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {

        [Test]
        public void GetOutput_InputDivisibleBy3And5_ReturnsFizzBuzz()
        {
            //Act
            var result = FizzBuzz.GetOutput(15);

            //Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));

        }

        [Test]
        public void GetOutput_InputDivisibleBy3_ReturnsFizz()
        {
            //Act
            var result = FizzBuzz.GetOutput(9);

            //Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputDivisibleBy5_ReturnsBuzz()
        {
            //Act
            var result = FizzBuzz.GetOutput(10);

            //Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy5Or3_ReturnsSameNumber()
        {
            //Act
            var result = FizzBuzz.GetOutput(2);

            //Assert
            Assert.That(result, Is.EqualTo("2"));
        }
    }
}
