using nothinbutdotnetstore.web.core.frontcontroller.stubs;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class DisplayEngineImplementation : DisplayEngine
    {
        ItemRendererRegistry renderers;

        public DisplayEngineImplementation():this(new StubItemRendererRegistry()) {}

        public DisplayEngineImplementation(ItemRendererRegistry renderers)
        {
            this.renderers = renderers;
        }

        public void display<Item>(Item item)
        {
            renderers.get_renderer_for<Item>().render(item);
        }
    }
}