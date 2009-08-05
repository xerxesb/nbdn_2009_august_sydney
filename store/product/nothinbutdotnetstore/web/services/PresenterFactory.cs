using nothinbutdotnetstore.web.presenters;
using nothinbutdotnetstore.web.viewmodels;
using nothinbutdotnetstore.web.views;

namespace nothinbutdotnetstore.web.services
{
    public interface PresenterFactory
    {
        Presenter create(ViewModel view_model, View view);
    }
}