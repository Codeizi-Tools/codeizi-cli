namespace Codeizi.ConsoleManager.Test
{
    public class ContentHelperTests
    {
        [Fact]
        public void AddToken_WithColor_ShouldAddTokenWithColor()
        {
            // Arrange
            var contentHelper = new ContentHelper();
            var token = "test";
            var color = ConsoleColor.Red;

            // Act
            contentHelper.AddToken(token, color);

            // Assert
            Assert.Contains(contentHelper.Content, x => x.Key == token && x.Value == color);
        }

        [Fact]
        public void AddToken_WithoutColor_ShouldAddTokenWithWhiteColor()
        {
            // Arrange
            var contentHelper = new ContentHelper();
            var token = "test";

            // Act
            contentHelper.AddToken(token);

            // Assert
            Assert.Contains(contentHelper.Content, x => x.Key == token && x.Value == ConsoleColor.White);
        }

        [Fact]
        public void AddDefaultSpaces_ShouldAddFourSpacesWithWhiteColor()
        {
            // Arrange
            var contentHelper = new ContentHelper();

            // Act
            contentHelper.AddDefaultSpaces();

            // Assert
            Assert.Contains(contentHelper.Content, x => x.Key == "    " && x.Value == ConsoleColor.White);
        }
    }
}