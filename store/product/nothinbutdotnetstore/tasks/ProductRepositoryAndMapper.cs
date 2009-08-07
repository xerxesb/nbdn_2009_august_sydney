using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.tasks
{
    public class ProductRepositoryAndMapper : CatalogRepositoryAndMapper<ProductRepository, ProductItemMapper>
    {
        public ProductRepositoryAndMapper(ProductRepository departments, ProductItemMapper products)
        {
            this.departments = departments;
            this.products = products;
        }

        public ProductRepository departments { get; private set; }
        public ProductItemMapper products { get; private set; }
    }
}