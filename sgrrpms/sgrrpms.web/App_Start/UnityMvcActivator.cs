using sgrrpms.web.App_Start;
using System;
using System.Linq;
using System.Web.Mvc;
using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyProject.Web.App_Start.UnityMvcActivator), nameof(MyProject.Web.App_Start.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(MyProject.Web.App_Start.UnityMvcActivator), nameof(MyProject.Web.App_Start.UnityMvcActivator.Shutdown))]

namespace MyProject.Web.App_Start
{
    public static class UnityMvcActivator
    {
        public static void Start()
        {
            // Ensure that the container is initialized before using it
            var container = UnityConfig.RegisterComponents();

            if (container == null)
            {
                throw new InvalidOperationException("Unity container is not initialized.");
            }

            // Use Unity as the Dependency Resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // Optionally, register the Unity filter provider
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));
        }

        public static void Shutdown()
        {
            var container = UnityConfig.Container;
            container.Dispose();
        }
    }
}
