namespace Codeizi.Service.Commands
{
    public class CommandException(string message) : Exception(message)
    {

    }

    public static class CommandNotFound
    {
        public static CommandException Throw(string command) => new($"The {command} not found");
    }

    public static class DuplicatedParameter
    {
        public static CommandException Throw(string parameter) => new($"The parameter {parameter} has already been used");
    }

    public static class ParameterForCommandNotFound
    {
        public static CommandException Throw(string command) => new($"The parameter for {command} not found");
    }
}
