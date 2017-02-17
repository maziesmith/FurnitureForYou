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

namespace FFY.Tests.Data.GenericRepositoryTests
{
    [TestFixture]
    public class GetAll
    {
        [Test]
        public void ShouldReturnDbSetAsIEnumerable()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel(),
                new MockedModel()
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll();

            Assert.AreEqual(data.ToList(), result);
        }

        [Test]
        public void ShouldReturnEmptyDbSetAsIEnumerable_WhenFilterExpressionDoesNotMatch()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel(),
                new MockedModel()
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(o => o.Id == 42);

            Assert.AreEqual(0, result.Count());
        }

        [TestCase(42, "NotName", 2)]
        [TestCase(24, "Name", 2)]
        [TestCase(0, "NotNotName", 0)]
        public void ShouldReturnCorrectAmountOfModels_WhenFilterExpressionMatches(int id, string name, int expectedCount)
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 24,  Name = "Name" },
                new MockedModel() { Id = 42, Name = "Name"},
                new MockedModel() { Id = 42, Name="NotName" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(o => o.Id == id || o.Name == name);

            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void ShouldReturnSortedDbSet_WhenSortExpressionIsPassed()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(null, s => s.Id).ToList();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(result[0].Name, "One");
            Assert.AreEqual(result[1].Name, "Two");
            Assert.AreEqual(result[2].Name, "Four");
        }

        [Test]
        public void ShouldReturnFilteredAndSortedDbSet_WhenFilterAndSortExpressionsArePassed()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(f => f.Id < 3, s => s.Id).ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(result[0].Name, "One");
            Assert.AreEqual(result[1].Name, "Two");
        }

        [Test]
        public void ShouldReturnSelectedValues_WhenSelectExpressionIsPassed()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll<int, string>(null, null, m => m.Name).ToList();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(result[0], "Two");
            Assert.AreEqual(result[1], "Four");
            Assert.AreEqual(result[2], "One");
        }

        [Test]
        public void ShouldReturnSelectedAndSortedValues_WhenSelectAndSortExpressionArePassed()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll<int, string>(null, s => s.Id, m => m.Name).ToList();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(result[0], "One");
            Assert.AreEqual(result[1], "Two");
            Assert.AreEqual(result[2], "Four");
        }

        [Test]
        public void ShouldReturnFilteredSelectedAndSortedValues_WhenFilterSelectAndSortExpressionArePassed()
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" },
                new MockedModel() { Id = 3, Name="Three" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll<int, string>(f => f.Id < 3, s => s.Id, m => m.Name).ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(result[0], "One");
            Assert.AreEqual(result[1], "Two");
        }

        [TestCase(1)]
        [TestCase(3)]
        public void ShouldReturnCorrectAmountOfElements_WhenTakeParameterIsPassed(int take)
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" },
                new MockedModel() { Id = 3, Name="Three" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(null, null, take).ToList();

            Assert.AreEqual(take, result.Count());
        }

        [Test]
        public void ShouldReturnCorrectElements_WhenTakeParameterIsPassed()
        {
            int take = 3;
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" },
                new MockedModel() { Id = 3, Name="Three" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(null, null, take).ToList();

            Assert.AreEqual(take, result.Count());
            Assert.AreEqual(result[0].Name, "Two");
            Assert.AreEqual(result[1].Name, "Four");
            Assert.AreEqual(result[2].Name, "One");
        }

        [TestCase(1)]
        [TestCase(3)]
        public void ShouldSkipCorrectAmountOfElements_WhenSkipParameterIsPassed(int skip)
        {
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" },
                new MockedModel() { Id = 3, Name="Three" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(null, skip).ToList();

            Assert.AreEqual(data.Count() - skip, result.Count());
        }

        [Test]
        public void ShouldSkipAndReturnCorrectElements_WhenSkipParameterIsPassed()
        {
            int skip = 2;
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" },
                new MockedModel() { Id = 3, Name="Three" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(null, skip).ToList();

            Assert.AreEqual(data.Count() - skip, result.Count());
            Assert.AreEqual(result[0].Name, "One");
            Assert.AreEqual(result[1].Name, "Three");
        }

        [Test]
        public void ShouldSkipAndReturnCorrectElements_WhenSkipAndTakeParameterIsPassed()
        {
            int skip = 1;
            int take = 2;
            var mockedContext = new Mock<IFFYContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var data = new List<MockedModel>()
            {
                new MockedModel() { Id = 2,  Name = "Two" },
                new MockedModel() { Id = 4, Name = "Four"},
                new MockedModel() { Id = 1, Name="One" },
                new MockedModel() { Id = 3, Name="Three" }
            }.AsQueryable();

            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<MockedModel>>().Setup(m => m.ElementType).Returns(data.ElementType);

            var genericRepository = new GenericRepository<MockedModel>(mockedContext.Object);

            var result = genericRepository.GetAll(null, skip, take).ToList();

            Assert.AreEqual(take, result.Count());
            Assert.AreEqual(result[0].Name, "Four");
            Assert.AreEqual(result[1].Name, "One");
        }
    }
}
