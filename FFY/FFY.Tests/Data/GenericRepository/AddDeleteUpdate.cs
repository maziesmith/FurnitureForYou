using FFY.Data;
using FFY.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.Tests.Data.GenericRepository
{
    [TestFixture]
    public class AddDeleteUpdate
    {
        // Parent does not have a default constructor | Not sure how to work it around
        // Possible change in repository or find way to test it
        // Same for add/delete/update
        // [Test]
        public void ShouldChangeEntityStateToAdded()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();

            var mockedModel = new MockedModel();
            var mockedEntry = new Mock<DbEntityEntry<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedContext.Setup(x => x.Entry(It.IsAny<MockedModel>())).Returns(mockedEntry.Object);
            mockedEntry.SetupSet(x => x.State = It.IsAny<EntityState>()).Verifiable();

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            mockedEntry.VerifySet(x => x.State = EntityState.Added);
        }
    }
}
