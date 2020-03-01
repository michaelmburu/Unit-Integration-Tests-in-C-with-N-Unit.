using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
 
        public Stack<int?> stack;
        [SetUp]
        public void SetUp()
        {
            stack = new Stack<int?>();
        }

        [Test]
        public void Push_CountObjectsInStack_ReturnsCount()
        {
            //Act
            stack.Push(1);
            stack.Push(2);

            //Assert
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Push_PushNullObjectToStack_ReturnsArgumentNullException()
        {
            int? num = null;
            //Assert
            Assert.That(() => stack.Push(num), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_PopItemFromStackWhenListIsZero_RemovesAndReturnsLastItemAddedToStack()
        {
            //Assert
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Push_PeekItemOnStackWhenListIsZero_ReturnsInvalidOperationException()
        {
            //Assert
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);

        }

        [Test]
        public void Push_PeekItemOnStackWhenListIsNotZero_ReturnsLatestItemOnStack()
        {
            //Act
            stack.Push(1);
            stack.Push(2);

            //Assert
            Assert.That(stack.Peek(), Is.EqualTo(2));

        }
    }
}
