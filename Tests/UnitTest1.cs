using _mode_7;
using NuGet.Frameworks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        List<Token> tokens = new List<Token>(2);
        [SetUp]
        public void Setup()
        {
            tokens.Add(new Token([new SingleToken(TokenType.LiteralCharacter, "a")]));
        }
        [TestCase(0, "a")]
        public void TestParserMethod1(int indexOfTokenList, string parse)
        {
            string[] parsed = tokens[indexOfTokenList].Parse(parse);
            if (parsed.Length == 0)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}