using Codeizi.ConsoleManager;

namespace Codeizi
{
    public class CodeiziConsoleManager : ICodeiziConsoleManager
    {
        public void Color(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void Reset()
        {
            Console.ResetColor();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
