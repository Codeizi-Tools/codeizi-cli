using Codeizi.ConsoleManager;
using Codeizi.ProcessExecution;
using Codeizi.Service.Commands;

namespace Codeizi.Service.Executions
{
    [Command(typeof(NewProjectMinimalApiCommand))]
    public class NewProjectMinimalApiExecution(ICodeiziConsoleManager console,
        ICodeiziProcessExecution processExecution) : IExecutionCommand
    {
        /// <summary>
        /// 1. Enter the name of the project:
        /// --> dotnet new webapiaot -o [name]
        /// </summary>
        public void Proccess(IEnumerable<ParameterCommand> args)
        {
            var projectName = (args.FirstOrDefault(x => x.Name.Equals(NewProjectMinimalApiCommand.SHORT_NAME))
                ?? args.FirstOrDefault(x => x.Name.Equals(NewProjectMinimalApiCommand.LONG_NAME)))
                    ?? throw ParameterForCommandNotFound.Throw("np-minimal-api");
            processExecution.Execute("dotnet", $"new webapi -o {projectName!.Value}");
            console.WriteLine("Projeto criado com sucesso");
        }
    }
}
