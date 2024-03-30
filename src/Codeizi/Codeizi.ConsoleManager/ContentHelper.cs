namespace Codeizi.ConsoleManager
{
    public class ContentHelper
    {
        public readonly List<KeyValuePair<string, ConsoleColor>> Content;
        public ContentHelper()
        {
            Content = [];
        }

        public ContentHelper AddToken(string token)
        {
            Content.Add(new KeyValuePair<string, ConsoleColor>(token, ConsoleColor.White));
            return this;
        }

        public ContentHelper AddToken(string token, ConsoleColor color)
        {
            Content.Add(new KeyValuePair<string, ConsoleColor>(token, color));
            return this;
        }

        public ContentHelper AddDefaultSpaces()
        {
            Content.Add(new KeyValuePair<string, ConsoleColor>("    ", ConsoleColor.White));
            return this;
        }
    }
}