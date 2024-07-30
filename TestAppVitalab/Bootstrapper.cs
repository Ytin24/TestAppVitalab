using TestAppVitalab.ViewModels;
using TestAppVitalab.Views;
using Autofac;
using ReactiveUI;
using Splat;
using Splat.Autofac;
using System.Linq;
using System.Reflection;
using TestAppVitalab.Services;

namespace TestAppVitalab {
    public static class Bootstrapper
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterAllServices>();

            builder.RegisterModule<RegisterAllViewModels>();


            AutofacDependencyResolver resolver = new AutofacDependencyResolver(builder);
            Locator.SetLocator(resolver);
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();

            var container = builder.Build();
            resolver.SetLifetimeScope(container);
        }
    }
    public class RegisterAllViewModels : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("ViewModel"))
                   .AsImplementedInterfaces()
                   .AsSelf()
                   .SingleInstance();
        }
    }
    public class RegisterAllServices : Autofac.Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<AuthService>()
                .AsImplementedInterfaces();

            builder.RegisterType<ViewModelService>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
