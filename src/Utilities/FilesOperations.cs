namespace Utilities
{
    public static class FilesOperations
    {
        /// <summary>
        /// Nos indica si los ficheros pasados por parametro se encuentran en el directorio indicado. 
        /// Except devuelve los elementos que estan en el primer conjunto 'files' pero no del segundo 'filesInDir'
        /// si no devuelve ninguno es que todos los archivos estan en el directorio y devolvemos true, en caso contrario devolvemos false
        /// Esta clase sirve para las pruebas en el proyecto xUnit FixtureDemoTest
        /// </summary>
        /// <param name="files"> conjunto de ficheros a verificar que existen en el directorio indicado </param>
        /// <param name="directory"> directorio en el que buscar los ficheros indicados </param>
        /// <returns></returns>
        public static bool FilesInDirectory(string[] files, string directory)
        {
            var dir = new DirectoryInfo(directory);
            if (!dir.Exists)
                return false;

            //obtenemos los nombres de los ficheros del directorio indicado para comparar con el parametro files
            var filesInDir = dir.GetFiles().Select(f => f.Name);            

            return !files.Except(filesInDir).Any();
        }




    }
}
