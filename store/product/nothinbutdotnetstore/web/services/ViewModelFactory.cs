using System.Collections.Generic;
using nothinbutdotnetstore.web.models;
using nothinbutdotnetstore.web.viewmodels;

namespace nothinbutdotnetstore.web.services
{
    public interface ViewModelFactory {
        ViewModel create(IEnumerable<Department> departments);   
    }
}