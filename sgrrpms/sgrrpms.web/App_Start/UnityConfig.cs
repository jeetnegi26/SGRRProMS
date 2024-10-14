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
        public object ResolveUnregistered(Type type)
        {
            var constructors = type.GetConstructors();
            foreach ( var constructor in constructors)
            {
                try
                {
                    var parameters = constructor.GetParameters();
                    var parameterInstance = new List<Object>();
                    foreach ( var parameter in parameters)
                    {
                        var service = this.DependencyContainer.Resolve(parameter.ParameterType);
                        if (service == null) throw new Exception("UnKnown Dependency to resolve");
                        parameterInstance.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstance.ToArray());
                }
                catch (Exception)
                {

                    throw;
                }
            }
            throw new Exception("No Constructor found");
        }
    }
}