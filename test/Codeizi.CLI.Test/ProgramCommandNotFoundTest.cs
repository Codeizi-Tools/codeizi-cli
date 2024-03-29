namespace Codeizi.CLI.Test
{
    public class ProgramCommandNotFoundTest
    {
        [Fact]
        public void CommandNotFoundTest()
        {
            var result = Program.Main(["-anyname"]);
            Assert.Equal(1, result);
        }
    }
}
