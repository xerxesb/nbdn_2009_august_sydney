using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tasks
{
    public class ApplicationStartup : ApplicationStartupCommand
    {
        static public void start_the_application()
        {
            new ApplicationStartup().run();
        }

        public void run()
        {
            Start.by<ConfigureCoreServices>()
                 .followed_by<ConfigureFrontController>()
                 .followed_by<ConfigureTheServiceLayer>()
                 .finish_by<ConfigureTheApplicationRoutes>();
        }
    }
}