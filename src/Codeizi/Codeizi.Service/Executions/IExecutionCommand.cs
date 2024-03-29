using Codeizi.Service.Commands;

namespace Codeizi.Service.Executions
{
    public interface IExecutionCommand
    {
        void Proccess(IEnumerable<ParameterCommand> args);
    }
}
