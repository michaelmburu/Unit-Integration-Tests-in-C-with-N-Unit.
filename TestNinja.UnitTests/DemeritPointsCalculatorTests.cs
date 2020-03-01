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
    public class DemeritPointsCalculatorTests
    {
        public DemeritPointsCalculator demeritPointsCalculator;
        [SetUp]
        public void Setup()
        {
            //Arrange
            demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        public void CalculateDemeritPoints_IfSpeedIsLessThan0_ThrowArgumentOutOfRangeException()
        {
             //Act
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => demeritPointsCalculator.CalculateDemeritPoints(-1));

            //Assert
            Assert.That(result, Is.TypeOf<ArgumentOutOfRangeException>());
        }


        [Test]
        public void CalculateDemeritPoints_IfSpeedIsGreaterThanMaxSpeed_ThrowArgumentOutOfRangeException()
        {
            //Act
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => demeritPointsCalculator.CalculateDemeritPoints(400));

            //Assert
            Assert.That(result, Is.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(20,0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_IfSpeedIsLessThanOrEqualToSpeedLimit_Return0(int speed,int result)
        {
            //Act
           demeritPointsCalculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_IfSpeedIsNotGreaterThanSpeedLimit_ReturnSpeedMinusSpeedLimit()
        {
            //Act
            var result = demeritPointsCalculator.CalculateDemeritPoints(85);

            //Assert
            Assert.That(result, Is.EqualTo(4));

        }

       


    }
}
