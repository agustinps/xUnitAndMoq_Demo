using FixtureDemoTest.Fixtures;
using Utilities;

namespace FixtureDemoTest._1_ClassFixtureTest
{

    /// <summary>
    /// Creamos un accesorio de tipo ClassFixture<T> heredando de la clase IClassFixture y usamos para particulizar el genérico, nuestra clase DirectoryFixture.
    /// El runner de xUnit nos permite inyectar esta clase en el constructor, por lo que podremos utilizarlo en toda la clase.
    /// Ahora nuestro accesorio se ejecutará al comienzo de la prueba y se destruirá al terminar la última.
    /// </summary>
    public class FilesOperationsClassFixtureTest : IClassFixture<DirectoryFixture>
    {
        private readonly DirectoryFixture directoryFixture;

        public FilesOperationsClassFixtureTest(DirectoryFixture directoryFixture)
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
            var result = FilesOperations.FilesInDirectory(new string[] {"file1.prueba" }, directoryFixture.MyDirectory);

            //Assert
            Assert.False(result);
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
