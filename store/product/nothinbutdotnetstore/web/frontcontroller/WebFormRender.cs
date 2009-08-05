using System;

namespace nothinbutdotnetstore.web.frontcontroller
{
    public class WebFormRender : ItemRender
    {
        static public ViewFactory view_factory = (x, y) =>
        {
            throw new Exception();
        };

        public void render<Item>(Item item)
        {
            throw new NotImplementedException();
        }
    }
}