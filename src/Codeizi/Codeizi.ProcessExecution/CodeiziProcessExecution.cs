using Codeizi.ConsoleManager;

namespace Codeizi.ProcessExecution
{
    public class CodeiziProcessExecution(ICodeiziConsoleManager console,
        IProcessExecution process) : ICodeiziProcessExecution
    {
        public void Execute(string fileName,
            string arguments)
        {
            int exitCode = process.Execute(fileName, arguments);
            if (exitCode == 0)
            {
                console.WriteLine("Comando executado com sucesso.");
            }
            else
            {
                console.WriteLine($"Ocorreu um erro ao executar o comando. Código de saída: {exitCode}");
            }
        }
    }
}
