using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.frontcontroller;
using nothinbutdotnetstore.web.models;
using nothinbutdotnetstore.web.services;
using nothinbutdotnetstore.web.services.viewmaindepartments;

namespace nothinbutdotnetstore.web.commands
{
    public class ViewMainDepartmentsCommand : RawRequestCommand
    {
        DepartmentRegistry department_registry;
        DisplayEngine display_engine;


        public ViewMainDepartmentsCommand(DepartmentRegistry department_registry, DisplayEngine display_engine)
        {
            this.department_registry = department_registry;
            this.display_engine = display_engine;
        }

        public void process(IncomingRequest request)
        {
            display_engine.display(department_registry.get_main_departments());
        }
    }
}