using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<DepartmentItem> get_all_main_departments()
        {
            return Enumerable.Range(1, 10).Select(number => new DepartmentItem { name = number.ToString("Department 0") });
        }

        public IEnumerable<DepartmentItem> get_all_subdepartments_in(Id<long> department_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductItem> get_all_products_in(Id<long> department_id)
        {
            throw new NotImplementedException();
        }
    }
}