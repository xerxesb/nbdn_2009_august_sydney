using System;
using System.Collections.Generic;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<DepartmentItem> get_all_main_departments()
        {
            throw new NotImplementedException();
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