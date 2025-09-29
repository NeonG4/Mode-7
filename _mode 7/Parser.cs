using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _mode_7
{
    public class Token
    {
        public List<SingleToken> tokens;
        public Token(int length) 
        {
            tokens = new List<SingleToken>(length);
        }
        public Token(List<SingleToken> tokens)
        {
            this.tokens = tokens;
        }
        public void AddLiteral(string lit)
        {
            tokens.Add(new SingleToken(TokenType.LiteralString, lit));
        }
        public string[] Parse(string function)
        {

            try
            {
                List<string> calculatedTokens = new List<string> ();
                int tokenIdx = 0;
                int parsingTokenSize = 0;
                string summedString = string.Empty;
                for (int i = 0; i < function.Length; i++)
                {
                    if (tokens[tokenIdx].type == TokenType.LiteralCharacter)
                    {
                        if (function[i].ToString() == tokens[tokenIdx].key)
                        {
                            calculatedTokens.Add(function[i].ToString());
                            parsingTokenSize = 0;
                            tokenIdx++;
                        }
                        else
                        {
                            return []; // failed, unexpected literal
                        }

                    }
                    else if (tokens[tokenIdx].type == TokenType.LiteralString || tokens[tokenIdx].type == TokenType.LiteralNumber)
                    {
                        if (parsingTokenSize == tokens[tokenIdx].key.Length - 1)
                        {
                            summedString += function[i];
                            calculatedTokens.Add(summedString);
                            summedString = string.Empty;
                            parsingTokenSize = 0;
                            tokenIdx++;
                        }
                        else if (tokens[tokenIdx].key[parsingTokenSize] == function[i])
                        {
                            summedString += function[i];
                            parsingTokenSize++;
                        }
                        else
                        {
                            return [];
                        }
                    }
                    else if (tokens[tokenIdx].type == TokenType.Number)
                    {
                        if ("0123456789".Contains(function[i + 1]))
                        {
                            summedString += function[i];
                            parsingTokenSize++;
                        }
                        else
                        {
                            summedString += function[i];
                            calculatedTokens.Add(summedString);
                            summedString = string.Empty;
                            parsingTokenSize = 0;
                            tokenIdx++;
                        }
                    }
                }
                return calculatedTokens.ToArray();
            }
            catch
            {
                return [];
            }
        }
    }
    public class SingleToken
    {
        public TokenType type;
        public string key;
        public SingleToken(TokenType t)
        {
            this.type = t;
            key = string.Empty;
        }
        public SingleToken(TokenType t, string key)
        {
            this.type = t;
            this.key = key;
        }
    }
    public enum TokenType
    {
        None,
        WhiteSpace,
        LiteralString,
        LiteralNumber,
        LiteralCharacter,
        String,
        Number,
        Character,
        MAX
    }
}
