using FFY.Data;
using FFY.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Data.GenericRepository
{
    [TestFixture]
    public class GetById
    {
        [TestCase(42)]
        public void ShouldCallFindMethodOfSet(object id)
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            genericRepository.GetById(id);

            mockedSet.Verify(s => s.Find(It.IsAny<object>()), Times.Once);
        }

        [TestCase(42)]
        [TestCase("testcase")]
        public void ShouldCallFindMethodOfSetWithCorrectId(object id)
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            repository.GetById(id);

            mockedSet.Verify(x => x.Find(id), Times.Once);
        }

        [TestCase(42)]
        public void ShouldReturnTheCorrectResult(object id)
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedModel = new MockedModel();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Returns(mockedModel);

            var repository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = repository.GetById(id);

            Assert.AreEqual(mockedModel, result);
        }
    }
}
