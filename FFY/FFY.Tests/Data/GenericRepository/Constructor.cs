using FFY.Data;
using FFY.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Data.GenericRepository
{
    [TestFixture]
    public class Constructor
    {
        [Test]
        public void ShouldThrowArgumentNullException_WhenNullContextIsPassed()
        {
            var expectedExMessage = "Value cannot be null.";


            var exception = Assert.Throws<ArgumentNullException>(() =>
            new GenericRepository<MockedModel>(null));
            StringAssert.Contains(expectedExMessage, exception.Message);
        }

        [Test]
        public void ShouldSetContextCorrectly_WhenValidContextIsPassed()
        {
            var mockedContext = new Mock<IFFYContext>();

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            Assert.AreSame(mockedContext.Object, genericRepository.Context);
        }

        [Test]
        public void ShouldSetDbSetCorrectly_WhenValidContextIsPassed()
        {
            var mockedContext = new Mock<IFFYContext>();

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            Assert.AreSame(mockedContext.Object.Set<MockedModel>(), genericRepository.Set);
        }

        [Test]
        public void ShouldCallSetMethodOfContext_WhenValidContextIsPassed()
        {
            var mockedContext = new Mock<IFFYContext>();

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            mockedContext.Verify(c => c.Set<MockedModel>(), Times.Once);
        }
    }
}
