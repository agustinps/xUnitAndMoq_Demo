using ProductsApi.Domain.Entities;
using ProductsApi.Domain.Interfaces;
using ProductsApi.Infrastructure.Data;

namespace ProductsApi.Infrastructure.Repository
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<bool> UpdateSupplier(int id, string supplier)
        {
            if (string.IsNullOrEmpty(supplier))
                throw new ArgumentNullException("Proveedor no indicado");
            var product = await this.GetByIdAsync(id);
            if (product == null)
                return false;
            product.Supplier = supplier;            
            return await this.SaveChangesAsync();
        }
    }
}
