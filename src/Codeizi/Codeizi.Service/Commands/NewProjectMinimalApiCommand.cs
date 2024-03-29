namespace Codeizi.Service.Commands
{
    public record NewProjectMinimalApiCommand : BaseCommand
    {
        private readonly string[] _parameters = [SHORT_NAME, LONG_NAME];

        public NewProjectMinimalApiCommand() : base("np-minimal-api", "npmapi") { }
        public const string SHORT_NAME = "-n";
        public const string LONG_NAME = "-name";
        public override string[] GetParameters() => [SHORT_NAME];
        public override IEnumerable<ParameterCommand> GetArgs(string[] args)
        {
            var parameters = new List<ParameterCommand>();
            _parameters.ToList().ForEach(p =>
            {
                var index = args.ToList().FindIndex(x => x.Equals(p));
                if (parameters.Count != 0 && index >= 0)
                    throw DuplicatedParameter.Throw(p);

                if (index >= 0)
                    parameters.Add(new ParameterCommand(p, args[index + 1]));
            });
            return parameters;
        }
    }
}
