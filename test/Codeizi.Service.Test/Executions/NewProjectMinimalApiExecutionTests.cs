using Codeizi.ConsoleManager;
using Codeizi.ProcessExecution;
using Codeizi.Service.Commands;
using Codeizi.Service.Executions;
using NSubstitute;

namespace Codeizi.Service.Test.Executions
{
    public class NewProjectMinimalApiExecutionTests
    {
        [Fact]
        public void Proccess_CreatesProjectSuccessfully()
        {
            // Arrange
            var consoleMock = Substitute.For<ICodeiziConsoleManager>();
            var processExecutionMock = Substitute.For<ICodeiziProcessExecution>();

            var projectName = "MyProject";
            var args = new List<ParameterCommand>
            {
                new(NewProjectMinimalApiCommand.SHORT_NAME, projectName)
            };

            var execution = new NewProjectMinimalApiExecution(consoleMock, processExecutionMock);

            // Act
            execution.Proccess(args);

            // Assert
            processExecutionMock.Received(1).Execute("dotnet", $"new webapi -o {projectName}");
            consoleMock.Received(1).WriteLine("Projeto criado com sucesso");
        }

        [Fact]
        public void Proccess_NoProjectName_ThrowsException()
        {
            // Arrange
            var consoleMock = Substitute.For<ICodeiziConsoleManager>();
            var processExecutionMock = Substitute.For<ICodeiziProcessExecution>();

            var args = new List<ParameterCommand>(); // No project name provided

            var execution = new NewProjectMinimalApiExecution(consoleMock, processExecutionMock);

            // Act & Assert
            Assert.Throws<CommandException>(() => execution.Proccess(args));
            processExecutionMock.DidNotReceive().Execute(Arg.Any<string>(), Arg.Any<string>());
            consoleMock.DidNotReceive().WriteLine(Arg.Any<string>());
        }
    }
}
