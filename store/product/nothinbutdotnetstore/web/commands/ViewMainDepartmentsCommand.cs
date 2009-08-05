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
        readonly PresenterFactory presenter_factory;
        readonly ViewFactory view_factory;
        readonly ViewModelFactory view_model_factory;
        readonly DepartmentRegistry department_registry;


        public void process(IncomingRequest request)
        {
            var departments = department_registry.get_main_departments();
            var view_model = view_model_factory.create(departments);
            var view = view_factory.create();
            var presenter = presenter_factory.create(view_model, view);
            presenter.show();
        }

        public ViewMainDepartmentsCommand(PresenterFactory presenter_factory, ViewFactory view_factory, ViewModelFactory view_model_factory, DepartmentRegistry department_registry)
        {
            this.presenter_factory = presenter_factory;
            this.view_factory = view_factory;
            this.view_model_factory = view_model_factory;
            this.department_registry = department_registry;
        }
    }
}