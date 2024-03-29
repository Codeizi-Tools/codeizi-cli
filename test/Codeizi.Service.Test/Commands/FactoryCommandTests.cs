using Codeizi.Service.Commands;

namespace Codeizi.Service.Test.Commands
{
    public class FactoryCommandTests
    {
        [Fact]
        public void Create_SingleToken_ReturnsValidCommand()
        {
            // Arrange
            var factory = new FactoryCommand();
            string token = "-version";

            // Act
            var command = factory.Create(token);

            // Assert
            Assert.NotNull(command);
            Assert.IsType<VersionCommand>(command);
        }

        [Fact]
        public void Create_MultipleTokens_ReturnsValidCommands()
        {
            // Arrange
            var factory = new FactoryCommand();
            string[] tokens = { "-version", "-v" };

            // Act
            var commands = factory.Create(tokens);

            // Assert
            Assert.NotNull(commands);
            Assert.Equal(tokens.Length, commands.Count());

            foreach (var command in commands)
            {
                Assert.NotNull(command);
                Assert.IsAssignableFrom<BaseCommand>(command);
            }
        }

        [Fact]
        public void Create_InvalidToken_ThrowsException()
        {
            // Arrange
            var factory = new FactoryCommand();
            string token = "invalidCommand";

            // Act & Assert
            Assert.Throws<CommandException>(() => factory.Create(token));
        }
    }
}