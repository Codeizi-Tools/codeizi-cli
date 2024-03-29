using Codeizi.CLI;
using Codeizi.DI;
using Codeizi.Service.Commands;

public class Program
{
    public static int Main(string[] args)
    {
        try
        {
            if (args.Length == 0)
                args = ["-v"];
            new CodeiziManager(new SetupDependencyInjection()).Start(args);
            return (int)EnumCodeReturn.SUCCES_RETURN;
        }
        catch (CommandException)
        {
            return (int)EnumCodeReturn.COMMAND_NOT_FOUND;
        }
        catch (Exception)
        {
            return (int)EnumCodeReturn.INTERNAL_ERROR;
        }
    }
}