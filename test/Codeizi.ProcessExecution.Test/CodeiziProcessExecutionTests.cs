using Codeizi.ConsoleManager;
using Moq;

namespace Codeizi.ProcessExecution.Test
{
    public class CodeiziProcessExecutionTests
    {
        [Fact]
        public void Execute_WithExitCodeZero_ShouldWriteSuccessMessage()
        {
            // Arrange
            var mockConsole = new Mock<ICodeiziConsoleManager>();
            var mockProcess = new Mock<IProcessExecution>();
            mockProcess.Setup(p => p.Execute(It.IsAny<string>(), It.IsAny<string>())).Returns(0);
            var processExecution = new CodeiziProcessExecution(mockConsole.Object, mockProcess.Object);
            var fileName = "test.exe";
            var arguments = "-arg1 -arg2";

            // Act
            processExecution.Execute(fileName, arguments);

            // Assert
            mockConsole.Verify(console => console.WriteLine("Comando executado com sucesso."), Times.Once);
        }

        [Fact]
        public void Execute_WithNonZeroExitCode_ShouldWriteErrorMessage()
        {
            // Arrange
            var mockConsole = new Mock<ICodeiziConsoleManager>();
            var mockProcess = new Mock<IProcessExecution>();
            mockProcess.Setup(p => p.Execute(It.IsAny<string>(), It.IsAny<string>())).Returns(1);
            var processExecution = new CodeiziProcessExecution(mockConsole.Object, mockProcess.Object);
            var fileName = "test.exe";
            var arguments = "-arg1 -arg2";

            // Act
            processExecution.Execute(fileName, arguments);

            // Assert
            mockConsole.Verify(console => console.WriteLine("Ocorreu um erro ao executar o comando. Código de saída: 1"), Times.Once);
        }

    }
}