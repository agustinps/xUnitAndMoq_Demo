using System.Data.SqlClient;

namespace AsyncLifeTimeDemoTest
{

    /// <summary>
    /// Utilizamos el accesorio creado en DatabaseFixture para crear una base de datos que se creará y eliminará al comenzar y terminar las pruebas respectivamente.
    /// Además añadimos la interfaz IAsyncLifeTime que nos permite ejecutar tareas asincronas en la incialización y destrucción.
    /// </summary>
    public class ConnectionTests : IClassFixture<DatabaseFixture>, IAsyncLifetime
    {
        private readonly DatabaseFixture _fixture;

        private readonly SqlConnection _connection;

        public ConnectionTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _connection = new SqlConnection(_fixture.ConnectionString);
        }

        public async Task InitializeAsync()
        {
            await _connection.OpenAsync();
        }

        public async Task DisposeAsync()
        {
            await _connection.DisposeAsync();
        }

        [Fact]
        public async Task Can_Connect()
        {
            //Arrange
            using var cmd = _connection.CreateCommand();
            cmd.CommandText = "SELECT 1";

            //Act
            var result = await cmd.ExecuteScalarAsync();

            //Assert
            Assert.Equal(1, result);
        }
    }
}
