namespace Codeizi.Service.Commands
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class CommandAttribute(Type type) : Attribute
    {
        public Type Type { get; } = type;
    }
}
