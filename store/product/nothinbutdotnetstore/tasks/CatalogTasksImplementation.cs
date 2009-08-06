using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks
{
    public class CatalogTasksImplementation : CatalogTasks
    {
        DepartmentRepository department_repository;
        DepartmentItemMapper departmentItemMapper;
        
        public CatalogTasksImplementation(DepartmentRepository department_repository, DepartmentItemMapper departmentItemMapper)
        {
            this.department_repository = department_repository;
            this.departmentItemMapper = departmentItemMapper;
        }

        public IEnumerable<DepartmentItem> get_all_main_departments()
        {
            var departments = department_repository.all_main_departments();
            return departments.Select(d => departmentItemMapper.map_from(d));
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