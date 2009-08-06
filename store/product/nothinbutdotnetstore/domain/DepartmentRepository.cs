using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> all_main_departments();
    }
}