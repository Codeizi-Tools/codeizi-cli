﻿using Codeizi.DI;
using Codeizi.Service.Commands;
using System.Diagnostics.CodeAnalysis;

namespace Codeizi.CLI
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        protected Program() { }

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
}