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
    public class Commit
    {
        [Test]
        public void ShouldCallSaveChangesOnDbContext()
        {
            var mockedContext = new Mock<IFFYContext>();
            mockedContext.Setup(x => x.SaveChanges()).Verifiable();
            var unifOfWork = new UnitOfWork(mockedContext.Object);

            unifOfWork.Commit();

            mockedContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
