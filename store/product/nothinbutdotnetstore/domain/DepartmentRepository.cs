using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.domain
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> all_main_departments();
        IEnumerable<Department> all_sub_departments_in(Id<long> department_id);
    }
}