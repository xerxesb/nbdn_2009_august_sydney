using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.frontcontroller;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewProductsInDepartments : RawRequestCommand
    {
        DisplayEngine display_engine;
        CatalogTasks catalog_tasks;

        public ViewProductsInDepartments(DisplayEngine display_engine, CatalogTasks catalog_tasks)
        {
            this.display_engine = display_engine;
            this.catalog_tasks = catalog_tasks;
        }

        public void process(IncomingRequest request)
        {
            display_engine.display(catalog_tasks.get_all_products_in(request.map<Id<long>>()));
        }
    }
}