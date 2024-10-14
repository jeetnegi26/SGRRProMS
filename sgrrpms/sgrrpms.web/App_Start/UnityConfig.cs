using Account;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using UserRepositoryData;

namespace sgrrpms.web.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; private set; }

        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();
            var ConnectionString = ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString;
            // Register your components here
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IUserRepository, UserRepository>(ConnectionString);
                new InjectionConstructor();

            Container = container;
            return container;
        }
    }
}