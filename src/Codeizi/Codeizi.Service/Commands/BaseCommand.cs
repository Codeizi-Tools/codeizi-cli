namespace Codeizi.Service.Commands
{
    public abstract record BaseCommand(string Name,
                                       string ShortName)
    {
        public string Name { get; } = Name;
        public string ShortName { get; } = ShortName;
        public abstract IEnumerable<ParameterCommand> GetArgs(string[] args);
        public abstract string[] GetParameters();

    }
}
