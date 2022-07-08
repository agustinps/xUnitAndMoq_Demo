namespace ProductsApi.Domain.Entities
{

    //Entidad producto que hereda de la entidad base
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Supplier { get; set; }
    }
}
