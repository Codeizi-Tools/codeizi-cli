using System.Diagnostics.CodeAnalysis;

namespace Codeizi.Service.Commands
{
    public record VersionCommand : BaseCommand
    {
        public VersionCommand() : base("-version", "-v")
        {
        }
        public override IEnumerable<ParameterCommand> GetArgs(string[] args) => [];

        [ExcludeFromCodeCoverage]
        public override string[] GetParameters() => [];
    }
}
