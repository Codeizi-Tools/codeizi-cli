using System.Reflection;

namespace Codeizi.Service.Commands
{
    public class FactoryCommand
    {
        private readonly List<BaseCommand> _commands = [
            new VersionCommand(),
            new NewProjectMinimalApiCommand()];

        public BaseCommand Create(string token)
            => _commands.Find(x => x.Name.ToLower().Equals(token.ToLower()) ||
                        x.ShortName.ToLower().Equals(token.ToLower())) ??
                throw CommandNotFound.Throw(token);

        public IEnumerable<BaseCommand> Create(string[] tokens)
            => tokens.Select(x => Create(x));


        public Type GetExecution(BaseCommand command)
        {
            var executions = this.GetType().Assembly.GetTypes()
                 .Where(x => x.GetCustomAttribute(typeof(CommandAttribute)) != null);

            return executions.First(x => x.GetCustomAttribute<CommandAttribute>()?.Type == command.GetType());

        }
    }
}
