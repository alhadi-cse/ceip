<%@ Application Language="C#" %>
<%@ Import Namespace="ceip" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        AspMap.License.SetLicenseKey("cffcffcaembjdcdlphgondamomkphoojkgghbmnhlhbhed");
    }

</script>
