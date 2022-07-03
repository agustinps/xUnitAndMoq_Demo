using FixtureDemoTest.Fixtures;
using Utilities;

namespace FixtureDemoTest._2_CollectionFixtureTest
{
    [Collection("CollectionDirectory")]
    public class FilesOperationsCollectionFixture_2
    {
        private readonly DirectoryFixture directoryFixture;

        public FilesOperationsCollectionFixture_2(DirectoryFixture directoryFixture)
        {
            this.directoryFixture = directoryFixture;
        }


        [Fact]
        public void FilesInDirectory_ShouldBeFalse_IfDirectoryNotExits()
        {
            //Arrange

            //Act
            var result = FilesOperations.FilesInDirectory(directoryFixture.Files, "OtroDirectorio");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void FilesInDirectory_ShouldThrowArgumentNullException_IfDirectoryIsNull()
        {
            //Arrange

            //Act
            Action act = () =>
            {
                FilesOperations.FilesInDirectory(directoryFixture.Files, null);
            };

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void FilesInDirectory_ShouldThrowArgumentNullException_IfFilesIsNull()
        {
            //Arrange

            //Act
            Action act = () =>
            {
                FilesOperations.FilesInDirectory(null, directoryFixture.MyDirectory);
            };

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }


    }
}
