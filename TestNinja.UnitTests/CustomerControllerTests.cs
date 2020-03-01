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
    public class CustomerControllerTests
    {
        [Test]
        public void CustomerController_IdIsZero_ReturnNotFound()
        {
            //Arrange
            var customerController = new CustomerController();

            //Act
            var result = customerController.GetCustomer(0);

            //Assert

            //Not Found
            Assert.That(result, Is.TypeOf<NotFound>());
            //Not FOund Or One Of its Derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void CustomerController_IdIsNotZero_ReturnOK()
        {
            //Arrange
            var customerController = new CustomerController();
            //Act
            var result = customerController.GetCustomer(1);
            //Assert
            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}
