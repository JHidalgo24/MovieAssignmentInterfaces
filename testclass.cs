using Xunit;

namespace AbstractMovieAssignment
{
    public class Testclass
    {

        //should pass as Toy Story (1995) is in the file
        [Fact]
        public void PassingDuplicateTest()
        {
            Assert.True(Program.DuplicateChecker("Toy Story (1995)","Movie"));
        }


        //All should fail except 1
        [Theory]
        [InlineData("Toy Story (1995)")]//pass specific title found with year
        [InlineData("Toy Story")]//fail as it's too vague of a title to pass
        public void TheoryTest(string movie)
        {
            Assert.True(Program.DuplicateChecker(movie,"Movie"));
        }
        
        
    }
}