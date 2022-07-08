using ProductsApi.Domain.Entities;

namespace ProductsApi.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {

        //Métodos específicos de la entidad product

        Task<bool> UpdateSupplier(int id, string supplier);
    }

}
