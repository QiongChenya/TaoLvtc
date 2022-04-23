using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using TaoLvtc.IaoLvtcServiceAdmin;
using TaoLvtc.ITaoLvtcService;
using TaoLvtc.Models;

namespace TaoLvtc
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            builder.RegisterType<UserService>().As<IUserService<Users>>().SingleInstance();
            builder.RegisterType<AdminService>().As<IAdmin<Administrators>>().SingleInstance();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
        /// <summary>
        /// 配置Ajax跨域访问
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToUpper() == "OPTIONS")
            {
                Response.StatusCode = 200;
                Response.End();
            }
        }
    }
}
