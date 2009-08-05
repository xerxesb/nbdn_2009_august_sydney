using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<DepartmentItem> get_all_main_departments();
        IEnumerable<DepartmentItem> get_all_subdepartments_in(Id<long> department_id);
        IEnumerable<ProductItem> get_all_products_in(Id<long> department_id);
    }
}