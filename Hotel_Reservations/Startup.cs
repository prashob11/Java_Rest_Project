using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel_Reservations.Startup))]
namespace Hotel_Reservations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
