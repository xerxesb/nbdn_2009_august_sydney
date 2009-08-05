using System.Collections.Generic;
using nothinbutdotnetstore.web.models;

namespace nothinbutdotnetstore.web.services.viewmaindepartments
{
    public interface DepartmentRegistry
    {
        IEnumerable<Department> get_main_departments();
    }
}