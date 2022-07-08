using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductsApi.Controllers;
using ProductsApi.Domain.Entities;
using ProductsApi.Domain.Interfaces;

namespace MoqDemoTest
{

    /// <summary>
    /// Provamos algunos métodos cómo ejemplo de Moq sobre el controlador Products de nuestro api
    /// </summary>
    public class ProductControllerTest : IAsyncLifetime
    {
        private readonly Mock<IProductRepository> mockRespository;
        private readonly ProductsController controller;
        private IEnumerable<Product> products = new List<Product>();


        /// <summary>
        /// Creamos el objeto mock y el controlador
        /// </summary>
        public ProductControllerTest()
        {
            mockRespository = new Mock<IProductRepository>();
            controller = new ProductsController(mockRespository.Object);
        }


        /// <summary>
        /// Método dispose de la interfaz IAsynLifeTime
        /// </summary>        
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }       


        /// <summary>
        /// El método GetAll debe devolver una lista de productos
        /// </summary>        
        [Fact]
        public async Task GetAll_ShouldBeListOfProducts()
        {
            //Arrange            
                        

            //Act
            var actionResult = await controller.GetAllAsync();                        
            var result = (IEnumerable<Product>)((ObjectResult)actionResult.Result).Value;

            //Assert            
            Assert.Equal(products.Count(), result.Count());
        }


        /// <summary>
        /// el método GetById debe devolver un producto con el id indicado
        /// </summary>        
        [Fact]
        public async Task GetById_ShouldBeFirstProduct()
        {
            //Arrange            


            //Act
            var actionResult = await controller.GetByIdAsync(1);            
            var result = (Product)((ObjectResult)actionResult.Result).Value;

            //Assert            
            Assert.Equal(products.FirstOrDefault(), result);
        }

        /// <summary>
        /// El método UpdateSupplier debe ser verdadero si el id existe y se indica el nuevo supplier
        /// </summary>        
        [Fact]
        public async Task UpdateSupplier_ShouldBeTrue_IfIdExistsAndSuppierIsNotNull()
        {
            //Arrange

            //Act
            var actionResult = await controller.UpdateSupplierAsync(1, "Supplier X");
            var result = (bool)((ObjectResult)actionResult.Result).Value;

            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// El método UpdateSupplier debe ser false si el id No existe y se indica el nuevo supplier
        /// </summary>        
        [Fact]
        public async Task UpdateSupplier_ShouldBeFalse_IfIdNotExitsAndSupplierIsNotNull()
        {
            //Arrange            


            //Act
            var actionResult = await controller.UpdateSupplierAsync(-1, "Supplier X");
            var result = (bool)((ObjectResult)actionResult.Result).Value;

            //Assert            
            Assert.False(result);
        }

        /// <summary>
        /// El método UpdateSupplier debe devolver ArgumentNullException si no se indica el supplier
        /// </summary>        
        [Fact]
        public void UpdateSupplier_ShouldBeNullArgumentException_IfSupplierIsNull()
        {
            //Arrange

            //Act            
            async Task func() => await controller.UpdateSupplierAsync(1, String.Empty);

            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(func);  
        }


        /// <summary>
        /// Método inicializador asyncrono de la interfaz IAsyncLifeTime
        /// </summary>        
        public async Task InitializeAsync()
        {
            products = await GetProducts();            
            mockRespository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult<IEnumerable<Product>>(products));
            mockRespository.Setup(x => x.GetByIdAsync(1)).Returns(Task.FromResult(products.FirstOrDefault()));
            mockRespository.Setup(x => x.UpdateSupplier(1, "Supplier X")).Returns(Task.FromResult(true));
            mockRespository.Setup(x => x.UpdateSupplier(-1, "Supplier X")).Returns(Task.FromResult(false));
            mockRespository.Setup(x => x.UpdateSupplier(It.IsAny<int>(), string.Empty)).ThrowsAsync(new ArgumentNullException());
        }


        /// <summary>
        /// Método para crear una lista de productos para nuestra simulación
        /// </summary>        
        private async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> productList = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "producto 1",
                    Price = 30,
                    Stock = 1400,
                    Supplier = "proveedor 1"
                },
                new Product
                {
                    Id = 1,
                    Name = "product 2",
                    Price = 20,
                    Stock = 1200,
                    Supplier = "proveedor 2"
                },
                new Product
                {
                    Id = 1,
                    Name = "producto 3",
                    Price = 10,
                    Stock = 1000,
                    Supplier = "proveedor 3"
                }
            };
            return await Task.FromResult(productList);
        }
    }
}
