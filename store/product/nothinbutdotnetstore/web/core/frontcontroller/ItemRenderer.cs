namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface ItemRenderer
    {
        void render<Item>(Item item);
    }
}