namespace FixtureDemoTest.Fixtures
{

    /// <summary>
    /// clase para crear un directorio y ficheros que se eliminaran al terminar la prueba
    /// </summary>
    public class DirectoryFixture : IDisposable
    {
        private const string DIRECTORY = "./test";
        private const int FILECOUNT = 10;
        private readonly string[] files = new string[FILECOUNT];


        public string[] Files => files;
        public string MyDirectory => DIRECTORY;


        /// <summary>
        /// En el constructor creamos el directorio y los ficheros que buscaremos para probar el método FilesInDirectory de la clase FileOperations
        /// </summary>
        public DirectoryFixture()
        {
            if (!Directory.Exists(DIRECTORY))
                Directory.CreateDirectory(DIRECTORY);

            for (int i = 0; i < FILECOUNT; i++)
            {
                var file = $"{i}.prueba";
                files[i] = file;
                File.WriteAllText(Path.Combine(DIRECTORY, file), "some text");
            }
        }


        /// <summary>
        /// Eliminamos los recursos, en nuestro caso, borrar el directorio creado para las pruebas
        /// </summary>
        public void Dispose()
        {
            if (Directory.Exists(DIRECTORY))
                Directory.Delete(DIRECTORY, true);
        }
    }
}
