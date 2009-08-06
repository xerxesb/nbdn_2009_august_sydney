<%@ Application Language="C#" %>
<%@ Import Namespace="nothinbutdotnetstore.tasks"%>
<script runat="server">

        private void Application_Start(object sender, EventArgs e)
        {
            new ApplicationStartup().run();
        }


</script>
