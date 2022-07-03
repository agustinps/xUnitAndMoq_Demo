using FixtureDemoTest.Fixtures;

namespace FixtureDemoTest._2_CollectionFixtureTest
{

    /// <summary>
    /// Clase utilizada para definir la colección
    /// </summary>
    
    [CollectionDefinition("CollectionDirectory")]
    public class DefinitionCollectionFixture : ICollectionFixture<DirectoryFixture>
    {
    }
}
