using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface DepartmentItemMapper
    {
        DepartmentItem map_from(Department department);
    }
}