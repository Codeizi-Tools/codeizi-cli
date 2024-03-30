using Codeizi.ConsoleManager;
using System.Diagnostics;

namespace Codeizi.ProcessExecution
{
    public class CodeiziProcessExecution(ICodeiziConsoleManager console) : ICodeiziProcessExecution
    {
        public void Execute(string fileName,
            string arguments)
        {
            Process process = new();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.OutputDataReceived += (sender, e) => console.WriteLine(e?.Data ?? string.Empty);
            process.ErrorDataReceived += (sender, e) => console.WriteLine(e?.Data ?? string.Empty);
            process.Start();
            process.BeginErrorReadLine();
            process.WaitForExit();
            int exitCode = process.ExitCode;
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
