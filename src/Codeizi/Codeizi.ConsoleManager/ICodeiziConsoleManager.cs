namespace Codeizi.ConsoleManager
{
    public interface ICodeiziConsoleManager
    {
        void WriteLine(string message);
        void Write(string message);
        void Reset();
        void Color(ConsoleColor color);
    }
}