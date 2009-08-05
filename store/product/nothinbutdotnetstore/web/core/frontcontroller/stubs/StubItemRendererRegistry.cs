namespace nothinbutdotnetstore.web.core.frontcontroller.stubs
{
    public class StubItemRendererRegistry : ItemRendererRegistry
    {
        public ItemRender get_renderer_for<Item>()
        {
            return new WebFormRender();
        }
    }
}