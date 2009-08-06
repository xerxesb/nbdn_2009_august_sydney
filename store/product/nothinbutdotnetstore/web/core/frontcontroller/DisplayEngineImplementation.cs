namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class DisplayEngineImplementation : DisplayEngine
    {
        ItemRenderer renderer;

        public DisplayEngineImplementation(ItemRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void display<Item>(Item item)
        {
            renderer.render(item);
        }
    }
}