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
            // passed tests (yay!)
            tokens.Add(new Token([new SingleToken(TokenType.LiteralCharacter, "a")]));
            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "a")]));
            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "Hello, "), new SingleToken(TokenType.LiteralString, "World")]));
            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "Hello, "), new SingleToken(TokenType.LiteralString, "World"), new SingleToken(TokenType.LiteralCharacter, "!")]));
            tokens.Add(new Token([new SingleToken(TokenType.LiteralNumber, "123"), new SingleToken(TokenType.LiteralString, "ABC"), new SingleToken(TokenType.LiteralCharacter, "!")]));
            tokens.Add(new Token([new SingleToken(TokenType.Number), new SingleToken(TokenType.LiteralString, " is a number!")]));
            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "This is also a number: "), new SingleToken(TokenType.Number), new SingleToken(TokenType.LiteralNumber, ".")]));
        }
        [TestCase(0, "a")]
        [TestCase(1, "a")]
        [TestCase(2, "Hello, World")]
        [TestCase(3, "Hello, World!")]
        [TestCase(4, "123ABC!")]
        [TestCase(5, "123 is a number!")]
        [TestCase(6, "This is also a number: 512.")]
        public void TestParserMethod1(int indexOfTokenList, string parse)
        {
            string[] parsed = tokens[indexOfTokenList].Parse(parse);
            if (parsed.Length == 0)
            {
                Assert.Fail();
            }
            for (int i = 0; i < parsed.Length; i++)
            {
                Console.WriteLine(indexOfTokenList + ": " + parsed[i]);
            }
            Assert.Pass();
        }
    }
}