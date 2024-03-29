using Codeizi.ConsoleManager;
using Codeizi.Service.Commands;
using Codeizi.Service.Executions;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.DI
{
    public class SetupDependencyInjection : ISetupDependencyInjection
    {
        private ServiceProvider? _serviceCollection;

        public void Initialize()
        {
            _serviceCollection = new ServiceCollection()
                .AddScoped<ICodeiziConsoleManager, CodeiziConsoleManager>()
                .AddScoped<VersionExecution>()
                .AddScoped<NewProjectMinimalApiExecution>()
                .AddSingleton<FactoryCommand>()
                .BuildServiceProvider();
        }

        public T Get<T>() where T : notnull
            => _serviceCollection!.GetRequiredService<T>();

        public IExecutionCommand Get(Type type)
            => (IExecutionCommand)_serviceCollection!.GetService(type);

    }
}
