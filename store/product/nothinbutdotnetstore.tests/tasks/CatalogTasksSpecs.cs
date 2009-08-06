using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.mbunit;
using developwithpassion.bdd.mbunit.standard.observations;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.infrastructure;
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

        [Concern(typeof (CatalogTasks))]
        public class when_getting_all_of_the_subdepartments_for_a_department : concern
        {
            it should_return_the_list_of_sub_department_items_in_the_department = () =>
            {
                results.should_contain(mapped_department_item);
            };

            because b = () =>
            {
                results = sut.get_all_subdepartments_in(department_id);
            };

            context c = () =>
            {
                sub_department = an<Department>();
                department_id = new Id<long>();
                mapped_department_item = new DepartmentItem();
                the_sub_departments = ObjectMother.create_enumerable_from(sub_department);

                department_repository = the_dependency<DepartmentRepository>();
                department_item_mapper = the_dependency<DepartmentItemMapper>();
                department_repository.Stub(x => x.all_sub_departments_in(department_id)).Return(the_sub_departments);
                department_item_mapper.Stub(x => x.map_from(sub_department)).Return(mapped_department_item);
            };


            static IEnumerable<DepartmentItem> results;
            static DepartmentItem mapped_department_item;
            static DepartmentRepository department_repository;
            static IEnumerable<Department> the_sub_departments;
            static Department sub_department;
            static DepartmentItemMapper department_item_mapper;
            static Id<long> department_id;
        }

        [Concern(typeof (CatalogTasks))]
        public class when_getting_all_of_the_products_in_a_department : concern
        {
            it should_return_a_list_of_the_products_in_the_department = () =>
            {
                results.should_contain(mapped_product_item);
            };

            because b = () =>
            {
                results = sut.get_all_products_in(department_id);
            };

            context c = () =>
            {
                product = an<Product>();
                department_id = new Id<long>();
                mapped_product_item = new ProductItem();
                the_products = ObjectMother.create_enumerable_from(product);

                product_repository = the_dependency<ProductRepository>();
                product_item_mapper = the_dependency<ProductItemMapper>();
                product_repository.Stub(x => x.all_products_in(department_id)).Return(the_products);
                product_item_mapper.Stub(x => x.map_from(product)).Return(mapped_product_item);
            };


            static IEnumerable<ProductItem> results;
            static ProductRepository product_repository;
            static IEnumerable<Product> the_products;
            static Product product;
            static ProductItemMapper product_item_mapper;
            static Id<long> department_id;
            static ProductItem mapped_product_item;
        }
    }
}