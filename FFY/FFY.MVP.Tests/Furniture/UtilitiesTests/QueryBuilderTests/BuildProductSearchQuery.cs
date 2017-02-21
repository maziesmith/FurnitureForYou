using FFY.MVP.Furniture.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFY.MVP.Tests.Furniture.UtilitiesTests.QueryBuilderTests
{
    [TestFixture]
    public class BuildProductSearchQuery
    {
        [TestCase("/all", "table", "5", "10", "/all?search=table&from=5&to=10")]
        [TestCase("/all", "table", "5", "", "/all?search=table&from=5")]
        [TestCase("/all", "table", "", "", "/all?search=table")]
        [TestCase("/all", "", "5", "10", "/all?from=5&to=10")]
        [TestCase("/all", "", "5", "", "/all?from=5")]
        [TestCase("/all", "", "", "10", "/all?to=10")]
        [TestCase("/all", "", "", "", "/all")]
        [TestCase("", "", "", "", "")]
        public void ShouldReturnCorrectQueryBasedOnParameters(string path, string search, string from, string to, string expected)
        {
            // Arrange
            var queryBuilder = new QueryBuilder();

            // Act
            var actual = queryBuilder.BuildProductSearchQuery(path, search, from, to);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
