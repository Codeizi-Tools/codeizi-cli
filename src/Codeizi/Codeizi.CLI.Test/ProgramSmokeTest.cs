namespace Codeizi.CLI.Test
{
    public class ProgramSmokeTest
    {
        [Fact]
        public void SmokeOkTest()
        {
            var result = Program.Main(["-version"]);
            Assert.Equal(0, result);
        }
    }
}
