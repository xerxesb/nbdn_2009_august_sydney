using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface ProductItemMapper
    {
        ProductItem map_from(Product product);
    }
}