using Microsoft.AspNetCore.Mvc;
using ProductsApi.Domain.Entities;
using ProductsApi.Domain.Interfaces;

namespace ProductsApi.Controllers
{

    /// <summary>    
    /// Controlador de producto, NUNCA deberíamos acceder a la entidad Product desde aquí, deberíamos utilizar DTOs y ayudarnos de Automapper, 
    /// pero al ser un ejemplo para Moq lo hacemos por simplicidad.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync() => Ok(await productRepository.GetAllAsync());

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product is null)
                return NotFound("Registro no existe");
            return Ok(product);
        }

        [HttpDelete("[action]/{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id) => Ok(await productRepository.DeleteAsync(id));
            

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateAsync([FromBody] Product product)
        {
            int idProduct = await productRepository.AddAsync(product);
            return CreatedAtAction("GetById", new { id = idProduct }, product);
        }

        [HttpPatch("[action]")]
        public async Task<ActionResult<bool>> UpdateSupplierAsync(int id, string supplier) => Ok(await productRepository.UpdateSupplier(id, supplier));
        
    }
}
