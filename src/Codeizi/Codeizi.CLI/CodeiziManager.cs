using Codeizi.DI;
using Codeizi.Service.Commands;

namespace Codeizi.CLI
{
    public class CodeiziManager(ISetupDependencyInjection injection) : ICodeiziManager
    {
        public void Start(string[] args)
        {
            injection.Initialize();

            var factoryCommands = injection.Get<FactoryCommand>();

            var commands = factoryCommands.Create(args);

            foreach (var command in commands)
            {
                var executionType = factoryCommands.GetExecution(command);
                injection.Get(executionType).Proccess(command.GetArgs(args));
            }
        }
    }
}
