using Microsoft.Owin;
using Owin;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(MVC_Login_B.Startup))]
namespace MVC_Login_B
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
