using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.domain
{
    public interface ProductRepository
    {
        IEnumerable<Product> all_products_in(Id<long> department_id);
    }
}