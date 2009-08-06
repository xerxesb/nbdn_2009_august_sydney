 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core.frontcontroller;
 using developwithpassion.bdd.mbunit;

namespace nothinbutdotnetstore.tests.web
 {   
     public class WebFormViewRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<WebFormViewRegistry,
                                             WebFormViewRegistryImplementation>
         {
        
         }

         [Concern(typeof(WebFormViewRegistryImplementation))]
         public class when_getting_view_information_for_a_view_model : concern
         {
             it should_return_view_information_for_the_view_model = () =>
             {                 
                 result.type.should_be_equal_to(view_information.type);
                 result.path.should_be_equal_to(view_information.path);
             };

             because b = () =>
             {
                 result = sut.get_view_information_for<int>();
             };

             context c = () =>
             {
                 view_information = new WebFormViewInformation("some_path", typeof (string));
                 mappings = new Dictionary<Type, WebFormViewInformation>();
                 mappings.Add(typeof (int), view_information);
                 provide_a_basic_sut_constructor_argument(mappings);
             };

             static WebFormViewInformation result;
             static WebFormViewInformation view_information;
             static IDictionary<Type, WebFormViewInformation> mappings;
         }

         [Concern(typeof(WebFormViewRegistryImplementation))]
         public class when_getting_view_information_for_a_non_registered_view_model : concern
         {
             it should_throw_an_exception = () =>
             {
                 var exception = exception_thrown_by_the_sut.should_be_an_instance_of<WebFormViewInformationNotMappedException>();
                 exception.type_not_mapped.should_be_equal_to(typeof(int));
             };

             because b = () =>
             {
                doing(() => sut.get_view_information_for<int>());
             };

             context c = () =>
             {
                 mappings = new Dictionary<Type, WebFormViewInformation>();
                 provide_a_basic_sut_constructor_argument(mappings);
             };

             static IDictionary<Type, WebFormViewInformation> mappings;
         }
     }
 }
