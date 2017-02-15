using FFY.Data;
using FFY.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContextIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [Test]
        public void ShouldThrowExceptionWithCorrectMessage_WhenNullContextIsPassed()
        {
            var expectedExMessage = "Context cannot be null.";

            var exception = Assert.Throws<ArgumentNullException>(() => new UnitOfWork(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }
    }
}
