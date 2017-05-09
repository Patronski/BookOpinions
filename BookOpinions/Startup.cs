using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookOpinions.Startup))]
namespace BookOpinions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //Tips for creating Roles and Users
            //CreateRolesandUsers();
        }
    }
}
