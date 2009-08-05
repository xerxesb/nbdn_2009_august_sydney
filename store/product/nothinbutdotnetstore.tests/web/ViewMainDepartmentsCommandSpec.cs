using System.Collections;
using System.Collections.Generic;
using developwithpassion.bdd;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.commands;
using nothinbutdotnetstore.web.frontcontroller;
using nothinbutdotnetstore.web.models;
using nothinbutdotnetstore.web.presenters;
using nothinbutdotnetstore.web.services;
using nothinbutdotnetstore.web.services.viewmaindepartments;
using nothinbutdotnetstore.web.viewmodels;
using nothinbutdotnetstore.web.views;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewMainDepartmentsCommandSpec
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RawRequestCommand,
                                            ViewMainDepartmentsCommand>
        {

        }

        [Concern(typeof(ViewMainDepartmentsCommand))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                mock_request = an<IncomingRequest>();
                view = an<View>();
                view_model = an<ViewModel>();
                web_presenter = an<Presenter>();
                departments = an<IEnumerable<Department>>();

                main_departments_lister = the_dependency<DepartmentRegistry>();

                view_model_factory = the_dependency<ViewModelFactory>();
                view_model_factory.Stub(x => x.create(departments)).Return(view_model);

                view_factory = the_dependency<ViewFactory>();
                view_factory.Stub(x => x.create()).Return(view);

                presenter_factory = the_dependency<PresenterFactory>();
                presenter_factory.Stub(x => x.create(view_model, view)).Return(web_presenter);

                main_departments_lister.Stub(x => x.get_main_departments()).Return(departments);
            };

            because b = () =>
            {
                sut.process(mock_request);
            };


            it should_get_a_list_of_main_departments = () =>
            {
                main_departments_lister.received(x => x.get_main_departments());
            };

            it should_create_a_view_model = () =>
            {
                view_model_factory.received(x => x.create(departments));
            };

            it should_create_a_view = () => 
            {
                view_factory.received(x => x.create());
            };

            it should_create_a_presenter = () =>
            {
                presenter_factory.received(x => x.create(view_model, view));
            };

            it should_call_show_on_the_presenter = () => 
            {
                web_presenter.received(x => x.show());
            };


            static DepartmentRegistry main_departments_lister;
            static IncomingRequest mock_request;
            static ViewModelFactory view_model_factory;
            static IEnumerable<Department> departments;
            static ViewFactory view_factory;
            static View view;
            static ViewModel view_model;
            static Presenter web_presenter;
            static PresenterFactory presenter_factory;
        }
    }

}
