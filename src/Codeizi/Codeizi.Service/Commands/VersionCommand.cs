namespace Codeizi.Service.Commands
{
    public record VersionCommand : BaseCommand
    {
        public VersionCommand() : base("-version", "-v")
        {
        }
        public override IEnumerable<ParameterCommand> GetArgs(string[] args) => [];

        public override string[] GetParameters() => [];
    }
}
