using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tests.utility;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
{
    public class CatalogTasksSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<CatalogTasks,
                                            CatalogTasksImplementation> {}

        [Concern(typeof (CatalogTasks))]
        public class when_getting_all_of_the_main_departments_in_the_store : concern
        {
            it should_return_the_list_of_main_department_items = () =>
            {
                results.should_contain(mapped_department_item);
            };

            because b = () =>
            {
                results = sut.get_all_main_departments();
            };

            context c = () =>
            {
                main_department = an<Department>();
                mapped_department_item = new DepartmentItem();
                the_main_departments = ObjectMother.create_enumerable_from(main_department);

                department_repository = the_dependency<DepartmentRepository>();
                department_item_mapper = the_dependency<DepartmentItemMapper>();
                department_repository.Stub(x => x.all_main_departments()).Return(the_main_departments);
                department_item_mapper.Stub(x => x.map_from(main_department)).Return(mapped_department_item);
            };


            static IEnumerable<DepartmentItem> results;
            static DepartmentItem mapped_department_item;
            static DepartmentRepository department_repository;
            static IEnumerable<Department> the_main_departments;
            static Department main_department;
            static DepartmentItemMapper department_item_mapper;
        }
    }
}