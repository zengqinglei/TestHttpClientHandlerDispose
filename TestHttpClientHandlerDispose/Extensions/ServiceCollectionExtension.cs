using Autofac;
using Autofac.Extensions.DependencyInjection;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestHttpClientHandlerDispose.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceProvider UseAutofac(this IServiceCollection services)
        {
            // create a container-builder and register dependencies
            var builder = new ContainerBuilder();

            // populate the service-descriptors added to `IServiceCollection`
            // BEFORE you add things to Autofac so that the Autofac
            // registrations can override stuff in the `IServiceCollection`
            // as needed
            builder.Populate(services);

            // this will be used as the service-provider for the application!
            return new AutofacServiceProvider(builder.Build());
        }

        public static IServiceProvider UseWindsor(this IServiceCollection services)
        {
            var windsorContainer = new WindsorContainer();

            return WindsorRegistrationHelper.CreateServiceProvider(windsorContainer, services);
        }
    }
}
