using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.frontcontroller;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartments : RawRequestCommand
    {
        DisplayEngine display_engine;
        CatalogTasks catalog_tasks;


        public ViewMainDepartments(DisplayEngine display_engine, CatalogTasks catalog_tasks)
        {
            this.display_engine = display_engine;
            this.catalog_tasks = catalog_tasks;
        }

        public void process(IncomingRequest request)
        {
            display_engine.display(catalog_tasks.get_all_main_departments());
        }
    }
}