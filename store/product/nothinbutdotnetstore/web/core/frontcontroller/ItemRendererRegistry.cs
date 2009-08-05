namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface ItemRendererRegistry
    {
        ItemRender get_renderer_for<Item>();
    }
}