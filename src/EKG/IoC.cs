using Autofac;

namespace EKG
{
    public static class IoC
    {
        private static IContainer _container;

        public static IContainer Container => _container;

        public static void LetThereBeIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(
                typeof(Startup).Assembly);
            _container = builder.Build();
        }
    }
}