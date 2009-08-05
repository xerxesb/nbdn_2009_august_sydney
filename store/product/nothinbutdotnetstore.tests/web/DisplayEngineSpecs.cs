 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.mbunit.standard.observations;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core.frontcontroller;
 using developwithpassion.bdd;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class DisplayEngineSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<DisplayEngine,
                                             DisplayEngineImplementation>
         {
        
         }

         [Concern(typeof(DisplayEngineImplementation))]
         public class when_told_to_display_an_item : concern
         {
             context c = () =>
             {
                 items = new List<int>();
                 render = an<ItemRender>();
                 renderer_registry = the_dependency<ItemRendererRegistry>();
                 renderer_registry.Stub(x => x.get_renderer_for<IEnumerable<int>>()).Return(render);
             };

             because b = () =>
             {
                sut.display(items); 
             };

        
             it should_tell_the_item_renderer_for_the_item_to_render_the_item = () =>
             {
                 render.received(x => x.render(items));
             };

             static ItemRender render;
             static IEnumerable<int> items;
             static ItemRendererRegistry renderer_registry;
         }
     }
 }
