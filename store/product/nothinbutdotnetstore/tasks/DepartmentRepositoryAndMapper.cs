using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.tasks
{
    public class DepartmentRepositoryAndMapper : CatalogRepositoryAndMapper<DepartmentRepository, DepartmentItemMapper>
    {
        public DepartmentRepositoryAndMapper(DepartmentRepository departments, DepartmentItemMapper products)
        {
            this.departments = departments;
            this.products = products;
        }

        public DepartmentRepository departments { get; private set; }
        public DepartmentItemMapper products { get; private set; }
    }
}