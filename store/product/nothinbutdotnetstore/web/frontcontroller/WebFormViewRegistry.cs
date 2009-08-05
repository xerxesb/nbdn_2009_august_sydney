namespace nothinbutdotnetstore.web.frontcontroller
{
    public interface WebFormViewRegistry
    {
        WebFormViewInformation get_view_information_for<T>();
    }
}