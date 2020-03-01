using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Mock<IStorage> _storage;
        private OrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _storage = new Mock<IStorage>();
            _orderService = new OrderService(_storage.Object);
        }

        [Test]
        public void PlaceHolder_WhenCalled_StoreOrder()
        {
            //Act
            var order = new Order();
            _storage.Setup(o => o.Store(order));
            _orderService.PlaceOrder(order);

            //Assert
            _storage.Verify(s => s.Store(order));
        }

    }
}
