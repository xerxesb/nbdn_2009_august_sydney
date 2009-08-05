namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public interface WebFormViewRegistry
    {
        WebFormViewInformation get_view_information_for<T>();
    }
}