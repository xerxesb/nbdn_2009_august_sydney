namespace nothinbutdotnetstore.web.frontcontroller
{
    public interface ItemRendererRegistry
    {
        ItemRender get_renderer_for<Item>();
    }
}