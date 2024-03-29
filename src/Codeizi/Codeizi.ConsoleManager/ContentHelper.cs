namespace Codeizi.ConsoleManager
{
    public class ContentHelper
    {
        private readonly List<KeyValuePair<string, ConsoleColor>> _content;
        public ContentHelper()
        {
            _content = [];
        }

        public ContentHelper AddToken(string token)
        {
            _content.Add(new KeyValuePair<string, ConsoleColor>(token, ConsoleColor.White));
            return this;
        }

        public ContentHelper AddToken(string token, ConsoleColor color)
        {
            _content.Add(new KeyValuePair<string, ConsoleColor>(token, color));
            return this;
        }

        public ContentHelper AddDefaultSpaces()
        {
            _content.Add(new KeyValuePair<string, ConsoleColor>("    ", ConsoleColor.White));
            return this;
        }
    }
}