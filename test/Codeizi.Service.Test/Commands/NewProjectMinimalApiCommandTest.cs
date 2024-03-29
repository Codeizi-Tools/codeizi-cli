using Codeizi.Service.Commands;

namespace Codeizi.Service.Test.Commands
{
    public class NewProjectMinimalApiCommandTest
    {
        [Fact]
        public void GetArgs_ReturnsCorrectParameters()
        {
            // Arrange
            var command = new NewProjectMinimalApiCommand();
            var args = new string[] { "-n", "MyProjectName" };

            // Act
            var result = command.GetArgs(args);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);

            var parameter1 = result.FirstOrDefault(p => p.Name == "-n");
            Assert.NotNull(parameter1);
            Assert.Equal("MyProjectName", parameter1.Value);
        }

        [Fact]
        public void GetArgs_ReturnsErrosWithDuplicatedParameters()
        {
            // Arrange
            var command = new NewProjectMinimalApiCommand();
            var args = new string[] { "-n", "MyProjectName", "-name", "MyName" };

            // Act            
            // Assert
            Assert.Throws<CommandException>(() => command.GetArgs(args));
        }

        [Fact]
        public void GetArgs_NoParameters_ReturnsEmptyList()
        {
            // Arrange
            var command = new NewProjectMinimalApiCommand();
            var args = Array.Empty<string>();

            // Act
            var result = command.GetArgs(args);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetArgs_Others_Parameters_ReturnsEmptyList()
        {
            // Arrange
            var command = new NewProjectMinimalApiCommand();
            var args = new string[] { "-any", "MyProjectName" };

            // Act
            var result = command.GetArgs(args);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void GetArgs_WithValidANdOthersParameters()
        {
            // Arrange
            var command = new NewProjectMinimalApiCommand();
            var args = new string[] { "-n", "MyProjectName", "-any", "MyProjectName" };

            // Act
            var result = command.GetArgs(args);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("-n", result.First().Name);
            Assert.Equal("MyProjectName", result.First().Value);
        }
    }
}
