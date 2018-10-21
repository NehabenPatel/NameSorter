using Autofac;
using name_sorter.Logic.Interface;
using name_sorter.Logic.Service;

namespace name_sorter.Logic.Infrastructure
{
    public static class DependencyRegister
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SortNamesService>().As<ISortNamesService>();
            builder.RegisterType<FileService>().As<IFileService>();

            return builder.Build();
        }
    }
}
