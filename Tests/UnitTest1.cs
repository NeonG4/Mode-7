using _mode_7;
using NuGet.Frameworks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        List<Token> tokens = new List<Token>();
        List<string> inputs = new List<string>();
        List<string[]> expected = new List<string[]>();
        [SetUp]
        public void Setup()
        {
            // "\n\n\n" is used for any non literal numbers
            tokens.Add(new Token([new SingleToken(TokenType.LiteralCharacter, "a")]));
            inputs.Add("a");
            expected.Add(["a"]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "a")]));
            inputs.Add("a");
            expected.Add(["a"]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "Hello, "), new SingleToken(TokenType.LiteralString, "World")]));
            inputs.Add("Hello, World");
            expected.Add(["Hello, ", "World"]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "Hello, "), new SingleToken(TokenType.LiteralString, "World"), new SingleToken(TokenType.LiteralCharacter, "!")]));
            inputs.Add("Hello, World!");
            expected.Add(["Hello, ", "World", "!"]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralNumber, "123"), new SingleToken(TokenType.LiteralString, "ABC"), new SingleToken(TokenType.LiteralCharacter, "!")]));
            inputs.Add("123ABC!");
            expected.Add(["123", "ABC", "!"]);

            tokens.Add(new Token([new SingleToken(TokenType.Number), new SingleToken(TokenType.LiteralString, " is a number!")]));
            inputs.Add("5122 is a number!");
            expected.Add(["\n\n\n", " is a number!"]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "This is also a number: "), new SingleToken(TokenType.Number), new SingleToken(TokenType.LiteralCharacter, ".")]));
            inputs.Add("This is also a number: 123.");
            expected.Add(["This is also a number: ", "\n\n\n", "."]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "wait "), new SingleToken(TokenType.Number)]));
            inputs.Add("wait 45");
            expected.Add(["wait ", "\n\n\n"]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "abc")]));
            inputs.Add("def");
            expected.Add([]);

            tokens.Add(new Token([new SingleToken(TokenType.LiteralString, "Test for negative numbers (-5):"), new SingleToken(TokenType.Number)]));
            inputs.Add("Test for negative numbers (-5):-5");
            expected.Add(["Test for negative numbers (-5):", "\n\n\n"]);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        public void TestParserMethod1(int indexOfTokenList)
        {
            string[] final = expected[indexOfTokenList];
            string parse = inputs[indexOfTokenList];
            string[] parsed = tokens[indexOfTokenList].Parse(parse);
            
            if (parsed.Length != final.Length)
            {
                Console.WriteLine($"Expected: {final.Length} got: {parsed.Length}");
                Assert.Fail();
            }
            for (int i = 0; i < final.Length; i++)
            {
                if (final[i] == parsed[i])
                {
                    // yay!
                }
                else
                {
                    if (final[i] == "\n\n\n")
                    {
                        // 3 letters to signify a custom number (not a literal)
                        Console.WriteLine("const");
                    }
                    else
                    {
                        Console.WriteLine("Failed on: \"" + final[i] + "\"");
                        Assert.Fail();
                    }
                }
                Console.WriteLine(indexOfTokenList + ": \"" + parsed[i] + "\"");
            }
            Assert.Pass();
        }
    }
}