using Codeizi.ConsoleManager;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Codeizi.ProcessExecution
{
    [ExcludeFromCodeCoverage]
    public class WindowsProcessExecution(ICodeiziConsoleManager console) : IProcessExecution
    {
        public int Execute(string fileName, string arguments)
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
            return process.ExitCode;
        }
    }
}
