using FixtureDemoTest.Fixtures;
using Utilities;

namespace FixtureDemoTest._2_CollectionFixtureTest
{
    [Collection("CollectionDirectory")]
    public class FilesOperationsCollectionFixtureTest1
    {
        private readonly DirectoryFixture directoryFixture;

        public FilesOperationsCollectionFixtureTest1(DirectoryFixture directoryFixture)
        {
            this.directoryFixture = directoryFixture;
        }


        [Fact]
        public void FilesInDirectory_ShouldBeTrue_IfFilesExits()
        {
            //Arrange

            //Act
            var result = FilesOperations.FilesInDirectory(directoryFixture.Files, directoryFixture.MyDirectory);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void FilesInDirectory_ShouldBeFalse_IfFilesNotExits()
        {
            //Arrange

            //Act
            var result = FilesOperations.FilesInDirectory(new string[] { "file1.prueba" }, directoryFixture.MyDirectory);

            //Assert
            Assert.False(result);
        }


    }
}
