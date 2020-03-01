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
    public class ErrorLoggerTests
    {
        //Arrange
        public ErrorLogger logger { get; set; }
        [SetUp]
        public void Setup()
        {
            logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetLastErrorProperty()
        {
            //Act
            logger.Log("a");

            //Assert
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {

            //Assert
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLog()
        {
            //Arrange
            var id = new Guid();
            //Act
            logger.ErrorLogged += (sender, args) => { id = args; };
            logger.Log("a");

            //Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

    }
}
