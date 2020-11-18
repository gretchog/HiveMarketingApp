using DataProvider;
using Moq;
using System;
using Xunit;

namespace UnitTests
{
    public class DBProviderTests
    {
        private IDBProvider InstantiateDbProvider()
        {
            return new MongoDBProvider();
        }

        [Fact]
        public void RetrievePointsOfInterest()
        {
            // Arrange
            var dbProvider = InstantiateDbProvider();

            // Act
            var result = dbProvider.RetrievePointsOfInterest();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count == 429);
            Assert.NotNull(result.Find(x => x.Id == 1516325));
        }

        // Bad test - doesn't actually test DBProvider throwing an error, just that we can mock it. Solution would be to have an injectable
        // config to DBProvider and throw a bad config into it, so we can test that it throws given a bad config. Also throw a specific exception instead of generic.
        [Fact]
        public void HandleDBNotAvailable()
        {
            // Arrange
            var mockDb = new Mock<IDBProvider>();
            mockDb.Setup(x => x.RetrievePointsOfInterest()).Throws(It.IsAny<Exception>());

            // Act

            // Assert
            Assert.Throws<Exception>(() => mockDb.Object.RetrievePointsOfInterest());
        }

        [Fact]
        public void DBProviderInitialisesOnCreation()
        {
            // Arrange

            // Act
            var dbProvider = InstantiateDbProvider();
            var result = dbProvider.RetrievePointsOfInterest();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count == 429);
            Assert.NotNull(result.Find(x => x.Id == 1516325));
        }
    }
}
